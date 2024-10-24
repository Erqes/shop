using System.Collections;
using Application.DTOs.Payment;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace Payment.Service;

public class PaymentService : IPaymentService
{
    public async Task<Session> Create(List<PaymentData> data, string domain)
    {
        var products = new List<SessionLineItemOptions>();
        foreach (var item in data)
        {
            var product = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    Currency = "PLN",
                    ProductData =new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = item.ProductName
                    },
                    UnitAmountDecimal = (decimal)item.Price,
                },
                Quantity = item.Quantity,
                
            };
            products.Add(product);
        }

        var options = new SessionCreateOptions
        {
            LineItems = products,
            UiMode = "embedded",
            Mode = "payment",
            ShippingAddressCollection = new SessionShippingAddressCollectionOptions()
            {
                AllowedCountries =new List<string>()
                {
                    "US",
                    "PL"
                }
                
            },
            ReturnUrl = domain + "return?session_id={CHECKOUT_SESSION_ID}",
        };
        var service = new SessionService();
        var session = await service.CreateAsync(options);
        return session;
    }
}