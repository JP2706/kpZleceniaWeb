using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Firma.Command;
using kpZleceniaWeb.Shared.Firma.Dto;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IFirmaHttpRepository
    {
        Task<InfoDto> AddEditFirma(AddEditFirmaCommand command);
        Task<bool> CzyFirma();
        Task<GetFirmaDto> GetFirma();
    }
}
