using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Shared.Klient.Command;
using kpZleceniaWeb.Shared.Klient.Dto;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Klient
{
    public partial class KlientList : KpBaseForm, IDisposable
    {
        //private List<GetKlientDto> _klientList;
        private List<KlientRecord> _klientList = new();
        private PaginationState _klientListaPagination = new PaginationState { ItemsPerPage = 10 };

        record KlientRecord(GetKlientDto klientDto, bool czMaZlecenia)
        {
            bool CzyMaZlecenia = czMaZlecenia;
        }

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _formName = "KlientLista";
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;
            _currentUser = user;
            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();
            await PrepPage();
            _isLoading = false;
        }

        private async Task PrepPage()
        {
            var list = await KlientHttpRepository.GetKlient();
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    var czyMaZlec = await ZlecenieHttpRepository.GetCzyKlientMaZlecenia(item.Id);
                    var klientRec = new KlientRecord(item, czyMaZlec.CzyMa);
                    _klientList.Add(klientRec);
                }
            }
        }

        private async Task AddEditKlient(int id = 0)
        {
            var dialogParams = new DialogParameters
            {

            };

            var command = new AddEditKlientCommand();

            if (id != 0)
            {
                var klient = _klientList.FirstOrDefault(x => x.klientDto.Id == id);

                command.Id = id;   
                command.Imie = klient.klientDto.Imie;
                command.Nazwisko = klient.klientDto.Nazwisko;
                command.Tel = klient.klientDto.Tel;
                command.Nazwa = klient.klientDto.Nazwa;
            }
            

            var dialog = await DialogService.ShowDialogAsync<AddEditKlientDialog>(command, dialogParams);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                var resultFromDialog = (AddEditKlientCommand)result.Data;
                await KlientHttpRepository.AddEditKlient(resultFromDialog);
                await PrepPage();
                ToastService.ShowSuccess("Dodano klienta pomyślnie");
            }
        }

        private async Task DeleteKlient(int id)
        {
            await KlientHttpRepository.DeleteKlient(id);
            await PrepPage();
        }

        private async Task<bool> CzyKlientMaZlec(int klientId)
        {
            var result = await ZlecenieHttpRepository.GetCzyKlientMaZlecenia(klientId);

            return result.CzyMa;
        }

        private void GetKlientLastZlec(int klientId)
        {
            NavigationManager.NavigateTo($"zlecenia/lastzlecenialista/{klientId}");
        }

    }
}
