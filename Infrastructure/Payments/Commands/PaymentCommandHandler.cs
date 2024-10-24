using System.Collections.ObjectModel;
using Application;
using Application.DTOs.Payment;
using Application.Payments.Commands;
using CustomExceptions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payment.Service;
using Stripe.Checkout;

namespace Infrastructure.Payments.Commands;

public class PaymentCommandHandler : IRequestHandler<PaymentCommand, Session>
{
    private readonly IConfiguration _configuration;
    private readonly ShopDbContext _dbContext;
    private readonly IPaymentService _paymentService;

    public PaymentCommandHandler(ShopDbContext dbContext, IPaymentService paymentService, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _paymentService = paymentService;
        _configuration = configuration;
    }

    public async Task<Session> Handle(PaymentCommand command, CancellationToken cancellationToken)
    {
        var productIds = command.Dtos.Select(dto => dto.Id).ToList();
        var products = await _dbContext.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        var missingProductIds = productIds.Except(products.Select(p => p.Id)).ToList();

        if (missingProductIds.Any())
        {
            throw new ProductNotFoundException(
                $"The following products were not found: {string.Join(", ", missingProductIds)}");
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var order = new Order()
            {
                CustomerId = _dbContext.Customers.SingleOrDefault().Id,//tdo
                Status = "",
            };
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var orderProducts = new List<OrderProduct>();
            var itemsToSell = new List<PaymentData>();
            foreach (var item in command.Dtos)
            {
                var product = products.FirstOrDefault(p => p.Id == item.Id);
                var itemToSell = new PaymentData()
                {
                    Id = item.Id,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Quantity = item.Quantity
                };
                itemsToSell.Add(itemToSell);
                var orderProduct = new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = item.Id,
                    Quantity = item.Quantity
                };
                product.Quantity -= item.Quantity;
                orderProducts.Add(orderProduct);
            }

            await _dbContext.OrderProducts.AddRangeAsync(orderProducts, cancellationToken);
            var session = await _paymentService.Create(itemsToSell, _configuration.GetSection("FrontHost").Value);
            order.Status = session.Status;
            order.SessionId = session.Id;
            order.OrderDate = session.Created;
            _dbContext.Orders.Update(order); 
            await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return session;
        }
        catch 
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}