using kpZleceniaWeb.Domain.Entities;
using System.Security.Claims;

namespace kpZleceniaWeb.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetToken(ApplicationUser user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
