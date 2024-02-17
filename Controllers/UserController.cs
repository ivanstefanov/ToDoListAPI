using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PaymentsAPI.Services;

using System.ComponentModel;

namespace PaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authenticate an user with specific role and returns the JWT token for this user. 
        /// After successful response, the returned JWT token should be copied and pasted into the "Authorize" popup of this page in order to be used for the next responses as an authnetication token
        /// </summary>
        /// <param name="role">The role. For the purpose of the demo is good to use "admin" or "customer" for values</param>
        /// <returns>The JWT token for the user</returns>
        [HttpGet]
        public ActionResult<string> Login(string role)
        {
            string username = "ivan";
            string password = "password";

            var token = _userService.GetToken(username, password, role);


            if (token == null)
                return BadRequest(new { message = "User name or password is incorrect" });

            return Ok(token.ToString());
        }

        /// <summary>
        /// Return a positive response only if the provided JWT is for an admin user
        /// </summary>        
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public ActionResult<string> AdminOnly()
        {
            return Ok("You are admin");
        }

        /// <summary>
        /// Return a positive response only if the provided JWT is for an 'customer' user
        /// </summary>
        [HttpGet]
        [Route("customer")]
        [Authorize(Roles = "customer")]
        public ActionResult<string> CustomersOnly()
        {
            return Ok("You are customer");
        }

        /// <summary>
        /// Return a positive response only if the provided JWT is for an 'admin' or 'customer' user
        /// </summary>
        [HttpGet]
        [Route("registered")]
        [Authorize(Roles = "admin,customer")]
        public ActionResult<string> CustomersAndAdminsOnly()
        {
            return Ok("You are admin or customer");
        }
    }

    public enum UserRole
    {
        admin,
        customer
    }
}
