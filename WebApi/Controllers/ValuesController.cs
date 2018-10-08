using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCuting.Structure.Business.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreStart.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValidateAccountService ValidateService;

        public ValuesController(IValidateAccountService validateService) {
            ValidateService = validateService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var isAuthorized = ValidateService.IsAccoutValid("", "");

            return new string[] { "value1", "value2", isAuthorized.ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
