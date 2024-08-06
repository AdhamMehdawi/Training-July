using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, string> _refreshTokens = new Dictionary<string, string>();

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string userName, string userId, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim("id", userId),
                new Claim("Role", role),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public bool ValidateRefreshToken(string userId, string refreshToken)
        {
            if (_refreshTokens.TryGetValue(userId, out var storedToken) && storedToken == refreshToken)
            {
                return true;
            }
            return false;
        }

        public void SaveRefreshToken(string userId, string refreshToken)
        {
            _refreshTokens[userId] = refreshToken;
        }

        public (string, string) RefreshTokens(string userId, string refreshToken, string userName, string role)
        {
            if (ValidateRefreshToken(userId, refreshToken))
            {
                var newJwtToken = GenerateJwtToken(userName, userId, role);
                var newRefreshToken = GenerateRefreshToken();
                SaveRefreshToken(userId, newRefreshToken);
                return (newJwtToken, newRefreshToken);
            }

            throw new SecurityTokenException("Invalid refresh token");
        }
    }
}
