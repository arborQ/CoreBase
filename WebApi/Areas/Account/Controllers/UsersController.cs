using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Account.Controllers
{
    [Route("api/[area]/[controller]")]
    [Area("Account")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public string[] Values()
        {
            return new string[] {
                "1",
                "2",
                "3",
                "test",
            };
        }
    }
}
