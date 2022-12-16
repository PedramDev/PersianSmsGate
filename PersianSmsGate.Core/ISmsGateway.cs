using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersianSmsGate.Core
{
    public interface ISmsGateway
    {
        void Init(Dictionary<string, string> gateway_filds);
        Task<SmsGateResult> Send(string mobile, string message);
        Task<SmsGateResult> SendPattern(string mobile, string pattern, Dictionary<string, string> fields);
    }
}