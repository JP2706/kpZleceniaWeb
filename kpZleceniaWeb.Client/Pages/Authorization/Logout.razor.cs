using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using Microsoft.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Authorization
{
    public partial class Logout
    {

        [Inject]
        public IAuthenticationHttpRepository AuthenticationHttpRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationHttpRepository.Logout();
            NavigationManager.NavigateTo("logowanie");
        }
    }
}
