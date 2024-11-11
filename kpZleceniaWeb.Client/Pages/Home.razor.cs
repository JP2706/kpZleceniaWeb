using kpZleceniaWeb.Client.HttpInterceptor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace kpZleceniaWeb.Client.Pages
{
    public partial class Home : KpBaseForm , IDisposable
    {
        private string _helloTekst;

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();

            _helloTekst = GetHelloTekst(user);
            _isLoading = false;
        }

        private string GetHelloTekst(ClaimsPrincipal user)
        {
            return "Witaj " + user.FindFirst("FirstName").Value + " " + user.FindFirst("LastName").Value;
        }
    }
}
