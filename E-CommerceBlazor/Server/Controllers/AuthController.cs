
using Microsoft.AspNetCore.Mvc;
using E_CommerceBlazor.Shared.Dto;
using E_CommerceBlazor.Server.Service.Abstract;
using E_CommerceBlazor.Shared.Dto;
using System.Security.Claims;

namespace E_CommerceBlazor.Server.Controllerss
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly HttpContextAccessor _http;

        public AuthController(IAuthService authService)
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
