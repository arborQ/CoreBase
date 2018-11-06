using Authorize.Services;
using CrossCutting.Structure.Business.Authorize;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Structure.Areas.Account.Models;
using Structure.Models;
using Structure.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Authorize.Services
{
    public class UserValidateHandler<TRequest> : IRequestHandler<TRequest, ICurrentUser>
    where TRequest : ILoginModel
    {
        private IValidateAccountService ValidateAccountService;
        public UserValidateHandler(IValidateAccountService validateAccountService) {
            ValidateAccountService = validateAccountService;
        }
        public async Task<ICurrentUser> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await ValidateAccountService.IsAccoutValid(request.Login, request.Password);
        }
    }

    internal class ValidateAccountService : IValidateAccountService, IRequestHandler<ILoginModel, ICurrentUser>
    {
        private readonly AuthorizeUnitOfWork AuthorizeUnitOfWork;
        private readonly ICryptography Cryptography;
        private const string DefaultPassword = "Haslo123!";

        public ValidateAccountService(AuthorizeUnitOfWork authorizeUnitOfWork, ICryptography cryptography)
        {
            AuthorizeUnitOfWork = authorizeUnitOfWork;
            Cryptography = cryptography;
        }

        public async Task<ICurrentUser> IsAccoutValid(string login, string password)
        {
            var user = await AuthorizeUnitOfWork.Users.Items.SingleAsync(e => e.Login == login);

            if (user == null)
            {
                throw new UnauthorizedAccessException($"User {login} is invalid");
            }

            if (string.IsNullOrEmpty(user.PasswordHash) && password == DefaultPassword)
            {
                var passwordSalt = Cryptography.GenerateSalt();
                var passwordHash = Cryptography.HashPassword(DefaultPassword, passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await AuthorizeUnitOfWork.CommitAsync();
            }
            else
            {
                var hashedPassword = Cryptography.HashPassword(password, user.PasswordSalt);

                if (hashedPassword != user.PasswordHash)
                {
                    throw new UnauthorizedAccessException($"Invalid password");
                }
            }

            return user as ICurrentUser;
        }

        public async Task<ICurrentUser> Handle(ILoginModel request, CancellationToken cancellationToken)
        {
            return await IsAccoutValid(request.Login, request.Password);
        }
    }
}