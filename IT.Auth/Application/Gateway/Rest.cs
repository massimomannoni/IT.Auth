using RestSharp;
using System.Threading.Tasks;
using System.Threading;
using IT.Auth.Log.Models;


namespace IT.Users
{
    public class GateWay
    {
        private const string apiAuthLog = "http://172.31.224.1:2100/";

        public static Task<int> LogRequest(AuthRequestLog authRequest)
        {
            EventWaitHandle _callBack = new AutoResetEvent(false);

            var _client = new RestClient(apiAuthLog);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var _request = new RestRequest("Api/Request", Method.POST);

            _request.AddParameter("application/json", authRequest, ParameterType.RequestBody);

            _request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var _taskSource = new TaskCompletionSource<int>();

            _client.ExecuteAsync<int>(_request, response =>
            {
                var _count = int.Parse(response.Content.ToString());
                _taskSource.SetResult(_count);

                _callBack.Set();

            });

            _callBack.WaitOne();

            return _taskSource.Task;
        }

        public static Task<int> CountRequest()
        {
            EventWaitHandle _callBack = new AutoResetEvent(false);        
            var _client = new RestClient(apiAuthLog);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var _request = new RestRequest("Api/Request", Method.GET);

            _request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var _taskSource = new TaskCompletionSource<int>();

            _client.ExecuteAsync<int>(_request, response =>
            {
                var _count = int.Parse(response.Content.ToString());
                _taskSource.SetResult(_count);

                _callBack.Set();

            });

            _callBack.WaitOne();

            return _taskSource.Task;
        }
    }
}