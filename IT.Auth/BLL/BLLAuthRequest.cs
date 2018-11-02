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
                KeyValuePair<long, string> idHash =  await Task.FromResult<KeyValuePair<long, string>>(AuthRequest.GetHashCode(auth).Result);
                if (idHash.Key > 0)
                {
                    auth.IsValid = (Security.PasswordHash.Create(idHash.Key, auth.Password) == idHash.Value);
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
