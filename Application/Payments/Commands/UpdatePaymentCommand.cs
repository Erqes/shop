using MediatR;
using Stripe.Checkout;

namespace Application.Payments.Commands;

public class UpdatePaymentCommand(string sessionId):IRequest<Session>
{
    public string SessionId { get; set; } = sessionId;
}