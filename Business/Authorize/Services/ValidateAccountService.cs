using Authorize.Services;
using CrossCutting.Structure.Business.Authorize;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Authorize.Services
{
    internal class ValidateAccountService : IValidateAccountService
    {
        private readonly AuthorizeUnitOfWork AuthorizeUnitOfWork;

        public ValidateAccountService(AuthorizeUnitOfWork authorizeUnitOfWork)
        {
            AuthorizeUnitOfWork = authorizeUnitOfWork;
        }

        public async Task<bool> IsAccoutValid(string userName, string password)
        {
            var user = await AuthorizeUnitOfWork.Users.GetRecordsAsAsync(e => e.Id == 1);

            return user != null;
        }
    }
}