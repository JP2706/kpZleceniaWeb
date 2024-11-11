using kpZleceniaWeb.Client.Models;
using kpZleceniaWeb.Client.Services.Interfaces;
using System.Security.Claims;

namespace kpZleceniaWeb.Client.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly CookieStorageService _cookieStorageService;
        public CurrentUserService(CookieStorageService cookieStorageService) 
        {
            _cookieStorageService = cookieStorageService;
        }

        private async Task<IEnumerable<Claim>> GetClaims()
        {
            var token = await _cookieStorageService.GetValueAsync(GlobalStaticParameters.AuthTokenName);

            if(string.IsNullOrEmpty(token))
                return new List<Claim>();

            var claims = JwtParser.ParseClaimsFromJwt(token);

            return claims;
        }

        public async Task<string> GetUserId()
        {
           var claims = await GetClaims();

            var claim =  claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if(claim == null)
                return string.Empty;

            return claim.Value;
        }
    }
}
