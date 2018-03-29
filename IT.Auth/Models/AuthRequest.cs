using System;
using IT.Users.Dal;

namespace IT.Users.Models
{
    public class AuthRequest 
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool isValid { get; set; }

        public static string GetHashCode (AuthRequest auth)
        {
            DBAuthRequest dbAuth = new DBAuthRequest();
            string _hashCode = null;

            try
            {
                _hashCode = dbAuth.GetHashCode(auth).Result;
            }
            catch (Exception)
            {

                throw;
            }

            return _hashCode;
        }

    }

}
