using MediatR;
using Structure.Business.Account.Models;

namespace WebApi.Areas.Account.Models
{
    public class UserViewModel : IUser, IRequest<IUser>
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
