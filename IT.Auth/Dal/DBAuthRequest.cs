using System;
using System.Threading.Tasks;
using IT.Users.Models;
using System.Data.SqlClient;
using System.Data;
using IT.Users.Constants;


namespace IT.Users.Dal
{
    public class DBAuthRequest : DBFunctions
    {

        public  async Task<string> GetHashCode(AuthRequest auth)
        {
            string _hash = string.Empty;

            try
            {
                using (SqlConnection _conn = NewConnection())
                {
                    using (SqlCommand _cmd = NewCommand(_conn, "GetAuthHash", CommandType.StoredProcedure, Param("@username", auth.Username, SqlDbType.VarChar)))
                    {
                        await _conn.OpenAsync();
                        _cmd.CommandTimeout = DataBase.commandTimeout;

                        using (var _dr = await _cmd.ExecuteReaderAsync())
                        {
                            while (await _dr.ReadAsync())
                            {
                                _hash = _dr["password"].ToString();                                
                            }

                            _dr.Close();
                        }

                        _conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _hash;
        }

    }
}
