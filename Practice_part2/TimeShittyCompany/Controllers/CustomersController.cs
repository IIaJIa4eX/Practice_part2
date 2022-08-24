using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Authorization;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Controllers
{
    //for review
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IUsersService _userService;
        private IAuthService _authService;

        public CustomersController(IUsersService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }


        [HttpGet("search")]
        //https://localhost:5001/api/customers/search/?searchterm=Alexander - для теста
        public IActionResult GetByName([FromQuery] string searchterm)
        {
            var data = _userService.GetByName(searchterm);
            if(data == null || data.Count == 0)
            {
                return BadRequest("Никого нет с таким именем");
            }

            return Ok(data);
        }


        [HttpGet()]
        //https://localhost:5001/api/customers/?skip=0&take=70
        public IActionResult GetPage([FromQuery] int skip, int take)
        {
            var data = _userService.GetPage(skip, take);

            if (data == null || data.Count == 0)
            {
                return BadRequest("Нельзя сделать такой запрос");
            }

            return Ok(data);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {         
           return Ok(_userService.GetById(id));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] User person)
        {
            return Ok(_userService.AddNewUser(person));
        }

        [HttpPost("registerValidation")]
        public IActionResult PostWithValidation([FromBody] User person)
        {
            return Ok(_userService.AddNewUserValidation(person));
        }


        [HttpPut("update")]
        public IActionResult Put([FromBody] User person)
        {
            return Ok(_userService.UpdateUserById(person));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.DeleteUserById(id));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string email, string password)
        {
            JwtTokenResponse token = _authService.Authenticate_TokenResp(email, password);
            if (token is null)
            {
                return BadRequest(new
                {
                    message = "Username or password is incorrect"
                });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);

        }

        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = _authService.RefreshToken(oldRefreshToken);
            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(120)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
