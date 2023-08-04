//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;


namespace eSignAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public ActionResult<List<User>> GetUsers()
        {
            try
            {
                return userService.GetUsers();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> Get(string id)
        {
            try
            {
                var user = userService.GetUserById(id);

                if (user == null)
                    return NotFound($"There is no user with this id: {id}");

                return user;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [Authorize]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                userService.CreateUser(user);

                return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
            }
            catch (Exception)
            {
                return NotFound();
            }
            

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<User> Put(string id, [FromBody] User user)
        {
            try
            {
                var existingUser = userService.GetUserById(id);

                if (existingUser == null)
                    return NotFound($"There is no user with this id: {id}");

                userService.UpdateUser(id, user);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<User> Delete(string id)
        {
            try
            {
                var user = userService.GetUserById(id);

                if (user == null)
                    return NotFound($"There is no user with this id: {id}");

                userService.DeleteUser(id);
                return Ok($"User deleted with this id: {id}");
            }
            catch (Exception)
            {
                return NotFound();
            }

        }


    }
}
