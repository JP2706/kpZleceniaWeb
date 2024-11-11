using kpZleceniaWeb.Shared.Zlecenie.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Query
{
    public class GetCzyKlientMaZleceniaQuery : IRequest<GetCzyKlientMaZleceniaDto>
    {
        public int KlientId { get; set; }
    }
}
