using Microsoft.AspNetCore.Mvc;
using Structure.Business.Account.Models;
using Structure.Business.Account.Services;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Areas.Account.Models;
using WebApi.Models;

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

        [HttpGet("{id}")]
        public IUser Value(long id)
        {
            var user = UsersCoreService.GetElement(id);

            return user;
        }

        [HttpPost]
        public IUser AddUser([FromBody]UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = UsersCoreService.AddElement(model);

                return newUser;
            }

            throw new System.Exception("Inalid model");
        }

        [HttpDelete]
        public async Task<long[]> Remove([FromBody]MultipleIdsModel model)
        {
            await UsersCoreService.RemoveAsync(model.Ids);

            return model.Ids;
        }
    }
}
