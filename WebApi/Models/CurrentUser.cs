using Structure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WebApi.Models
{
    public class CurrentUser : ICurrentUser
    {
        public const string FullNameClaimName = "FullName";
        public const string LoginClaimName = "Login";
        public const string IdClaimName = "Id";

        private CurrentUser(long id)
        {

        }

        public long Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public string[] Roles { get; set; }

        public static ICurrentUser CreateFromClaims(IEnumerable<Claim> claims)
        {
            var fullName = claims.Single(a => a.Type == FullNameClaimName).Value;
            var login = claims.Single(a => a.Type == LoginClaimName).Value;

            return new CurrentUser(1) {
                FullName = fullName, Login = login
            };
        }
    }
}
