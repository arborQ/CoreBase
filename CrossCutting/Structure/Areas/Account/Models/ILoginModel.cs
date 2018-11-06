using MediatR;
using Structure.Models;

namespace Structure.Areas.Account.Models
{
    public interface ILoginModel: IRequest<ICurrentUser>
    {
        string Login { get; }

        string Password { get; }
    }
}
