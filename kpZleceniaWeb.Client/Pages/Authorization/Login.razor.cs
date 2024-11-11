using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Authentication.Commands;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Authorization
{
    public partial class Login
    {
        private bool _savingData = false;
        private LoginUserCommand _command = new LoginUserCommand();
        public bool _showLoginError;
        public string _error;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationHttpRepository AuthenticationRepo { get; set; }

        [Inject]
        private IKeyCodeService KeyCodeService { get; set; }

        private async Task Save()
        {
            try
            {
                _savingData = true;
                _showLoginError = false;
                StateHasChanged();

                var response = await AuthenticationRepo.Login(_command);

                if (!response.IsAuthSuccessful)
                {
                    _error = response.ErrorMessage;
                    _showLoginError = true;
                    return;
                }

                NavigationManager.NavigateTo("");
            }
            finally
            {
                _savingData = false;
            }
        }

        
    }
}
