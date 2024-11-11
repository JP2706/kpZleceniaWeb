
using kpZleceniaWeb.Client.Models;
using kpZleceniaWeb.Shared.User.Command;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.User
{
    public partial class AddEditUser : KpBaseForm, IDisposable
    {
        private AddEditUserCommand _command = new AddEditUserCommand();
        private bool _czyPasswordChanege;

        [Parameter]
        public Guid UserId { get; set; }
        public void Dispose()
        {
            KeyCodeService.UnregisterListener(OnKeyDownAsync);
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            KeyCodeService.RegisterListener(OnKeyDownAsync);
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;
            _currentUser = user;
            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();

            await PrepUser();
            _isLoading = false;
        }

        private async Task SaveUser()
        {
           var response =  await UserHttpRepository.AddEditUser(_command);

            if (response.Blad <= -100)
            {
                await DialogService.ShowErrorAsync(response.Info, "Błąd podczas edycji użytkownika", "OK");
                return;
            }

            NavigationManager.NavigateTo("settings");
            ToastService.ShowSuccess("Edycja użytkownika zakończona pomyślnie!");
        }

        private async Task PrepUser()
        {
            if(!(UserId == Guid.Empty))
            {
                var user = await UserHttpRepository.GetUser(UserId.ToString());
                if(user.Count == 1)
                {
                    _command.Id = user.FirstOrDefault().Id;
                    _command.Email = user.FirstOrDefault().Email;
                    _command.FirstName = user.FirstOrDefault().FirstName;
                    _command.LastName = user.FirstOrDefault().LastName;
                    _command.Roles = user.FirstOrDefault().Roles;
                    _command.Password = "SmykPrzezGore;)";
                    _command.ConfirmPassword = "SmykPrzezGore;)";
                }
                
            }
            

        }

        private void RoleValueChange(string role)
        {
            var roleValue = false;
            _command.Roles.TryGetValue(role, out roleValue);
            _command.Roles[role] = !roleValue;
        }

        public async Task OnKeyDownAsync(FluentKeyCodeEventArgs args)
        {
            if (UserId != Guid.Empty && CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser) &&
                                args.CtrlKey && args.AltKey && args.Key == KeyCode.KeyI)
            {
                _czyPasswordChanege = true;
                StateHasChanged();
            }
        }

        private bool RoleAccess(string role)
        {
            if (role == CurrentUserRolesProvider.GlobalAdminstrator)
            {
                if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser))
                    return false;
                else if (CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                    return true;
                else
                    return true;
            }
            else 
            {
                if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser))
                    return false;
                else if (CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                    return false;
                else
                    return true;
            }
           
        }

    }
}
