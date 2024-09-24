using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RestaurantApi.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtKey = configuration["Jwt:Key"];
            _jwtIssuer = configuration["Jwt:Issuer"];
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                return GenerateJwtToken(user);
            }
            return null;
        }

        public async Task RegisterAsync(string email, string password, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        public async Task<bool> IsUserInRoleAsync(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            return await _userManager.IsInRoleAsync(user, role);
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtIssuer,
                _jwtIssuer,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
