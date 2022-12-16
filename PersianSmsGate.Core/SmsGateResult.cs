namespace PersianSmsGate.Core
{
    public class SmsGateResult
    {
        public SmsGateWayError? Error { get; set; }
        public bool IsSuccess { get; set; }

        public SmsGateResult Success()
        {
            IsSuccess = true;
            return this;
        }

        public SmsGateResult Message(SmsGateWayError error)
        {
            Error = error;
            return this;
        }
    }
}