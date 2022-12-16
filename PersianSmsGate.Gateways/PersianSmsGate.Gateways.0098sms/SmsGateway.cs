using PersianSmsGate.Core;
using ServiceReference1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersianSmsGate.Gateways._0098sms
{
    public class SmsGateway : ISmsGateway
    {
        private string _username;
        private string _password;
        private string _from;
    
        public void Init(Dictionary<string, string> gateway_filds)
        {
            _username= gateway_filds["username"];
            _password= gateway_filds["password"];
            _from= gateway_filds["from"];
        }

        public async Task<SmsGateResult> Send(string mobile, string message)
        {
            var response = new SmsGateResult();

            var client = new ServiceSoapClient( ServiceSoapClient.EndpointConfiguration.ServiceSoap12);
            var smsResult = await client.SendSMSAsync(_username, _password, message, mobile, _from);

            return response;
        }

        public Task<SmsGateResult> SendPattern(string mobile, string pattern, Dictionary<string, string> fields)
        {
            throw new System.NotImplementedException();
        }
    }
}