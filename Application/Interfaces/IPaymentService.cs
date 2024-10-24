using System.Collections;
using Application.DTOs.Payment;
using Stripe.Checkout;

namespace Payment.Service;

public interface IPaymentService
{
    Task<Session> Create(List<PaymentData> data,string domain);
}