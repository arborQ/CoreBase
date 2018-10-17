using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Account.Controllers
{
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
