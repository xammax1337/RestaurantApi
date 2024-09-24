using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Services.IServices;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _authService.LoginAsync(email, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string role)
        {
            await _authService.RegisterAsync(email, password, role);
            return Ok();
        }
    }
}
