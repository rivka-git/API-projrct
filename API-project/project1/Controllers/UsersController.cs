using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Text.Json;
using UserModel;
using Services;
using static project1.Controllers.Userscontroller;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Userscontroller : ControllerBase
    {
       UserServices _s = new UserServices();

        //GET: api/<users>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _s.GetUsers();
        }
 

        // GET api/<users>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
           User user= _s.GetUserById(id);
            if (user!=null)
            {
                return Ok(user);
            }       
          return NoContent();
        }
        // POST api/<users>

        [HttpPost]
        public CreatedAtActionResult Post([FromBody] User user)
        {

          User res= _s.addNewUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, res);
        }


        //POST
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] User user)
        {
           User res = _s.Login(user);
            if(res!=null)
            {
                return Ok(res);
            }
                 
            return NotFound();
        }



        // PUT api/<users>/5
        [HttpPut("{id}")]
        public CreatedAtActionResult Put(int id, [FromBody] User value)
        {
           User res=_s.update(id, value);
            return CreatedAtAction(nameof(Get), new { id = value.UserId }, res);
        }

        // DELETE api/<users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
