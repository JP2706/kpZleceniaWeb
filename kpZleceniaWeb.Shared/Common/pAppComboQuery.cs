using MediatR;

namespace kpZleceniaWeb.Shared.Common
{
    public class pAppComboQuery : IRequest<List<pAppComboDto>>
    {
        public string Forms { get; set; }
        public string Combo { get; set; }
    }
}
