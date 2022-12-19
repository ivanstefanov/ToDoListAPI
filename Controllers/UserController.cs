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

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public ActionResult<string> AdminOnly()
        {
            return Ok("You are admin");
        }

        [HttpGet]
        [Route("customer")]
        [Authorize(Roles = "customer")]
        public ActionResult<string> CustomersOnly()
        {
            return Ok("You are customer");
        }

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
