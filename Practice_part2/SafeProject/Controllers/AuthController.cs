using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SafeProject.Models;
using SafeProject.Models.Authorization;
using SafeProject.Services.Interfaces;
using System.Net.Http.Headers;

namespace SafeProject.Controllers
{
    //for_review
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountRepsitoryService _accountRepsitoryService;

        public AuthController(IAuthService authService, IAccountRepsitoryService accountRepsitoryService)
        {
            _authService = authService;
            _accountRepsitoryService = accountRepsitoryService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest authRequest)
        {
            AuthResponse authResponse = _authService.Login(authRequest);
            if(authResponse.AuthStatus == AuthStatus.Sucess)
            {
                Response.Headers.Add("X-Session-Token", authResponse.SessionInfo.SessionToken);
            }

            return Ok(authResponse);
        }

        [HttpPost("create-account")]
        public IActionResult Create([FromBody] CreateAccountRequest createReq)
        {
            
            return Ok(_accountRepsitoryService.CreateAccount(createReq));
        }

        [HttpGet("getinfo")]
        public IActionResult GetSessionInfo()
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            if(AuthenticationHeaderValue.TryParse(authorization, out var header))
            {
                var scheme = header.Scheme;
                var sessonToken = header.Parameter;
                if (string.IsNullOrEmpty(sessonToken))
                {
                    return Unauthorized();
                }

                SessionInfo sessionInfo = _authService.GetSessionInfo(sessonToken);
                if(sessionInfo == null)
                {
                    return Unauthorized();
                }

                return Ok(sessionInfo);

            };

            return Unauthorized();

        }
    }
}
