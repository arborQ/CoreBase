using System;
using System.Threading.Tasks;

namespace CrossCutting.Structure.Business.Authorize {
    public interface IValidateAccountService {
        Task<bool> IsAccoutValid (string userName, string password);
    }
}