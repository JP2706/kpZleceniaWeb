using System.Reflection;

namespace kpZleceniaWeb.Api
{
    public static class GlobalStaticParameters
    {
        public static Version GetVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            return version;
        }
    }
}
