using MediatR;
using Structure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Areas.Account.Models;

namespace WebApi.Services
{
    public class AuthorizeHandler : IRequestHandler<LoginModel, ICurrentUser>
    {
        public Task<ICurrentUser> Handle(LoginModel request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
