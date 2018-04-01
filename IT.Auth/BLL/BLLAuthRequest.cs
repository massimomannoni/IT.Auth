using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Users.Models;

namespace IT.Users.BLL
{
    public class Authentication
    {
        public static async Task<AuthRequest> GetValidation(AuthRequest auth)
        {
            
            try
            {
                string _hashCode =  await Task.FromResult<string>(AuthRequest.GetHashCode(auth).Result);
                if (!string.IsNullOrEmpty(_hashCode))
                {
                    auth.IsValid = Hash.Validate(auth.Password, _hashCode);
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
