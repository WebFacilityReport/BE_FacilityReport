using Domain.Entity;
using Infrastructure.Model.Security;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Common.SecurityService.Imp
{
    public class TokensHandler : ITokensHandler
    {
        private readonly JWToken _JWToken;
        private readonly IMemoryCache _memoryCache;

        public TokensHandler(JWToken jWToken, IMemoryCache memoryCache)
        {
            _JWToken = jWToken;
            _memoryCache = memoryCache;
        }

        public AccessToken CreateAccessToken(Account account)
        {
            var refreshToken = GenerateRefreshToken();
            var cacheKey = GetCacheKey(refreshToken.Token, account.Username);

            _memoryCache.Set(cacheKey, refreshToken, TimeSpan.FromDays(_JWToken.RefreshTokenExpiration));

            return BuildAccessToken(account, refreshToken);
        }

        public void RevokeRefreshToken(string token, string userName)
        {
            var cacheKey = GetCacheKey(token, userName);
            _memoryCache.Remove(cacheKey);
        }

        public RefreshToken TakeRefreshToken(string token, string userName)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(userName))
            {
                throw new Exception("Token or UserName Null");
            }

            var cacheKey = GetCacheKey(token, userName);
            var refreshToken = _memoryCache.Get<RefreshToken>(cacheKey);

            if (refreshToken == null)
            {
                throw new Exception("Data Refresh Token null");
            }
            _memoryCache.Remove(cacheKey);
            return refreshToken;
        }

        private RefreshToken GenerateRefreshToken()
        {

            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                Expiration = DateTime.UtcNow.AddDays(_JWToken.RefreshTokenExpiration)
            };

            return refreshToken;
        }

        private AccessToken BuildAccessToken(Account account, RefreshToken refreshToken)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddDays(_JWToken.AccessTokenExpiration);

            var secretKeyBytes = Encoding.UTF8.GetBytes(_JWToken.JWTSecretKey);

            var securityToken = new JwtSecurityToken
            (
                issuer: _JWToken.Issuer,
                audience: _JWToken.Audience,
                claims: GetClaims(account),
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
            );

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(securityToken);


            return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);
        }

        private IEnumerable<Claim> GetClaims(Account account)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, account.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, account.AccountId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, account.Username),
            new Claim(JwtRegisteredClaimNames.Email, account.Email)
        };

            return claims;
        }

        private string GetCacheKey(string token, string userName)
        {
            return $"RefreshToken:{userName}:{token}";
        }

        public async Task<string> ClaimsFromToken(string token)
        {
            var claimsPrincipal = GetClaimsFromToken(token);
            if (claimsPrincipal == null)
            {
                throw new Exception("ClaimsFromToken NULL");
            }

            var claims = GetClaimsFromToken(token);
            var email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
            return email;
        }

        private static IEnumerable<Claim> GetClaimsFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.Claims;
        }
    }
}

