using System;
using System.Threading.Tasks;
using IT.Users.Models;
using System.Data.SqlClient;
using System.Data;
using IT.Users.Constants;
using System.Collections;
using System.Collections.Generic;

namespace IT.Users.Dal
{
    public class DBAuthRequest : DBFunctions
    {

        public  async Task<KeyValuePair<long,string>> GetHashCode(AuthRequest auth)
        {
            KeyValuePair<long, string> idHash;

            try
            {
                using (SqlConnection conn = NewConnection())
                {
                    using (SqlCommand cmd = NewCommand(conn, "GetAuthHash", CommandType.StoredProcedure, Param("@username", auth.Username, SqlDbType.VarChar)))
                    {
                        await conn.OpenAsync();
                        cmd.CommandTimeout = DataBase.commandTimeout;

                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                idHash = new KeyValuePair<long, string>((long)dr["userID"], dr["password"].ToString());
                            }

                            dr.Close();
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idHash;
        }

    }
}
