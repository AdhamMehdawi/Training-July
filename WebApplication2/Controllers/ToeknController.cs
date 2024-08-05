using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.DTOs;
using WebApplication2.Services.TokenService;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateToken([FromBody] LoginRequestDto loginRequest)
        {
            var jwtToken = _tokenService.GenerateJwtToken(loginRequest.UserName, loginRequest.UserId, loginRequest.Role);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _tokenService.SaveRefreshToken(loginRequest.UserId, refreshToken);

            return Ok(new TokenResponseDto { JwtToken = jwtToken, RefreshToken = refreshToken });
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequest)
        {
            try
            {
                var tokens = _tokenService.RefreshTokens(refreshTokenRequest.UserId, refreshTokenRequest.RefreshToken, "userName", "role");
                return Ok(new TokenResponseDto { JwtToken = tokens.Item1, RefreshToken = tokens.Item2 });
            }
            catch (SecurityTokenException)
            {
                return Unauthorized("Invalid refresh token");
            }
        }
    }
}
