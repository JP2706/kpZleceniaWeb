using System.Reflection;

namespace kpZleceniaWeb.Client.Models
{
    public static class GlobalStaticParameters
    {
        public static string AuthTokenName { get; } = "kpZleceniaAuthToken";
        public static string RefreshTokenName { get; } = "kpZleceniaRefreshToken";

        public static Version GetVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            return version;
        }
    }
}
