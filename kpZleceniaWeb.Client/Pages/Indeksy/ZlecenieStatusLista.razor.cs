using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Client.Models.Components.Dialog;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using kpZleceniaWeb.Shared.Zlecenie.Status.Dto;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client.Pages.Indeksy
{
    public partial class ZlecenieStatusLista : KpBaseForm, IDisposable
    {
        #region PrivateParams
        private List<GetZlecenieStatusDto> _dtgZlecenieStatusLista;
        private PaginationState _dtgZlecenieStatusListaPagination = new PaginationState { ItemsPerPage = 10 };
        #endregion

        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _formName = "ZlecenieStatusLista";
            _isLoading = true;
            var authState = await AuthState;

            var user = authState.User;

            if (user == null || !user.Identity.IsAuthenticated)
                return;

            Interceptor.RegisterEvent();
            await Interceptor.RegisterBeforeSendEvent();
            await PrepPage();
            _isLoading = false;
        }

        private async Task PrepPage()
        {
            var lista = await ZlecenieHttpRepository.GetZlecenieStatus();
            _dtgZlecenieStatusLista = lista;
        }

        private async Task AddOnClick()
        {
            var dialogParams = new DialogParameters
            {

            };

            var addEditCommand = new AddEditBaseDialogModel
            {
                NazwaEtykieta = "Nazwa statusu:",
                Title = "Dodaj Status Zamówienia"
            };

            var dialog = await DialogService.ShowDialogAsync<AddEditBaseDialog>(addEditCommand, dialogParams);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                var resultFromDialog = (AddEditBaseDialogModel)result.Data;
                await ZlecenieHttpRepository.AddEditZlecenieStatus(new Shared.Zlecenie.Status.Command.AddEditZlecenieStatusCommand
                {
                    Id = 0,
                    Nazwa = resultFromDialog.Nazwa
                });
                await PrepPage();
                ToastService.ShowSuccess("Dodano status zamównienia pomyślnie.");
            }
        }

        private async Task EditOnClick(GetZlecenieStatusDto command)
        {
            var dialogParams = new DialogParameters
            {

            };

            var addEditCommand = new AddEditBaseDialogModel
            {
                Id = command.Id,
                Nazwa = command.Nazwa,
                NazwaEtykieta = "Nazwa statusu:",
                Title = "Edytuj Status Zamówienia"
            };

            var dialog = await DialogService.ShowDialogAsync<AddEditBaseDialog>(addEditCommand, dialogParams);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                var resultFromDialog = (AddEditBaseDialogModel)result.Data;
                await ZlecenieHttpRepository.AddEditZlecenieStatus(new Shared.Zlecenie.Status.Command.AddEditZlecenieStatusCommand
                {
                    Id = resultFromDialog.Id,
                    Nazwa = resultFromDialog.Nazwa
                });
                await PrepPage();
                ToastService.ShowSuccess("Edycji statusu zamównienia zakończona pomyślnie");
            }
        }

        private async Task DeleteOnClick(int id)
        {
            var czyDelete = await OpenYesNoDialog("Usuwanie statusu zlecenia", "Czy chcesz napewno chcesz usunąć status zlecenia?");

            if (czyDelete)
            {
                await ZlecenieHttpRepository.DeleteZlecenieStatus(id);
                await PrepPage();
                ToastService.ShowSuccess("Usunięcie statusu zlecenia zakończone pomyślnie");
            }
        }
    }
}
