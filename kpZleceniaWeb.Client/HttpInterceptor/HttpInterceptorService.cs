using kpZleceniaWeb.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using Toolbelt.Blazor;

namespace kpZleceniaWeb.Client.HttpInterceptor
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navigationManager;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly NavigationManager _navManager;

        public HttpInterceptorService(
            HttpClientInterceptor interceptor,
            NavigationManager navigationManager,
            RefreshTokenService refreshTokenService,
            NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navigationManager = navigationManager;
            _refreshTokenService = refreshTokenService;
            _navManager = navManager;
        }

        public void RegisterEvent() =>
            _interceptor.AfterSendAsync += HandleResponse;

        public async Task RegisterBeforeSendEvent()
        {
            _interceptor.BeforeSendAsync += InterceptBeforeSendAsync;
            await Task.Delay(100);
        }

        public void DisposeEvent()
        {
            _interceptor.AfterSendAsync -= HandleResponse;
            _interceptor.BeforeSendAsync -= InterceptBeforeSendAsync;
        }

        private async Task InterceptBeforeSendAsync(object sender, HttpClientInterceptorEventArgs e)
        {
            var absolutePath = e.Request.RequestUri.AbsolutePath;

            if (!absolutePath.Contains("token") && !absolutePath.Contains("account"))
            {
                var token = await _refreshTokenService.TryRefreshToken();

                if (!string.IsNullOrEmpty(token))
                {
                    e.Request.Headers.Authorization =
                        new AuthenticationHeaderValue("bearer", token);
                }
            }
        }

        private async Task HandleResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response == null)
            {
                _navigationManager.NavigateTo("error");
                return;
            }

            var message = string.Empty;

            if (!e.Response.IsSuccessStatusCode)
            {
                switch (e.Response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navigationManager.NavigateTo("404");
                        message = "Nie znaleziono zasobu.";
                        break;
                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("logowanie");
                        message = "Dostęp zabroniony";
                        break;
                    //case HttpStatusCode.BadRequest:
                    //    return;
                    default:
                        _navigationManager.NavigateTo("error");
                        message = "Coś poszło nie tak, proszę skontaktuj się z administratorem.";
                        break;
                }

                throw new HttpResponseException(message);
            }
        }
    }
}
