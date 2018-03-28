using System;
using RestSharp;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using IT.Users.Models;
using IT.Auth.Log.Models;
using System.Collections.Generic;


namespace IT.Users
{
    public class GateWay
    {
        private const string apiAuthLog = "http://172.31.224.1:2100/";

        public void LogRequest(Request authRequest)
        {
            var client = new RestClient("http://localhost:2050/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("Api/Orders", Method.POST);

            request.AddParameter("application/json", authRequest, ParameterType.RequestBody);


            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
        }

        public static Task<int> CountRequest()
        {
            EventWaitHandle executedCallBack = new AutoResetEvent(false);        
            var client = new RestClient(apiAuthLog);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("Api/Request", Method.GET);

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var tcs = new TaskCompletionSource<int>();

            client.ExecuteAsync<int>(request, response =>
            {
                var _count = int.Parse(response.Content.ToString());
                tcs.SetResult(_count);

                executedCallBack.Set();

            });

            executedCallBack.WaitOne();
            return tcs.Task;
        }
    }
}