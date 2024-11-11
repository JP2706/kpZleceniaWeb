using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Klient.Dto;
using kpZleceniaWeb.Shared.Klient.Query;
using MediatR;

namespace kpZleceniaWeb.Application.Klient
{
    public class GetKlientQueryHandler : KpBaseHandler, IRequestHandler<GetKlientQuery, List<GetKlientDto>>
    {
        public GetKlientQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetKlientDto>> Handle(GetKlientQuery request, CancellationToken cancellationToken)
        {
            var returnDto = new List<GetKlientDto>();

            var klients = _context.Klient.ToList();

            foreach (var klient in klients)
            {
                var klient1 = new GetKlientDto
                {
                    Id = klient.Id,
                    Imie = klient.Imie,
                    Nazwisko = klient.Nazwisko,
                    Nazwa = klient.Nazwa,
                    Tel = klient.Tel
                };

                returnDto.Add(klient1);
            }

            return returnDto;
        }
    }
}
