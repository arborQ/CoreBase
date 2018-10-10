using CrossCutting.Structure.Business.Authorize;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Structure.Models;
using Structure.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public AuthorizeController(IValidateAccountService accountService, IUserPrincipalService userPrincipalService)
        {
            AccountService = accountService;
            UserPrincipalService = userPrincipalService;
        }

        [HttpPost]
        public async Task<bool> SignIn(string login, string password)
        {
            var success = await AccountService.IsAccoutValid(login, password);

            var claims = new List<Claim>
                {
                    new Claim(CurrentUser.FullNameClaimName, login ?? "????"),
                    new Claim(CurrentUser.LoginClaimName, login ?? "????"),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

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

            return success;
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