using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Application;
using Application.Command.Customer;
using Domain;
using Domain.Entities;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using RestSharp;
using RestSharp.Authenticators;

namespace Infrastructure.Repositories;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
{
    private readonly IEmailService _emailService;
    private readonly ShopDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUrlHelper _url;


    public SignUpCommandHandler(ShopDbContext dbContext, UserManager<User> userManager, IUrlHelperFactory url,
        IHttpContextAccessor contextAccessor, IActionContextAccessor actionContext, IEmailService emailService)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _contextAccessor = contextAccessor;
        _emailService = emailService;
        _url = url.GetUrlHelper(actionContext.ActionContext);
    }


    public async Task Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            if (command.Password != command.ConfirmPassword)
                throw new Exception("Password not equal.");

            command.Email = command.Email.Normalize();
            if (await _userManager.FindByEmailAsync(command.Email) != null)
                throw new Exception("User already exists");
            var user = new User()
            {
                UserName = command.FirstName,
                Email = command.Email,
                EmailConfirmed = false
            };
            var isCreated = await _userManager.CreateAsync(user, command.Password);
            if (!isCreated.Succeeded)
                throw new Exception("Error occured while creating new user");
            var isRoleAdded = await _userManager.AddToRoleAsync(user, "Customer");
            if (!isRoleAdded.Succeeded)
                throw new Exception("Error while adding a role");
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var isClaimAdded = await _userManager.AddClaimsAsync(user, claims);
            if (!isClaimAdded.Succeeded)
                throw new Exception("Error occured while adding claims");
            var customer = new Customer()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                UserId = user.Id
            };
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            
            
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var email_body = $"Please confirm your email address <a href=\"#URL#\">Click here</a>";
            //var requestFeature = _contextAccessor.HttpContext.Features.Get<IHttpRequestFeature>();
            var callback_url = _contextAccessor.HttpContext.Request.Scheme + "://" +
                               _contextAccessor.HttpContext.Request.Host +
                               _url.Action("ConfirmEmail", "Account",
                                   new { userId = user.Id, code = code });
            var body = email_body.Replace("#URL#", callback_url);
            await _emailService.SendEmail(user.Email, body, "confirm email");
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}