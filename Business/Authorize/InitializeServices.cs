using System.Collections.Generic;
using CrossCuting.Structure.Business.Authorize;
using CrossCuting.Structure.IoC;

namespace Business.Authorize {
    public static class InitializeServices {
        public static IEnumerable<ContainerRegister> Register () { 
            yield return ContainerRegister.Service<Business.Authorize.Services.ValidateAccountService, IValidateAccountService>();
        }
    }
}