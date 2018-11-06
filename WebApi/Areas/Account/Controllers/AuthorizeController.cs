using CrossCutting.Structure.Business.Authorize;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Structure.Areas.Account.Models;
using Structure.Models;
using Structure.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Areas.Account.Models;
using WebApi.Models;

namespace WebApi.Areas.Account
{
    [Route("api/[area]/[controller]")]
    [Area("Account")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IValidateAccountService AccountService;
        private readonly IUserPrincipalService UserPrincipalService;
        private readonly IOptions<WebConfiguration> Configuration;
        private readonly IMediator Mediator;

        public AuthorizeController(IValidateAccountService accountService, IUserPrincipalService userPrincipalService, IOptions<WebConfiguration> configuration, IMediator mediator)
        {
            AccountService = accountService;
            UserPrincipalService = userPrincipalService;
            Configuration = configuration;
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<string> SignIn([FromBody]LoginModel model)
        {
            var user = await Mediator.Send(model);

            //var user = await AccountService.IsAccoutValid(model.Login, model.Password);

            var claims = GetClaims(user).ToList();

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return GenerateJwtToken(claims);
        }

        private IEnumerable<Claim> GetClaims(ICurrentUser user)
        {
            yield return new Claim(nameof(ICurrentUser.Id), user.Id.ToString());
            yield return new Claim(nameof(ICurrentUser.Email), user.Email);
            yield return new Claim(nameof(ICurrentUser.Login), user.Login);
            yield return new Claim(nameof(ICurrentUser.FullName), user.FullName);
        }

        private string GenerateJwtToken(IReadOnlyCollection<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Value.Jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                Configuration.Value.Jwt.ValidIssuer,
                Configuration.Value.Jwt.ValidIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpDelete]
        public async Task SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Authorize]
        public ICurrentUser IsAuthorized()
        {
            return UserPrincipalService.User;
        }
    }
}