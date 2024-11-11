using kpZleceniaWeb.Client.HttpInterceptor;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common;
using kpZleceniaWeb.Shared.Klient.Dto;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Command;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace kpZleceniaWeb.Client.Pages.Zlecenia
{
    public partial class ZlecenieAddEdit : KpBaseForm, IDisposable
    {
        #region PrivatePrams
        private AddEditZlecenieCommand _command = new();
        #endregion 

        [Parameter]
        public int ZlecenieId { get; set; }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _formName = "ZlecenieAddEdit";
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();
            await BrakFirma();
            await PreparePage();
            if(ZlecenieId == 0)
            {
                _command.ApplicationUserId = await CurrentUserService.GetUserId();
            }
            else
            {
                await PrepEditPage();
            }
           
            _isLoading = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            if(ZlecenieId == 0)
            {
                _command = new();
                _command.ApplicationUserId = await CurrentUserService.GetUserId();
                if (_cmbTypUrzadzenieList.Count > 0)
                    _command.TypUrzadzeniaId = Convert.ToInt32(_cmbTypUrzadzenieSelectedItem.Property["Id"].ToString());
                if (_cmbKlientList.Count > 0)
                    _command.KlientId = Convert.ToInt32(_cmbKlientSelectedItem.Property["Id"].ToString());
                if (_cmbZlecenieStatusLista.Count > 0)
                    _command.ZlecenieStatusId = Convert.ToInt32(_cmbZlecenieStatusSelectedItem.Property["Id"].ToString());
            }
        }

        private async Task BrakFirma()
        {
            if(CzyBrakFirma)
            {
                _isLoading = false;
                StateHasChanged();
                var dialog = await DialogService.ShowInfoAsync("Brak firmy, proszę dodać firmę!", "Uwaga!!!", "OK");
                var errorResult = await dialog.Result;
                if (!errorResult.Cancelled || errorResult.Cancelled)
                    NavigationManager.NavigateTo("");
            }
        }

        private async Task PreparePage()
        {
           await PrepareTypUrzadzenie();
           await PrepreKlient();
           await PrepZlecenieStatus();
        }

        private void ReturnLastPageOnClick()
        {
            NavigationManager.NavigateTo(LastUrlCascade);
        }

        private async Task PrepEditPage()
        {
            var lista = await ZlecenieHttpRepository.GetZlecenie(ZlecenieId);
            if (lista.Count > 0)
            {
                var zlecenie = lista[0];

                _command = new AddEditZlecenieCommand
                {
                    Id = ZlecenieId,
                    Symbol = zlecenie.Symbol,
                    Urzadzenie = zlecenie.Urzadzenie,
                    NumerSer = zlecenie.NumerSer,
                    OpisUsterki = zlecenie.OpisUsterki,
                    Opis = zlecenie.Opis,
                    DataPrzyjecie = zlecenie.DataPrzyjecie,
                    DataRozpoczRealizacji = zlecenie.DataRozpoczRealizacji,
                    DataZakRealizacji = zlecenie.DataZakRealizacji,
                    DataWydania = zlecenie.DataWydania,
                    ZlecenieStatusId = zlecenie.ZlecenieStatusId,
                    KlientId = zlecenie.KlientId,
                    TypUrzadzeniaId = zlecenie.TypUrzadzeniaId,
                    ApplicationUserId = zlecenie.ApplicationUserId,
                };

                _cmbKlientSelectedItem = _cmbKlientList.FirstOrDefault(x => x.Property["Id"].ToString() == _command.KlientId.ToString());
                _cmbTypUrzadzenieSelectedItem = _cmbTypUrzadzenieList.FirstOrDefault(x => x.Property["Id"].ToString() == _command.TypUrzadzeniaId.ToString());
                _cmbZlecenieStatusSelectedItem = _cmbZlecenieStatusLista.FirstOrDefault(x => x.Property["Id"].ToString() == _command.ZlecenieStatusId.ToString());
            }
                
        }

        private async Task SaveZlecenie()
        {
            var response = await ZlecenieHttpRepository.AddEditZlecenie(_command);

            if (response.Blad <= -100)
            {
                await DialogService.ShowErrorAsync(response.Info, "Błąd podczas dodawania zlecenia", "OK");
                return;
            }

            NavigationManager.NavigateTo("zlecenia/zlecenialista");
            ToastService.ShowSuccess("Dodano zlecenie pomyślnie!");
                
        }

        #region CmbTypUrzadzenie

        private List<pAppComboDto> _cmbTypUrzadzenieList = new();
        private pAppComboDto _cmbTypUrzadzenieSelectedItem;

        private async Task PrepareTypUrzadzenie()
        {
            _cmbTypUrzadzenieList = await SystemHttpRepository.pAppCombo(_formName, "CmbTypUrzadzenie");
            if(_cmbTypUrzadzenieList.Count > 0)
            {
                _cmbTypUrzadzenieSelectedItem = _cmbTypUrzadzenieList.First();
                _command.TypUrzadzeniaId = Convert.ToInt32(_cmbTypUrzadzenieSelectedItem.Property["Id"].ToString());
            }
        }

        private void CmbTypUrzadzenieAfterSelectedItem()
        {
            if(_cmbTypUrzadzenieSelectedItem != null)
            {
                _command.TypUrzadzeniaId = Convert.ToInt32(_cmbTypUrzadzenieSelectedItem.Property["Id"].ToString());
            }
        }

        #endregion

        #region CmbKlient
        private List<pAppComboDto> _cmbKlientList = new();
        private pAppComboDto _cmbKlientSelectedItem;

        private async Task PrepreKlient()
        {
            _cmbKlientList = await SystemHttpRepository.pAppCombo(_formName, "CmbKlient");
            if (_cmbKlientList.Count > 0)
            {
                _cmbKlientSelectedItem = _cmbKlientList.First();
                _command.KlientId = Convert.ToInt32(_cmbKlientSelectedItem.Property["Id"].ToString());
            }
        }

        private void CmbKlientAfterSelectedItem()
        {
            if(_cmbKlientSelectedItem != null)
            {
                _command.KlientId = Convert.ToInt32(_cmbKlientSelectedItem.Property["Id"].ToString());
            }
        }
        #endregion

        #region CmbZlecenieStatus
        private List<pAppComboDto> _cmbZlecenieStatusLista = new();
        private pAppComboDto _cmbZlecenieStatusSelectedItem;

        private async Task PrepZlecenieStatus()
        {
            _cmbZlecenieStatusLista = await SystemHttpRepository.pAppCombo(_formName, "CmbZlecenieStatus");
            if (_cmbZlecenieStatusLista.Count > 0)
            {
                _cmbZlecenieStatusSelectedItem = _cmbZlecenieStatusLista.First();
                _command.ZlecenieStatusId = Convert.ToInt32(_cmbZlecenieStatusSelectedItem.Property["Id"].ToString());
            }
        }

        private void CmbZlecenieStatusAfterSelectedItem()
        {
            if(_cmbZlecenieStatusSelectedItem != null)
            {
                _command.ZlecenieStatusId = Convert.ToInt32(_cmbZlecenieStatusSelectedItem.Property["Id"].ToString());
            }
        }
        #endregion

    }
}
