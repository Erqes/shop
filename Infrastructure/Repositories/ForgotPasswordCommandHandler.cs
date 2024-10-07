using System.Web;
using Application.Command.Customer;
using Domain.Entities;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Infrastructure.Repositories;

public class ForgotPasswordCommandHandler:IRequestHandler<ForgotPasswordCommand>
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUrlHelper _url;
    private readonly IEmailService _emailService;
    
    public ForgotPasswordCommandHandler(UserManager<User> userManager, IUrlHelperFactory url, IHttpContextAccessor contextAccessor,IActionContextAccessor actionContextAccessor, IEmailService emailService)
    {
        _userManager = userManager;
        _url = url.GetUrlHelper(actionContextAccessor.ActionContext);
        _contextAccessor = contextAccessor;
        _emailService = emailService;
    }

    public async Task Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            throw new Exception("There is no such email");
        var token =await _userManager.GeneratePasswordResetTokenAsync(user);
        var emailBody = $"Here you can reset your password <a href=\"#URL#\">Click here</a>";
        //var requestFeature = _contextAccessor.HttpContext.Features.Get<IHttpRequestFeature>();
        var callback_url = _contextAccessor.HttpContext.Request.Scheme + "://" +
                           _contextAccessor.HttpContext.Request.Host +
                           _url.Action("ResetPassword", "Account",
                               new { user=user.Id, token=token });
        var body = emailBody.Replace("#URL#",callback_url);
        await _emailService.SendEmail(command.Email, body, "Reset Password");
        
    }
}