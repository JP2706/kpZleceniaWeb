using System.Security.Claims;

namespace kpZleceniaWeb.Client.Models
{
    public static class CurrentUserRolesProvider
    {
        public static string GlobalAdminstrator { get; } = "GlobalAdministrator";
        public static string Adminstrator { get; } = "Administrator";
        public static string Pracownik { get; } = "Pracownik";


        public static bool CzyGlobalAdminstrator(ClaimsPrincipal user)
        {
            return user.Claims.Any(x => x.Value == GlobalAdminstrator);
        }

        public static bool CzyAdminstrator(ClaimsPrincipal user)
        {
            return user.Claims.Any(x => x.Value == Adminstrator);
        }

        public static bool CzyPracownik(ClaimsPrincipal user)
        {
            return user.Claims.Any(x => x.Value == Pracownik);
        }
    }
}
