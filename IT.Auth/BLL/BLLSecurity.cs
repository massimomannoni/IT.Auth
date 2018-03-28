using System;
using System.Security.Cryptography;
using IT.Users.Models;
using System.Threading.Tasks;

namespace IT.Users.BLL
{
    ////public class Logger
    ////{
    ////    public static void VerifyUserCountryAuthenticationAlert(string _username, string _email)
    ////    {
    ////        string _countryName = string.Empty;
    ////        string _countryIP = string.Empty;
    ////        DataTable _tmpDt;


    ////        try
    ////        {
    ////            LoginRequestController _controller = new LoginRequestController();

    ////            _tmpDt = _controller.GetCountryIPUserAuthenticated(_username);
    ////            if (_tmpDt.Rows.Count > 1)
    ////            {
    ////                if (_tmpDt.Rows[0]["countryname"].ToString() != _tmpDt.Rows[1]["countryname"].ToString())
    ////                {
    ////                    _countryName = _tmpDt.Rows[0]["countryname"].ToString();
    ////                    _countryIP = _tmpDt.Rows[0]["userhostaddress"].ToString();

    ////                    UserUtility.EmailSendAlertLoginFromOtherCountry(_email, _countryName, _countryIP);
    ////                }
    ////            }
    ////        }
    ////        catch (Exception)
    ////        {
                
    ////            throw;
    ////        }
    ////        finally
    ////        {
    ////            _tmpDt = null;
    ////        }
       
    ////    }

    ////    public static void LogLoginRequest(HttpRequest Request, string username, string sessionID)
    ////    {
    ////        LoginRequest _loginRequest = new LoginRequest();
    ////        _loginRequest.ApplicationPath = Request.ApplicationPath;
    ////        _loginRequest.Browser = Request.Browser.Browser;
    ////        _loginRequest.Platform = Request.Browser.Platform;
    ////        _loginRequest.ActiveXControls = Request.Browser.ActiveXControls;
    ////        _loginRequest.JavaApplets = Request.Browser.JavaApplets;
    ////        _loginRequest.VBscript = Request.Browser.VBScript;
    ////        _loginRequest.Version = Request.Browser.EcmaScriptVersion.Major;
    ////        _loginRequest.ContentType = Request.ContentType;
    ////        _loginRequest.ContentExecutioFilePath = Request.CurrentExecutionFilePath;
    ////        _loginRequest.FilePath = Request.FilePath;
    ////        _loginRequest.HttpMethod = Request.HttpMethod;
    ////        _loginRequest.IsAuthenticated = Request.IsAuthenticated;
    ////        _loginRequest.IsSecureConnection = Request.IsSecureConnection;
    ////        _loginRequest.Path = Request.Path;
    ////        _loginRequest.PathInfo = Request.PathInfo;
    ////        _loginRequest.QueryString = Request.QueryString.ToString();
    ////        _loginRequest.TotalBytes = Request.TotalBytes;
    ////        _loginRequest.Url = String.Format("Port={0};{1}", Request.Url.Port.ToString(), Request.Url.OriginalString);
    ////        _loginRequest.UserAgent = string.Empty;
    ////        if (Request.UserAgent != null)
    ////            _loginRequest.UserAgent = Request.UserAgent;
    ////        _loginRequest.UrlReferrer = Request.UrlReferrer == null ? String.Empty : String.Format("Port={0};{1}", Request.UrlReferrer.Port.ToString(), Request.UrlReferrer.OriginalString);
    ////        _loginRequest.DominioReferrer = GetURLDomain(Request.UrlReferrer == null ? String.Empty : Request.UrlReferrer.OriginalString);
    ////        _loginRequest.UserHostAddress = Request.UserHostAddress;
    ////        _loginRequest.UserHostName = Request.UserHostName;
    ////        _loginRequest.UserLanguages = string.Empty;
    ////        if (Request.UserLanguages != null && Request.UserLanguages.Length > 0)
    ////            _loginRequest.UserLanguages = Request.UserLanguages[0];
    ////        _loginRequest.SessionID = sessionID;
    ////        _loginRequest.UserID = username;

    ////        if (_loginRequest.UserHostAddress == "::1")
    ////            _loginRequest.UserHostAddress = "127.0.0.0";

    ////        string[] ip = _loginRequest.UserHostAddress.Split('.');

    ////        LoginRequestController controller = new LoginRequestController();
    ////        DataTable _tmpDt = controller.GetGeoInfo(int.Parse(ip[0]), int.Parse(ip[1]), int.Parse(ip[2]), int.Parse(ip[3]));
    ////        if (_tmpDt.Rows.Count > 0)
    ////        {
    ////            _loginRequest.CountryCode = _tmpDt.Rows[0]["country_code"].ToString();
    ////            _loginRequest.CountryName = _tmpDt.Rows[0]["country_name"].ToString();
    ////            _loginRequest.RegionName = _tmpDt.Rows[0]["region_name"].ToString();
    ////            _loginRequest.CityName = _tmpDt.Rows[0]["city_name"].ToString();
    ////            _loginRequest.ZipCode = _tmpDt.Rows[0]["zip_code"].ToString();
    ////        }

    ////        _loginRequest.Add(_loginRequest);

    ////        _loginRequest = null;
    
    ////    }

    ////    private static string GetURLDomain(string referrer)
    ////    {
    ////        var urlRegex = new Regex(@"(http|ftp)s?://(?<domain>[^/]+)");
    ////        var match = urlRegex.Match(referrer);

    ////        if (match.Success && match.Groups["domain"] != null)
    ////            return match.Groups["domain"].Value;

    ////        return String.Empty;
    ////    }

    ////    private string GetIPAddress()
    ////    {
    ////        System.Web.HttpContext context = System.Web.HttpContext.Current;
    ////        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

    ////        if (!string.IsNullOrEmpty(ipAddress))
    ////        {
    ////            string[] addresses = ipAddress.Split(',');
    ////            if (addresses.Length != 0)
    ////            {
    ////                return addresses[0];
    ////            }
    ////        }

    ////        return context.Request.ServerVariables["REMOTE_ADDR"];
    ////    }
    ////}

    //public class Token
    //{
    //    public static string GetToken()
    //    {
    //        RandomNumberGenerator _rng = new RNGCryptoServiceProvider();
    //        byte[] _tokenData = new byte[32];
    //        _rng.GetBytes(_tokenData);

    //        return Convert.ToBase64String(_tokenData);
    //    }

    //    public static void SaveToken(long userID, string token)
    //    {
    //        TokenController _tokenController = new TokenController();
    //        _tokenController.AddToken(userID, token);
    //    }

    //}

    public class Hash
    {
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        public static string Create(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +  Convert.ToBase64String(salt) + ":" +  Convert.ToBase64String(hash);
        }

        public static bool Validate(string password, string correctHash)
        {
            try
            {
                // Extract the parameters from the hash
                char[] delimiter = { ':' };
                string[] split = correctHash.Split(delimiter);
                int iterations = Int32.Parse(split[ITERATION_INDEX]);
                byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
                byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

                byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
                return SlowEquals(hash, testHash);
            }
            catch (Exception )
            {   
                throw;
            }
            
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }


}