using MediatR;
using Structure.Areas.Account.Models;

namespace WebApi.Areas.Account.Models
{
    public class LoginModel : ILoginModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
