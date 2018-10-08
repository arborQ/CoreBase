using System.Collections.Generic;
using CrossCutting.Structure.Business.Authorize;
using CrossCutting.Structure.IoC;

namespace Business.Authorize {
    public static class InitializeServices {
        public static IEnumerable<ContainerRegister> Register () { 
            yield return ContainerRegister.Service<Business.Authorize.Services.ValidateAccountService, IValidateAccountService>();
        }
    }
}