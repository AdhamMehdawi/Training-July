namespace WebApplication2.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userName, string userId, string role);
        string GenerateRefreshToken();
        bool ValidateRefreshToken(string userId, string refreshToken);
        void SaveRefreshToken(string userId, string refreshToken);
        (string JwtToken, string RefreshToken) RefreshTokens(string userId, string refreshToken, string userName, string role);
    }
}
