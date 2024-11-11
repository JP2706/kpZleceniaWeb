using kpZleceniaWeb.Client.HttpInterceptor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using Microsoft.FluentUI.AspNetCore.Components;
using kpZleceniaWeb.Client.Components.Dialog;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using kpZleceniaWeb.Client.Models.Components.Dialog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace kpZleceniaWeb.Client.Pages.Indeksy
{
    public partial class TypUrzadzeniaLista : KpBaseForm, IDisposable
    {
        #region PrivateParams
        private List<GetTypUrzadzeniaDto> _dtgTypyUrzadzeniaLista;
        private PaginationState _dtgTypyUrzadzeniaListaPagination = new PaginationState { ItemsPerPage = 10 };
        #endregion
        public void Dispose()
        {
            Interceptor.DisposeEvent();
        }

        protected override async Task OnInitializedAsync()
        {
            _formName = "TypUrzadzeniaLista";
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
            var lista = await UrzadzenieHttpRepository.GetTypUrzadzenia();
            _dtgTypyUrzadzeniaLista = lista;

        }

        private async Task AddOnClick()
        {
            var dialogParams = new DialogParameters
            {

            };

            var addEditCommand = new AddEditBaseDialogModel
            {
                NazwaEtykieta = "Nazwa typu:",
                Title = "Dodaj Typ Urządzenia"
            };

            var dialog = await DialogService.ShowDialogAsync<AddEditBaseDialog>(addEditCommand, dialogParams);

            var result = await dialog.Result;

            if(!result.Cancelled)
            {
                var resultFromDialog = (AddEditBaseDialogModel)result.Data;
                await UrzadzenieHttpRepository.AddEditTypUrzadzenia(new AddEditTypUrzadzeniaCommand
                {
                    Id = 0,
                    Nazwa = resultFromDialog.Nazwa
                });
                await PrepPage();
                ToastService.ShowSuccess("Dodano typ urządzenia pomyślnie");
            }
        }

        private async Task EditOnClick(GetTypUrzadzeniaDto command)
        {
            var dialogParams = new DialogParameters
            {

            };

            var addEditCommand = new AddEditBaseDialogModel 
            { 
                Id = command.Id, 
                Nazwa = command.Nazwa, 
                NazwaEtykieta = "Nazwa typu:",
                Title = "Edytuj Typ Urządzenia"
            };

            var dialog = await DialogService.ShowDialogAsync<AddEditBaseDialog>(addEditCommand, dialogParams);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                var resultFromDialog = (AddEditBaseDialogModel)result.Data;
                await UrzadzenieHttpRepository.AddEditTypUrzadzenia(new AddEditTypUrzadzeniaCommand 
                { 
                    Id = resultFromDialog.Id,
                    Nazwa = resultFromDialog.Nazwa
                });
                await PrepPage();
                ToastService.ShowSuccess("Edycji typ urządzenia zakończona pomyślnie");
            }
        }

        private async Task DeleteOnClick(int id)
        {
            var czyDelete = await OpenYesNoDialog("Usuwanie typu urządzenia", "Czy chcesz napewno chcesz usunąć typ urządzenia?");

            if(czyDelete)
            {
                await UrzadzenieHttpRepository.DeleteTypUrzadzenia(id);
                await PrepPage();
                ToastService.ShowSuccess("Usunięcie typ urządzenia zakończone pomyślnie");
            }
        }

        
    }
}
