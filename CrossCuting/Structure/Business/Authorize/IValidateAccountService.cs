using System;

namespace CrossCuting.Structure.Business.Authorize {
    public interface IValidateAccountService {
        bool IsAccoutValid (string userName, string password);
    }
}