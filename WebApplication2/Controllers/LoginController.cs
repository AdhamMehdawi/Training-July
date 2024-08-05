using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static readonly Dictionary<string, int> _refreshTokens = new();
        private readonly IConfiguration _configuration;
       // private readonly SettingController _settingController;
          public LoginController(IConfiguration configuration)//, SettingController settingController)
        {
            _configuration = configuration;
           // _settingController = settingController;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel model)
        {
            //we must use the dbcontext to check if the stueddnt exist but we didnt make it yet (i did change the private function (_settingController.FindStudentById)  to public then disable the change )
            //  var student = _settingController.FindStudentById(model.Id);
            var student = new Student
            {
                Password = "test",
                Id = 5,
                Name = "test",
                Address = new Address
                {
                    City = "ramallah",
                    AddressDescription = "test",
                    Street = "yafa street"
                },
                IsActive = true,
                Dob = new DateTime(2000, 10, 10),
             
            };
            if (student == null) { return BadRequest(); }
            if (model.Id == student.Id && model.Password == student.Password)
            {
                var token = GenerateJwtToken(model.Id.ToString());
                var refreshToken = GenerateRefreshToken();
                StoreRefreshToken(model.Id, refreshToken);
                return Ok(new { Token = token, RefreshToken = refreshToken });
            }

            return Unauthorized();
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenModel model)
        {
            
            var userId = ValidateRefreshToken(model.RefreshToken);
            if (userId == null)
            {
                return Unauthorized();
            }

            
            var newToken = GenerateJwtToken(userId.ToString());
            return Ok(new { Token = newToken });
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1).AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }
        private void StoreRefreshToken(int userId, string refreshToken)
        {
            InMemoryTokenStore.StoreToken(userId, refreshToken);
        }
            private int? ValidateRefreshToken(string refreshToken)
        {
            return InMemoryTokenStore.ValidateToken(refreshToken);
        }

    }

    public class UserLoginModel
    {
        public int  Id { get; set; }
        public string Password { get; set; }
    }
    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
    }

    public static class InMemoryTokenStore
    {
        private static readonly Dictionary<string, int> _refreshTokens = new();

        public static void StoreToken(int userId, string refreshToken)
        {
            _refreshTokens[refreshToken] = userId;
        }

        public static int? ValidateToken(string refreshToken)
        {
            if (_refreshTokens.TryGetValue(refreshToken, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}
