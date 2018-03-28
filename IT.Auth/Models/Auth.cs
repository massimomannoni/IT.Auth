using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Users.Dal;

namespace IT.Users.Models
{
    public class Auth 
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool isValid { get; set; }

        public static string GetHashCode (Auth auth)
        {
            DBAuth dbAuth = new DBAuth();
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
