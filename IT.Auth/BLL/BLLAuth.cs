using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Users.Models;

namespace IT.Users.BLL
{
    public class Authentication
    {
        public static Auth GetValidation(ref Auth auth)
        {
            try
            {
                var _hashCode = Task.FromResult<string>(Auth.GetHashCode(auth)).Result;
                if (!string.IsNullOrEmpty(_hashCode))
                {
                    auth.isValid = Hash.Validate(auth.Password, _hashCode);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return auth;
        }

    }
}
