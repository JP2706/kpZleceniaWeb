using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Client.Models;
using kpZleceniaWeb.Shared.Firma.Command;
using kpZleceniaWeb.Shared.User.Dto;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages
{
    public partial class Settings : KpBaseForm, IDisposable
    {
        private AddEditFirmaCommand _firmaCommand = new();
        private List<GetUserDto> _users;
        private string _firmaAdres;
        public DesignThemeModes Mode { get; set; }
        public OfficeColor? OfficeColor { get; set; }
        private string USERID;

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

            _currentUser = user;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();
            USERID = await CurrentUserService.GetUserId();
            await PrepUsers();
            if(!CzyBrakFirma)
                await PrepFirma();
            _isLoading = false;
        }

        private async Task PrepUsers()
        {
            var users = await UserHttpRepository.GetUser();
            _users = users;
        }

        private void EditUser(string id)
        {
            NavigationManager.NavigateTo($"user/{id}");
        }

        private async Task DeleteUser(string id)
        {
            await UserHttpRepository.DeleteUser(new Shared.User.Command.DeleteUserCommand { UserId = id });
            await PrepUsers();
        }

        private bool CzyCanEdit(string id)
        {
            if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser))
                return false;
            else
            {
                if (id == USERID)
                    return false;
                else if (CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                    return false;
                else
                    return true;
            }
        }

        private async Task SaveFirma()
        {
           
            var response = await FirmaHttpRepository.AddEditFirma(_firmaCommand);
            if (response.Blad <= -100)
                await DialogService.ShowErrorAsync(response.Info, "Błąd dodawania firmy", "OK");
            else
            {
                ToastService.ShowSuccess("Aktualizacja firmy zakończona pomyślnie!");
                await PrepFirma();
            }
                
        }

        private async Task PrepFirma()
        {
            var firma = await FirmaHttpRepository.GetFirma();
            _firmaCommand.Id = firma.Id;
            _firmaCommand.Nazwa = firma.Nazwa;
            _firmaCommand.Nip = firma.NIP;
            _firmaAdres = firma.Adres;
            _firmaCommand.Telefon = firma.Telefon;
            _firmaCommand.Email = firma.Email;
            _firmaCommand.Ulica = firma.Ulica;
            _firmaCommand.NumerDomu = firma.NumerDomu;
            _firmaCommand.NumerLokalu = firma.NumerLokalu;
            _firmaCommand.Miejscowosc = firma.Miejscowosc;
            _firmaCommand.KodPocztowy = firma.KodPocztowy;
            _firmaCommand.Poczta = firma.Poczta;
        }
    }
}
