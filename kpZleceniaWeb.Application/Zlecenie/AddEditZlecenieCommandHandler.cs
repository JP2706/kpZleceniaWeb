using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Zlecenie.Command;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Zlecenie
{
    public class AddEditZlecenieCommandHandler : KpBaseHandler, IRequestHandler<AddEditZlecenieCommand, InfoDto>
    {
        public AddEditZlecenieCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<InfoDto> Handle(AddEditZlecenieCommand request, CancellationToken cancellationToken)
        {
            var returnParam = new InfoDto();

            var parameters = new[]
            {
                new SqlParameter("Id", request.Id),
                new SqlParameter("Symbol", request.Symbol),
                new SqlParameter("Urzadzenie", request.Urzadzenie),
                new SqlParameter("NumerSer", string.IsNullOrEmpty(request.NumerSer) ? string.Empty : request.NumerSer),
                new SqlParameter("OpisUsterki", request.OpisUsterki),
                new SqlParameter("Opis", request.Opis),
                new SqlParameter("DataPrzyjecie", request.DataPrzyjecie),
                new SqlParameter("DataRozpoczRealizacji", request.DataRozpoczRealizacji),
                new SqlParameter("DataZakRealizacji", request.DataZakRealizacji),
                new SqlParameter("DataWydania", request.DataWydania),
                new SqlParameter("ZlecenieStatusId", request.ZlecenieStatusId),
                new SqlParameter("KlientId", request.KlientId),
                new SqlParameter("TypUrzadzeniaId", request.TypUrzadzeniaId),
                new SqlParameter("ApplicationUserId", request.ApplicationUserId),
                new SqlParameter
                {
                    ParameterName = "Blad",
                     SqlDbType = System.Data.SqlDbType.SmallInt,
                    Direction = System.Data.ParameterDirection.Output,
                },
                new SqlParameter
                {
                    ParameterName = "Info",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 250,
                    Direction = System.Data.ParameterDirection.Output
                },
            };

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                var transakcja = connection.BeginTransaction();

                using(var cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "pAddEditZlecenie";
                        cmd.Transaction = transakcja;
                        cmd.Parameters.AddRange(parameters);

                        await cmd.ExecuteNonQueryAsync();

                        var blad = (short)parameters[cmd.Parameters.Count - 2].Value;
                        var info = parameters[parameters.Count() - 1].Value == DBNull.Value ? "" : (string)parameters[parameters.Count() - 1].Value;

                        if (blad <= -100)
                        {
                            returnParam.Blad = blad;
                            returnParam.Info = info;
                        }
                        else
                        {
                            transakcja.Commit();
                        }
                            
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transakcja.Rollback();
                        }
                        catch { }
                        returnParam.Blad = -255;
                        returnParam.Info = ex.Message;
                        return returnParam;
                    }
                }
            }

            return returnParam;
        }
    }
}
