using Application;
using Application.Payments.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;

namespace Infrastructure.Payments.Commands;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand,Session>
{
    private readonly ShopDbContext _dbContext;

    public UpdatePaymentCommandHandler(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
    {
        var sessionService = new SessionService();
        var session = await sessionService.GetAsync(command.SessionId);
        if (session == null)
            throw new Exception("Session doesn't exist");
        var order = await _dbContext.Orders.Where(o => o.SessionId == command.SessionId)
            .FirstOrDefaultAsync(cancellationToken);
        if (order == null)
            throw new Exception("Order doesn't exist");
        var shipment = new Shipment()
        {
            Country = session.ShippingDetails.Address.Country,
            Address1 = session.ShippingDetails.Address.Line1,
            Address2 = session.ShippingDetails.Address.Line2,
            City = session.ShippingDetails.Address.City,
            PostalCode = session.ShippingDetails.Address.PostalCode,
            OrderId = order.Id
        };
        
        order.Status = session.Status;
        _dbContext.Update(order);
        await _dbContext.Shipments.AddAsync(shipment, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return session;
    }
}