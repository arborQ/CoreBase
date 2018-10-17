using Microsoft.AspNetCore.Mvc;
using Structure.Business.Account.Models;
using Structure.Business.Account.Services;
using System.Linq;

namespace WebApi.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [Area("Account")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersCoreService UsersCoreService;

        public UsersController(IUsersCoreService usersCoreService)
        {
            UsersCoreService = usersCoreService;
        }

        [HttpGet]
        public IUser[] Values()
        {
            var users = UsersCoreService.GetElements().ToArray();

            return users;
        }
    }
}
