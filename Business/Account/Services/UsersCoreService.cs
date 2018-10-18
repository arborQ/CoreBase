using Account.Dtos;
using Data.Entity.Models.Account;
using Structure.Business.Account.Models;
using Structure.Business.Account.Services;
using Structure.Repository;
using Structure.Services;
using Structure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Account.Services
{
    internal class UsersCoreService : BaseCoreService<IUser, User>, IUsersCoreService
    {
        public UsersCoreService(AccountUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        protected override IUser MapFromEntity(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Email = entity.Email,
                FullName = entity.FullName,
                Login = entity.Login,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        protected override Expression<Func<User, bool>> FilterExpression()
        {
            return a => a.IsActive;
        }
    }
}
