using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Klient.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Zlecenie
{
    public class GetZlecenieQueryHandler : KpBaseHandler, IRequestHandler<GetZlecenieQuery, List<GetZlecenieDto>>
    {
        public GetZlecenieQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetZlecenieDto>> Handle(GetZlecenieQuery request, CancellationToken cancellationToken)
        {
            var list = _context.Zlecenie
                .Include(x => x.Klient).Include(x => x.ZlecenieStatus).ToList();

            var returnList = new List<GetZlecenieDto>();
            if(request.Id == 0)
            {
                foreach (var item in list)
                {

                    var klient = new GetKlientDto
                    {
                        Id = item.Klient.Id,
                        Imie = item.Klient.Nazwa,
                        Nazwisko = item.Klient.Nazwisko,
                        Tel = item.Klient.Tel,
                        Nazwa = item.Klient.Nazwa,
                    };



                    var zlec = new GetZlecenieDto
                    {
                        Id = item.Id,
                        Symbol = item.Symbol,
                        Urzadzenie = item.Urzadzenie,
                        NumerSer = item.NumerSer,
                        OpisUsterki = item.OpisUsterki,
                        Opis = item.Opis,
                        DataPrzyjecie = item.DataPrzyjecie,
                        DataRozpoczRealizacji = item.DataRozpoczRealizacji,
                        DataZakRealizacji = item.DataZakRealizacji,
                        DataWydania = item.DataWydania,
                        ZlecenieStatus = item.ZlecenieStatus.Nazwa,
                        ZlecenieStatusId = item.ZlecenieStatusId,
                        KlientId = item.KlientId,
                        TypUrzadzeniaId = item.TypUrzadzeniaId,
                        ApplicationUserId = item.ApplicationUserId,
                        Klient = klient,

                    };
                    returnList.Add(zlec);
                }
            }
            else
            {
                var item = _context.Zlecenie.Include(x => x.Klient).FirstOrDefault(x => x.Id == request.Id);
                if(item != null)
                {

                    var klient = new GetKlientDto
                    {
                        Id = item.Klient.Id,
                        Imie = item.Klient.Nazwa,
                        Nazwisko = item.Klient.Nazwisko,
                        Tel = item.Klient.Tel,
                        Nazwa = item.Klient.Nazwa,
                    };


                    var zlec = new GetZlecenieDto
                    {
                        Id = item.Id,
                        Symbol = item.Symbol,
                        Urzadzenie = item.Urzadzenie,
                        NumerSer = item.NumerSer,
                        OpisUsterki = item.OpisUsterki,
                        Opis = item.Opis,
                        DataPrzyjecie = item.DataPrzyjecie,
                        DataRozpoczRealizacji = item.DataRozpoczRealizacji,
                        DataZakRealizacji = item.DataZakRealizacji,
                        DataWydania = item.DataWydania,
                        ZlecenieStatusId = item.ZlecenieStatusId,
                        KlientId = item.KlientId,
                        TypUrzadzeniaId = item.TypUrzadzeniaId,
                        ApplicationUserId = item.ApplicationUserId,
                        Klient = klient,

                    };
                    returnList.Add(zlec);
                }
            }

            return returnList;
            
        }
    }
}
