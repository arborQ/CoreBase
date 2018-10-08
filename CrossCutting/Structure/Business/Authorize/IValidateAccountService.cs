using System;

namespace CrossCutting.Structure.Business.Authorize {
    public interface IValidateAccountService {
        bool IsAccoutValid (string userName, string password);
    }
}