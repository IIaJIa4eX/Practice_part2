using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SafeProject.Models.Authorization;
using SafeProject.Services.Interfaces;
using System.Net.Http.Headers;

namespace SafeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
