using Microsoft.JSInterop;

namespace kpZleceniaWeb.Client.Services
{
    public class CookieStorageService
    {
        private IJSRuntime _jsRuntime;
        private readonly IConfiguration _configuration;
        private string _domain;

        public CookieStorageService(
            IJSRuntime jsRuntime,
            IConfiguration configuration)
        {
            _jsRuntime = jsRuntime;
            _configuration = configuration;
            _domain = _configuration["Domain"];
        }

        public async Task<string> GetValueAsync(string key)
        {
            var result = await _jsRuntime.InvokeAsync<string>("cookieFunctions.get", key);

            return result;
        }

        public async Task SetValueAsync(string key, string value)
        {
            await _jsRuntime.InvokeVoidAsync("cookieFunctions.set", key, value, _domain);
        }

        public async Task RemoveValueAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("cookieFunctions.remove", key, _domain);
        }
    }
}
