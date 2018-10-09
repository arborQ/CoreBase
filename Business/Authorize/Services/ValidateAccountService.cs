using Authorize.Services;
using CrossCutting.Structure.Business.Authorize;
using System.Linq;

namespace Business.Authorize.Services
{
    internal class ValidateAccountService : IValidateAccountService
    {
        private readonly AuthorizeUnitOfWork AuthorizeUnitOfWork;

        public ValidateAccountService(AuthorizeUnitOfWork authorizeUnitOfWork)
        {
            AuthorizeUnitOfWork = authorizeUnitOfWork;
        }

        public bool IsAccoutValid(string userName, string password)
        {
            return !AuthorizeUnitOfWork.Users.GetRecords().Any(a => a.Id == 1);
        }
    }
}