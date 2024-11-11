using kpZleceniaWeb.Shared.Zlecenie.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Query
{
    public class GetKlientLastZleceniaQuery : IRequest<List<GetKlientLastZleceniaDto>>
    {
        public int KlientId { get; set; }
        public int IleZlec { get; set; }
    }
}
