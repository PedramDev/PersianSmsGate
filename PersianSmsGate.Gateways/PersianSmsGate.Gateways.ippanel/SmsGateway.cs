using PersianSmsGate.Core;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersianSmsGate.Gateways.ippanel
{
    public class SmsGateway : ISmsGateway
    {
        private string _uname;
        private string _pass;
        private string _from;

        private const string _url = "http://188.0.240.110/api/select";

        private readonly HttpClient _client;
        public SmsGateway(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
        }

        public void Init(Dictionary<string, string> gateway_filds)
        {
            _uname = gateway_filds["uname"];
            _pass = gateway_filds["pass"];
            _from = gateway_filds["from"];
        }

        public async Task<SmsGateResult> Send(string mobile, string message)
        {
            var response = new SmsGateResult();

            var reqMessage = new HttpRequestMessage(HttpMethod.Post, _url);
            reqMessage.Content.Headers.Clear();
            reqMessage.Content.Headers.Add("Content-Type", "application/json");
            reqMessage.Content.Headers.Add("cache-control", "no-cache");
            reqMessage.Content = new StringContent(JsonSerializer.Serialize(
               new
               {
                   op = "send",
                   user = _uname,
                   pass = _pass,
                   fromNum = _from,
                   toNum = mobile,
                   message = message,
               })
            ,
            Encoding.UTF8, "application/json");

            using var result = await _client.SendAsync(reqMessage);

            var JsonResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.Success();
            //Todo Read Document for errors

            return response;
        }

        public async Task<SmsGateResult> SendPattern(string mobile,string pattern, Dictionary<string, string> fields)
        {
            var response = new SmsGateResult();

            var reqMessage = new HttpRequestMessage(HttpMethod.Post, _url);
            reqMessage.Content.Headers.Clear();
            reqMessage.Content.Headers.Add("Content-Type", "application/json");
            reqMessage.Content.Headers.Add("cache-control", "no-cache");
            reqMessage.Content = new StringContent(JsonSerializer.Serialize(
               new {
                   op = "pattern",
                   user = _uname,
                   pass = _pass,
                   fromNum = _from,
                   toNum = mobile,
                   patternCode = pattern,
                   inputData = fields,
               })
            ,
            Encoding.UTF8, "application/json");

            using var result = await _client.SendAsync(reqMessage);

            var JsonResult = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            response.Success();

            //Todo Read Document for errors

            //var jsonObject = JsonSerializer.Deserialize<ErrorResult>(JsonResult);
            //if (jsonObject != null && jsonObject.status != "ERR")
            //{
            //    response.Success();
            //}
            //else
            //{
            //    response.Message(new SmsGateWayError
            //    {
            //        Message = jsonObject.error_string
            //    });
            //}

            return response;
        }

    }
}