using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Client.Models;
using kpZleceniaWeb.Client.Models.Components.Dialog;
using kpZleceniaWeb.Shared.Common;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Zlecenia
{
    public partial class ZlecenieLista : KpBaseForm, IDisposable
    {
        #region PrivateParams
        private List<GetZlecenieDto> _dtgZlecenieLista;
        private List<GetKlientLastZleceniaDto> _klientLastZleceniaLista;
        private PaginationState _dtgZlecenieListaPagination = new PaginationState { ItemsPerPage = 10};
        private string USERID;
        #endregion

        [Parameter]
        public int KlientId { get; set; }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _formName = "ZlecenieLista";
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;
           _currentUser = user;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();

            USERID = await CurrentUserService.GetUserId();

            await PreparePage();
            _isLoading = false;
        }

        private async Task PreparePage()
        {
            if(NavigationManager.Uri.Contains("zlecenia/lastzlecenialista/"))
            {
                var list = await ZlecenieHttpRepository.GetKlientLastZlecenia(KlientId, 2);
                _klientLastZleceniaLista = list;
            }
            else
            {
                var list = await ZlecenieHttpRepository.GetZlecenie();
                _dtgZlecenieLista = list;
            }
            
        }

        private void EditOnClick(int id)
        {
            NavigationManager.NavigateTo($"zlecenia/edit/{id}");
        }

        private async Task ZmienStatusZlec(GetZlecenieDto zlec)
        {
            var zamSatusModel = new ChangeZlecenieStatusDialogModel();
            zamSatusModel.ItemList = await SystemHttpRepository.pAppCombo(_formName, "CmbZlecenieStatus");
            zamSatusModel.CurrentZlecenieStausId = zlec.ZlecenieStatusId;

            var dialogParams = new DialogParameters
            {

            };

            var dialog = await DialogService.ShowDialogAsync<ChangeZlecenieStatusDialog>(zamSatusModel, dialogParams);

            var dialogResult = await dialog.Result;

            if(!dialogResult.Cancelled)
            {
                var content =  (pAppComboDto)dialogResult.Data;
                await ZlecenieHttpRepository.ChangeZlecenieStatus(new Shared.Zlecenie.Status.Command.ChangeZlecenieStatusCommand
                {
                    ZlecenieId = zlec.Id,
                    ZlecenieStatusId = Convert.ToInt32(content.Property["Id"].ToString())
                });
                await PreparePage();
                ToastService.ShowSuccess("Zmieniono status poprawnie!");
            }
        }

        private bool CzyEdit()
        {
            if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser) 
                || CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                return false;

            return true;
        }

        private async Task DeleteOnClick(int id)
        {
            await ZlecenieHttpRepository.DeleteZlecenie(id);
            await PreparePage();
            
        }

        private bool CzyDelete(GetZlecenieDto zlec)
        {
            if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser)
                || CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                return false;
            else if (zlec.ApplicationUserId == USERID)
                return false;
            else 
                return true;
        }

        private async Task ZmienStatusZlecLast(GetKlientLastZleceniaDto zlec)
        {
            var zamSatusModel = new ChangeZlecenieStatusDialogModel();
            zamSatusModel.ItemList = await SystemHttpRepository.pAppCombo(_formName, "CmbZlecenieStatus");
            zamSatusModel.CurrentZlecenieStausId = zlec.ZlecenieStatusId;

            var dialogParams = new DialogParameters
            {

            };

            var dialog = await DialogService.ShowDialogAsync<ChangeZlecenieStatusDialog>(zamSatusModel, dialogParams);

            var dialogResult = await dialog.Result;

            if (!dialogResult.Cancelled)
            {
                var content = (pAppComboDto)dialogResult.Data;
                await ZlecenieHttpRepository.ChangeZlecenieStatus(new Shared.Zlecenie.Status.Command.ChangeZlecenieStatusCommand
                {
                    ZlecenieId = zlec.Id,
                    ZlecenieStatusId = Convert.ToInt32(content.Property["Id"].ToString())
                });
                await PreparePage();
                ToastService.ShowSuccess("Zmieniono status poprawnie!");
            }
        }

       
        private bool CzyDeleteLast(GetKlientLastZleceniaDto zlec)
        {
            if (CurrentUserRolesProvider.CzyGlobalAdminstrator(_currentUser)
                || CurrentUserRolesProvider.CzyAdminstrator(_currentUser))
                return false;
            else if (zlec.ApplicationUserId == USERID)
                return false;
            else
                return true;
        }

        private string KlientNazwa()
        {
            if(string.IsNullOrEmpty(_klientLastZleceniaLista.First().Imie) && string.IsNullOrEmpty(_klientLastZleceniaLista.First().Nazwisko))
            {
                return _klientLastZleceniaLista.First().Nazwa;
            }
            else
            {
                return _klientLastZleceniaLista.First().Imie + " " + _klientLastZleceniaLista.First().Nazwisko;
            }
        }

    }
}
