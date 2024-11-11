using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IUrzadzenieHttpRepository
    {
        Task<List<GetTypUrzadzeniaDto>> GetTypUrzadzenia(int id = 0);
        Task AddEditTypUrzadzenia(AddEditTypUrzadzeniaCommand command);
        Task DeleteTypUrzadzenia(int id);
    }
}
