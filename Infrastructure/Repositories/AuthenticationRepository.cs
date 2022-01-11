using Application.Helpers;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Auths;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly string connectionString;

        private readonly string storeSchema;

        public AuthenticationRepository(IConfiguration configuration)
        {
            storeSchema = "SIGESER.PKG_ATENCIONES_ONLINE";
            connectionString = configuration.GetConnectionString("OracleDBConnection");
        }

        public async Task<(ServiceStatus, string, UserMe)> Auth(AuthPayload payload)
        {
            var user = new UserMe();

            payload.Password = SecurityHelper.Encriptar(payload.Password.ToUpper());

            var status = false;

            try
            {
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("USP_LOGIN_GENERAL", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    //InParameter
                    cmd.Parameters.Add("xxUSUARIO", OracleDbType.Varchar2).Value = payload.Username.ToUpper();
                    cmd.Parameters.Add("xxPASSWORD", OracleDbType.Varchar2).Value = payload.Password;

                    //OutParameters
                    cmd.Parameters.Add("RESULTADO", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("MENSAJE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

                    //Cursor
                    cmd.Parameters.Add("RC1", OracleDbType.RefCursor, ParameterDirection.Output);

                    cmd.ExecuteNonQuery();

                    var resultado = int.Parse(cmd.Parameters["RESULTADO"].Value.ToString());
                    var mensaje = cmd.Parameters["MENSAJE"].Value.ToString();

                    if (resultado == 1)
                    {
                        OracleDataReader rdr = ((OracleRefCursor)cmd.Parameters["RC1"].Value).GetDataReader();
                        Permit permiso = null;
                        while (rdr.Read())
                        {
                            status = true;

                            user.FullName = rdr["U_NOMUSU"].ToString();
                            user.LastName = rdr["U_PATUSU"].ToString() + " " + rdr["U_MATUSU"].ToString();
                            user.CellMobil = rdr["U_TELMOVIL"].ToString();
                            user.TeleHouse = rdr["U_TELCASA"].ToString();
                            user.Email = rdr["U_EMAUSU"].ToString();
                            user.Address = rdr["U_DIRUSU"].ToString();
                            user.Dni = rdr["U_DNI"].ToString();
                            user.SexUser = rdr["U_SEXUSU"].ToString();
                            user.Profile = rdr["U_PERFIL"].ToString();
                            user.NamerCort = rdr["NOMCORTO"].ToString();
                            permiso = new Permit
                            {
                                /*MigrationVenta = Convert.ToBoolean(rdr["INDICADORES"].ToString()),
                                MigrationNoteCredit = Convert.ToBoolean(rdr["GENERAL"].ToString()),
                                MigrationCancellation = Convert.ToBoolean(rdr["ATCMANUAL"].ToString()),
                                MigrationAnul = Convert.ToBoolean(rdr["CONFIG"].ToString()),
                                MigrationAdmin = Convert.ToBoolean(rdr["ADMINISTRADOR"].ToString())*/
                            };

                            user.Permit = permiso;
                        }
                    }
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                return (ServiceStatus.InternalError, $"Problemas Internos de aplicación... { ex.Message }", null);
            }

            await Task.Delay(1);

            if (!status)
            {
                return (ServiceStatus.FailedValidation, "Usuario o contraseña es incorrecto", null);
            }

            return (ServiceStatus.Ok, null, user);
        }
    }
}
