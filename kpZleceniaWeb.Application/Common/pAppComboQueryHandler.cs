using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Common;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace kpZleceniaWeb.Application.Common
{
    public class pAppComboQueryHandler : KpBaseHandler, IRequestHandler<pAppComboQuery, List<pAppComboDto>>
    {
        public pAppComboQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<pAppComboDto>> Handle(pAppComboQuery request, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("forms", request.Forms),
                new SqlParameter("combo", request.Combo),
            };

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "pAppCombo";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);


                await _context.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var results = new List<dynamic>();
                    var resultsDto = new List<pAppComboDto>();
                    while (await result.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        
                            for (var i = 0; i < result.FieldCount; i++)
                            {
                                row.Add(result.GetName(i), result.IsDBNull(i) ? null : result.GetValue(i));

                            }
                            resultsDto.Add(new pAppComboDto(row));
                        
                    }

                    return resultsDto;
                }
            }
        }
    }
}
