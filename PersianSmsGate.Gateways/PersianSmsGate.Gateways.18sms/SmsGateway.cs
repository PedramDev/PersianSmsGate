using PersianSmsGate.Core;
using PersianSmsGate.Core.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersianSmsGate.Gateways._18sms
{
    public class SmsGateway : ISmsGateway
    {
        private string _username;
        private string _password;
        private string _from;

        private const string _url = "http://18sms.ir/webservice/rest";

        private readonly HttpClient _client;
        public SmsGateway(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        public void Init(Dictionary<string, string> gateway_filds)
        {
            _username = gateway_filds["username"];
            _password = gateway_filds["password"];
            _from = gateway_filds["from"];
        }

        public async Task<SmsGateResult> Send(string mobile, string message)
        {
            var response = new SmsGateResult();

            using var result = await _client.GetAsync(_url + "/sms_send".QueryStringBuilder(new List<QueryParam>()
            {
                new QueryParam("login_username",_username),
                new QueryParam("login_password",_password),
                new QueryParam("receiver_number",mobile),
                new QueryParam("note_arr[]",message),
                new QueryParam("sender_number",_from)
            })).ConfigureAwait(false);

            var JsonResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonObject = JsonSerializer.Deserialize<ErrorResult>(JsonResult);
            if(jsonObject != null && jsonObject.status != "ERR") 
            {
                response.Success();
            }
            else
            {
                response.Message(new SmsGateWayError
                {
                    Message = jsonObject.error_string
                });
            }

            return response;
        }

        public Task<SmsGateResult> SendPattern(string mobile, string pattern, Dictionary<string, string> fields)
        {
            throw new System.NotImplementedException();
        }

        private class ErrorResult
        {
            public string status { get; set; }
            public string error_string { get; set; }
        }
    }
}