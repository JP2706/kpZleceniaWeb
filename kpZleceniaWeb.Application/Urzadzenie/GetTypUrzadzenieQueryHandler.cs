using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Query;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application.Urzadzenie
{
    public class GetTypUrzadzenieQueryHandler : KpBaseHandler, IRequestHandler<GetTypUrzadzeniaQuery, List<GetTypUrzadzeniaDto>>
    {
        public GetTypUrzadzenieQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetTypUrzadzeniaDto>> Handle(GetTypUrzadzeniaQuery request, CancellationToken cancellationToken)
        {
            var typResult = new List<GetTypUrzadzeniaDto>();

            if(request.Id == 0)
            {
                var typy = _context.TypUrzadzenia.ToList();

                foreach(var t in typy)
                {
                    var typDto = new GetTypUrzadzeniaDto
                    {
                        Id = t.Id,
                        Nazwa = t.Nazwa,
                    };

                    typResult.Add(typDto);
                }
               
            }
            else
            {
                var typ = _context.TypUrzadzenia.FirstOrDefault(x => x.Id == request.Id);
                if(typ != null)
                {
                    var typDto = new GetTypUrzadzeniaDto
                    {
                        Id = typ.Id,
                        Nazwa = typ.Nazwa,
                    };
                    typResult.Add(typDto);
                }
            }

            return typResult;
        }
    }
}
