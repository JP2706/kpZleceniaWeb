using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Klient.Command;
using kpZleceniaWeb.Shared.Klient.Dto;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IKlientHttpRepository
    {
        Task<List<GetKlientDto>> GetKlient(int id = 0);
        Task AddEditKlient(AddEditKlientCommand command);
        Task DeleteKlient(int id);
    }
}
