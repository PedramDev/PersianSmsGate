using PersianSmsGate.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersianSmsGate.Gateways.arashpayamak
{
    public class SmsGateway : ISmsGateway
    {
        public void Init(Dictionary<string, string> gateway_filds)
        {
            throw new System.NotImplementedException();
        }

        public Task<SmsGateResult> Send(string mobile, string message)
        {
            throw new System.NotImplementedException();
        }

        public Task<SmsGateResult> SendPattern(string mobile, string pattern, Dictionary<string, string> fields)
        {
            throw new System.NotImplementedException();
        }
    }
}