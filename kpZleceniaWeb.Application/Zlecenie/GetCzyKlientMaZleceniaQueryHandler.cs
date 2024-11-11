using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Query;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Zlecenie
{
    public class GetCzyKlientMaZleceniaQueryHandler : KpBaseHandler, IRequestHandler<GetCzyKlientMaZleceniaQuery, GetCzyKlientMaZleceniaDto>
    {
        public GetCzyKlientMaZleceniaQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<GetCzyKlientMaZleceniaDto> Handle(GetCzyKlientMaZleceniaQuery request, CancellationToken cancellationToken)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("KlientId", request.KlientId),
                new SqlParameter
                {
                    ParameterName = "CzyMa",
                     SqlDbType = System.Data.SqlDbType.Bit,
                    Direction = System.Data.ParameterDirection.Output,
                }

            };

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var cmd = connection.CreateCommand())
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetCzyKlientMaZlecenia";
                    cmd.Parameters.AddRange(parameters.ToArray());

                    await cmd.ExecuteNonQueryAsync();

                    return new GetCzyKlientMaZleceniaDto { CzyMa = (bool)cmd.Parameters[1].Value };

                }
            }

        }
    }
}
