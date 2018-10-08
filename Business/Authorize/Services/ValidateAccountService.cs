using CrossCuting.Structure.Business.Authorize;

namespace Business.Authorize.Services
{
    internal class ValidateAccountService : IValidateAccountService
    {
        public bool IsAccoutValid(string userName, string password)
        {
            return false;
        }
    }
}