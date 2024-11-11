using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Firma.Command;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Firma
{
    public class AddEditFirmaCommandHandler : KpBaseHandler, IRequestHandler<AddEditFirmaCommand, InfoDto>
    {
        public AddEditFirmaCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<InfoDto> Handle(AddEditFirmaCommand request, CancellationToken cancellationToken)
        {
            var returnDto = new InfoDto();

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("Id", request.Id),
                new SqlParameter("Nazwa", request.Nazwa),
                new SqlParameter("Nip", request.Nip),
                new SqlParameter("Telefon", request.Telefon),
                new SqlParameter("Email", string.IsNullOrEmpty(request.Email) ? string.Empty : request.Email),
                new SqlParameter("Ulica", request.Ulica),
                new SqlParameter("NumerDomu", request.NumerDomu),
                new SqlParameter("NumerLokalu", string.IsNullOrEmpty(request.NumerLokalu) ? string.Empty : request.NumerLokalu),
                new SqlParameter("Miejscowosc", request.Miejscowosc),
                new SqlParameter("KodPocztowy", request.KodPocztowy),
                new SqlParameter("Poczta", request.Poczta),
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

            using(var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                var transakcja = connection.BeginTransaction();
                using(var  cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "pAddEditFirma";
                        cmd.Transaction = transakcja;
                        cmd.Parameters.AddRange(parameters.ToArray());

                        await cmd.ExecuteNonQueryAsync();

                        var blad = (short)parameters[cmd.Parameters.Count - 2].Value;
                        var info = parameters[parameters.Count() - 1].Value == DBNull.Value ? "" : (string)parameters[parameters.Count() - 1].Value;

                        if (blad <= -100)
                        {
                            returnDto.Blad = blad;
                            returnDto.Info = info;
                            return returnDto;
                        }
                        else
                            transakcja.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transakcja.Rollback();
                        }
                        catch { }

                        returnDto.Blad = -255;
                        returnDto.Info = ex.Message;
                    }
                }
            }

            return returnDto;
        }
    }
}
