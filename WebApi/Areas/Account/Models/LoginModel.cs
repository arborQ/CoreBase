using MediatR;
using Structure.Areas.Account.Models;
using Structure.Models;

namespace WebApi.Areas.Account.Models
{
    public class LoginModel : ILoginModel, IRequest<ICurrentUser>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
