using System.Collections;
using Application.DTOs.Payment;
using MediatR;
using Stripe.Checkout;

namespace Application.Payments.Commands;

public class PaymentCommand:IRequest<Session>
{
    public PaymentCommand(ICollection<PaymentDTO> dtos)
    {
        Dtos = dtos;

    }

    public ICollection<PaymentDTO> Dtos { get; set; }

   

}