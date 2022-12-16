using PersianSmsGate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Melipayamak
{
    public class SmsGateway : ISmsGateway
    {
        private string _username;
        private string _password;

        private string _from;
        private bool _isFlash;

        const string _path = "https://rest.payamak-panel.com/api/SendSMS/{0}";

        public SmsGateway()
        {

        }

        public void Init(Dictionary<string, string> gateway_filds)
        {
            _username = gateway_filds["username"];
            _password = gateway_filds["password"];


            _from = gateway_filds["from"];
            _isFlash = bool.Parse(gateway_filds["isFlash"]);
        }

        public Task<SmsGateResult> Send(string mobile, string message)
        {
            throw new Exception();
            //var response = new SmsGateResult();


            //return response;
        }

        public Task<SmsGateResult> SendPattern(string mobile, string pattern, Dictionary<string, string> fields)
        {
            throw new NotImplementedException();
        }
    }
}