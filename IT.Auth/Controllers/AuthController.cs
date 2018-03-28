using Microsoft.AspNetCore.Mvc;
using IT.Users.Models;
using IT.Users.BLL;

namespace IT.Users.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // GET api/values
        [HttpGet]
        public void Get()
        {
            
        }

        // MM : return Auth without information about password & hash but modifing isValid 
       

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Models.Auth auth)
        {
            return Authentication.GetValidation(ref auth);
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
