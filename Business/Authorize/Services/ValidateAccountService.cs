using Authorize.Services;
using CrossCutting.Structure.Business.Authorize;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Structure.Models;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Business.Authorize.Services
{
    internal class ValidateAccountService : IValidateAccountService
    {
        private readonly AuthorizeUnitOfWork AuthorizeUnitOfWork;
        private const string DefaultPassword = "Haslo123!";

        public ValidateAccountService(AuthorizeUnitOfWork authorizeUnitOfWork)
        {
            AuthorizeUnitOfWork = authorizeUnitOfWork;
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
                var passwordSalt = GenerateSalt();
                var passwordHash = HashPassword(DefaultPassword, passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await AuthorizeUnitOfWork.CommitAsync();
            }
            else
            {
                var hashedPassword = HashPassword(password, user.PasswordSalt);

                if (hashedPassword != user.PasswordHash)
                {
                    throw new UnauthorizedAccessException($"Invalid password");
                }
            }

            return user as ICurrentUser;
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        private string HashPassword(string password, byte[] salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );

            return hashed;
        }
    }
}