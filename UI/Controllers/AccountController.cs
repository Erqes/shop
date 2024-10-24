using Application.Accounts.Query;
using Application.Command.Customer;
using Application.DTOs.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

[Route("Account")]
public class AccountController(IMediator mediator, IConfiguration configuration) : ControllerBase
{
    [Route("ConfirmEmail")]
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string code)
    {
        var result = await mediator.Send(new ConfirmEmailQuery(userId, code));
        var url = configuration.GetSection("FrontHost").Value;
        return Redirect(url
        );
    }

    [Route("SignUp")]
    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpDTO dto)
    {
        await mediator.Send(new SignUpCommand(dto));
        return Ok();
    }

    [Route("SignIn")]
    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] SignInDTO dto)
    {
        var response = await mediator.Send(new SignInCommand(dto));
        return Ok(response);
    }

    [Route("ResetPassword")]
    [HttpPost]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
    {
        var result = await mediator.Send(new ResetPasswordCommand(dto));
        return Ok(result);
    }

    [Route("ForgotPassword")]
    [HttpPost]
    public async Task<IActionResult> ForgotPassword([FromBody] string email)
    {
        await mediator.Send(new ForgotPasswordCommand(email));
        return Ok();
    }
}