using sInference.Contracts;
using sInference.Enumerations;

namespace sInference
{
    public struct SmartCardData : ISmartCardData
    {
        public long Code { get; }
        public byte Pin { get; }
        public char[] Stripe { get; }
        public IResult Result { get; }
        public byte[] Data { get; }

        public Code CodeType => GetCode(Code);
        public Pin PinType => GetPin(Pin);
        public Result ResultType => GetResult(Result.Result);

        public override string ToString()
        {
            return string.Format("Pin: {0}\t\tCode: {1}\t\tResult:{2}", 
                GetPin(Pin), 
                GetCode(Code), 
                GetResult(Result.Result));
        }

        private SmartCardData(long code, byte pin, char[] stripe = null, byte[] data = null)
        {
            Code = code;
            Pin = pin;
            Stripe = stripe;
            Result = null;
            Data = data;
        }

        private SmartCardData(Code code, Pin pin, char[] stripe, byte[] data = null)
            : this(GetCode(code), GetPin(pin), stripe, data)
        {

        }

        private SmartCardData(IResult result)
            : this(result.Code, result.Pin, null)
        {
            Result = result;
        }

        public static Pin GetPin(byte pin)
        {
            return (Pin)pin;
        }

        public static byte GetPin(Pin pin)
        {
            return (byte)pin;
        }

        public static Code GetCode(long code)
        {
            return (Code)code;
        }

        public static long GetCode(Code code)
        {
            return (long)code;
        }

        public static Result GetResult(long result)
        {
            return (Result)result;
        }

        public static long GetResult(Result result)
        {
            return (long)result;
        }

        public static ISmartCardData Create(Code code, Pin pin, char[] stripe, byte[] data = null)
        {
            return new SmartCardData(code, pin, stripe, data);
        }

        public static ISmartCardData Create(IResult result)
        {
            return new SmartCardData(result);
        }
    }
}
