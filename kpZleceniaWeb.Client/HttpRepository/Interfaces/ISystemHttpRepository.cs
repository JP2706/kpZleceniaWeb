using kpZleceniaWeb.Shared.Common;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface ISystemHttpRepository
    {
        Task<List<pAppComboDto>> pAppCombo(string forms, string combo);
    }
}
