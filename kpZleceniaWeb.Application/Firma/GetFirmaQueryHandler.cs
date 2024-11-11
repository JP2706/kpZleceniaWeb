using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Firma.Dto;
using kpZleceniaWeb.Shared.Firma.Query;
using MediatR;

namespace kpZleceniaWeb.Application.Firma
{
    public class GetFirmaQueryHandler : KpBaseHandler, IRequestHandler<GetFirmaQuery, GetFirmaDto>
    {
        public GetFirmaQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<GetFirmaDto> Handle(GetFirmaQuery request, CancellationToken cancellationToken)
        {
            var firma = _context.Firma.FirstOrDefault();

            if(firma == null)
                return new GetFirmaDto();

            return new GetFirmaDto 
            { 
                Id = firma.Id, 
                Adres = firma.Adres, 
                Email = firma.Email, 
                Nazwa = firma.Nazwa, 
                NIP = firma.NIP, 
                Telefon = firma.Telefon,
                Ulica = firma.Ulica,
                NumerDomu = firma.NumerDomu,
                NumerLokalu = firma.NumerLokalu,
                Miejscowosc = firma.Miejscowosc,
                KodPocztowy = firma.KodPocztowy,
                Poczta = firma.Poczta
            };
        }
    }
}
