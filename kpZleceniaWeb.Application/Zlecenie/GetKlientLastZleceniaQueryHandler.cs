using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Query;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace kpZleceniaWeb.Application.Zlecenie
{
    public class GetKlientLastZleceniaQueryHandler : KpBaseHandler, IRequestHandler<GetKlientLastZleceniaQuery, List<GetKlientLastZleceniaDto>>
    {
        public GetKlientLastZleceniaQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetKlientLastZleceniaDto>> Handle(GetKlientLastZleceniaQuery request, CancellationToken cancellationToken)
        {
            var parametry = new List<SqlParameter>
            {
                new SqlParameter("KlientId", request.KlientId),
                new SqlParameter("Ile", request.IleZlec),
            };


            return _context.Database.SqlQueryRaw<GetKlientLastZleceniaDto>("EXEC [dbo].[pGetKlientLastZlecenia] @KlientId = @KlientId, @Ile = @Ile", parametry.ToArray()).ToList();
        }
    }
}
