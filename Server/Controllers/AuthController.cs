
using Microsoft.AspNetCore.Mvc;
using Server.Dto;
using Server.Service.Abstract;
using Sever.Dto;
using System.Security.Claims;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly HttpContextAccessor _http;

        gpublic AuthController(IAuthService authService)
        {
            _authService = authService;
        }   

        [HttpPost("/register")]
        public async Task<ActionResult<DataResponse<string>>> Register(RegisterDto register)
        {
            var response = await _authService.Register(register);
             
            return Ok(response);
        }
        [HttpPost("/login")]
        public async Task<ActionResult<DataResponse<string>>> login(LoginDto login)
        {
            var response = await _authService.Login(login);
            //var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(response);
        }
    }
}
