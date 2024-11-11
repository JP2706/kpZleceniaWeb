using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Firma.Dto;
using kpZleceniaWeb.Shared.Firma.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpZleceniaWeb.Application.Firma
{
    public class CzyBrakFirmyQueryHandler : KpBaseHandler, IRequestHandler<CzyBrakFirmyQuery, CzyBrakFirmyDto>
    {
        public CzyBrakFirmyQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<CzyBrakFirmyDto> Handle(CzyBrakFirmyQuery request, CancellationToken cancellationToken)
        {
            var czyFirma = await _context.Firma.AnyAsync();

            return new CzyBrakFirmyDto { CzyBrakFirmy = !czyFirma };
        }
    }
}
