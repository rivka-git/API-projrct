using Microsoft.AspNetCore.Mvc;
using Model;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        PasswordService _p = new PasswordService();
        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public PassWord Get(PassWord p)
        {
            return _p.getStrengthByPassword(p);
        }

        // POST api/<PasswordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpPost("pass")]
        
        public PassWord Post([FromBody] PassWord p)
        {
            return _p.getStrengthByPassword(p);
        }


        // PUT api/<PasswordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
