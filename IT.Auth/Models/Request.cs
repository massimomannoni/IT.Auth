﻿using System.Threading.Tasks;
using IT.Auth.Log.Dal;
using System.Collections.Generic;

namespace IT.Auth.Log.Models
{

    public class Request
    {

        public string ApplicationPath { get; set; }

        public string Browser { get; set; }

        public string Platform { get; set; }

        public bool ActiveXControls { get; set; }

        public bool JavaApplets { get; set; }

        public bool Javascipt { get; set; }

        public bool VBscript { get; set; }

        public int Version { get; set; }

        public string ContentType { get; set; }

        public string ContentExecutioFilePath { get; set; }

        public string FilePath { get; set; }

        public string HttpMethod { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool IsSecureConnection { get; set; }

        public string Path { get; set; }

        public string PathInfo { get; set; }

        public string QueryString { get; set; }

        public int TotalBytes { get; set; }

        public string Url { get; set; }

        public string UserAgent { get; set; }

        public string UrlReferrer { get; set; }

        public string DominioReferrer { get; set; }

        public string UserHostAddress { get; set; }

        public string UserHostName { get; set; }

        public string UserLanguages { get; set; }

        public string SessionID { get; set; }

        public string UserID { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string RegionName { get; set; }

        public string CityName { get; set; }

        public string ZipCode { get; set; }

        public static void Add(Request request)
        {
            DBRequests dbRequests = new DBRequests();

            try
            {
                Task.FromResult(dbRequests.Insert(request));
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                dbRequests = null;
            }
        }

        public static int CountByUserID(long userID)
        {
            DBRequests dbRequests = new DBRequests();
            int _count = 0;

            try
            {
                _count = Task.FromResult<int>(dbRequests.CountByUserID(userID).Result).Result;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                dbRequests = null;
            }

            return _count;
        }

    }
}