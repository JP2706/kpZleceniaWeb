using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Firma.Command;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Authorization
{
    public partial class Register
    {
        private bool _savingData = false;
        private RegisterUserCommand _command = new RegisterUserCommand();
        private bool _showErrors;
        private IEnumerable<string> _errors;
        private string test;


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationHttpRepository AuthenticationRepo { get; set; }

		[Inject]
		public IDialogService DialogService { get; set; }

		[Inject]
		public IToastService ToastService { get; set; }

		private async Task Save()
        {
            try
            {
                _savingData = true;
                _showErrors = false;


                var response = await AuthenticationRepo.RegisterUser(_command);
                if (!response.IsSuccess)
                {
                    _errors = new List<string> { response.Errors };
                    _showErrors = true;
                    return;
                }

                NavigationManager.NavigateTo("logowanie");
            }
            finally
            {
                _savingData = false;
            }
        }

    }
}
