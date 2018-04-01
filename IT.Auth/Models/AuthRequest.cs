using System;
using IT.Users.Dal;
using System.Threading.Tasks;

namespace IT.Users.Models
{
    public class AuthRequest 
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsValid { get; set; }

        public static async Task<string> GetHashCode (AuthRequest auth)
        {
            DBAuthRequest dbAuth = new DBAuthRequest();
            string _hashCode = null;

            try
            {
                _hashCode = await Task.FromResult<string>(dbAuth.GetHashCode(auth).Result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbAuth = null;
            }

            return _hashCode;
        }

    }

}
