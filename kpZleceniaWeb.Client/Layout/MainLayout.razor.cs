using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using kpZleceniaWeb.Client.HttpInterceptor;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Client.Models;
using Microsoft.FluentUI.AspNetCore.Components;
using kpZleceniaWeb.Shared.Firma.Command;
using kpZleceniaWeb.Client.Components.Dialog;

namespace kpZleceniaWeb.Client.Layout
{
    public partial class MainLayout
    {
        private string _lastUrlCascade;
        private bool _czyBrakFirmy;
        private bool _czyGlobalAdmin;
        private string _nazwaFirmy = string.Empty;

        [CascadingParameter]
        protected Task<AuthenticationState> AuthState { get; set; }

        [Inject]
        protected HttpInterceptorService Interceptor { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IFirmaHttpRepository FirmaHttpRepository { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            PageChangeEventHandler();
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();

            _czyGlobalAdmin = CurrentUserRolesProvider.CzyGlobalAdminstrator(user);

            _czyBrakFirmy = await FirmaHttpRepository.CzyFirma();
            var firma = await FirmaHttpRepository.GetFirma();
            if(firma.Id != 0)
            {
                _nazwaFirmy = firma.Nazwa;
            }
            Interceptor.DisposeEvent();

        }

        private void PageChangeEventHandler()
        {
            var bs = NavigationManager.BaseUri;
            NavigationManager.LocationChanged += (obj, lcea) =>
            {
                _lastUrlCascade = lcea.Location.Substring(bs.Length);
            };
        }

        private async Task AddFirma()
        {
            var dialogParams = new DialogParameters
            {

            };

            var command = new AddEditFirmaCommand();

            var dialog = await DialogService.ShowDialogAsync<AddFirmaDialog>(command, dialogParams);

            var dialogResut = await dialog.Result;

            if (dialogResut.Cancelled)
                return;

            var data = (AddEditFirmaCommand)dialogResut.Data;
            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();

            var response = await FirmaHttpRepository.AddEditFirma(data);

            Interceptor.DisposeEvent();
            if (response.Blad < -100)
                await DialogService.ShowErrorAsync(response.Info, "Błąd dodawania firmy.", "OK");
            else
                NavigationManager.NavigateTo("", true);
            

        }

        
    }
}
