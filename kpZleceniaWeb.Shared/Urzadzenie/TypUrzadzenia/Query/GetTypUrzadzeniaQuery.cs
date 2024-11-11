using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Query
{
    public class GetTypUrzadzeniaQuery : IRequest<List<GetTypUrzadzeniaDto>>
    {
        public int Id { get; set; }
    }
}
