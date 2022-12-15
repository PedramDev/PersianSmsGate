namespace PersianSmsGate.Core
{
    public class SmsGateResult
    {
        public SmsGateWayError? Error { get; set; }
        public bool IsSuccess { get; set; }
    }
}