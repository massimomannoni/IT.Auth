using Microsoft.AspNetCore.Mvc;
using IT.Users.Models;
using IT.Users.BLL;
using System.Threading.Tasks;

namespace IT.Users.Controllers
{
    [Route("api/[controller]")]
    public class AuthRequestController : Controller
    {
        // GET api/values
        [HttpGet]
        public void Get()
        {
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<AuthRequest> PostAsync([FromBody]AuthRequest authRequest)
        {
            if (authRequest != null)
            {
                authRequest = await Task.FromResult(Authentication.GetValidation(authRequest).Result);
            }

            return authRequest;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
