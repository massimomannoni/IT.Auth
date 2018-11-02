using System;
using IT.Users.Dal;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IT.Users.Models
{
    public class AuthRequest 
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsValid { get; set; }

        public static async Task<KeyValuePair<long, string>> GetHashCode (AuthRequest auth)
        {
            DBAuthRequest dbAuth = new DBAuthRequest();
            KeyValuePair<long, string> idHash;

            try
            {
                idHash = await Task.FromResult(result: dbAuth.GetHashCode(auth).Result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbAuth = null;
            }

            return idHash;
        }

    }

}
