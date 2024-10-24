using Application.DTOs.Payment;
using Application.Payments.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace UI.Controllers;

[Route("payment")]
public class PaymentController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Payment([FromBody] ICollection<PaymentDTO> dtos)
    {
        var session = await mediator.Send(new PaymentCommand(dtos));
        Response.Headers.Add("Location", session.Url);
        return Ok(session);
    }

    [Route("payment-status")]
    [HttpPut]
    public async Task<IActionResult> PaymentStatus([FromBody] string sessionId)
    {

        var session=await mediator.Send(new UpdatePaymentCommand(sessionId));
        return Ok(session);
    }
}