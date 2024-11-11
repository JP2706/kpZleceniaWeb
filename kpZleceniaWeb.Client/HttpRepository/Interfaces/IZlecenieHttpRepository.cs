using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Zlecenie.Command;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using kpZleceniaWeb.Shared.Zlecenie.Status.Dto;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IZlecenieHttpRepository
    {
        Task<List<GetZlecenieStatusDto>> GetZlecenieStatus(int id = 0);
        Task AddEditZlecenieStatus(AddEditZlecenieStatusCommand command);
        Task DeleteZlecenieStatus(int id);
        Task<InfoDto> AddEditZlecenie(AddEditZlecenieCommand command);
        Task<List<GetZlecenieDto>> GetZlecenie(int id = 0);
        Task ChangeZlecenieStatus(ChangeZlecenieStatusCommand command);
        Task DeleteZlecenie(int id);
        Task<List<GetKlientLastZleceniaDto>> GetKlientLastZlecenia(int klientId, int ileRek);
        Task<GetCzyKlientMaZleceniaDto> GetCzyKlientMaZlecenia(int klientId);
    }
}
