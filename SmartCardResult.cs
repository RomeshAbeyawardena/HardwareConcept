﻿using sInference.Contracts;
using sInference.Enumerations;

namespace sInference
{
    public struct SmartCardResult : IResult
    {
        public byte Pin { get; }

        public long Code { get; }

        public long Result { get; }

        public SmartCardResult(byte pin, long code, long result)
        {
            Pin = pin;
            Code = code;
            Result = result;
        }

        public SmartCardResult(Pin pin, Code code, Result result)
            : this(SmartCardData.GetPin(pin), SmartCardData.GetCode(code), SmartCardData.GetResult(result))
        {

        }

        
        public static IResult CreateError(Result result, Code code = Enumerations.Code.Error)
        {
            return Create(Enumerations.Pin.Reject, code, result);
        }

        public static IResult Create(Pin pin, Code code, Result result)
        {
            return new SmartCardResult(pin, code, result);
        }

        public override string ToString()
        {
            return string.Format("Pin: {0} Code: {1} Result:{2}", 
                SmartCardData.GetPin(Pin), 
                SmartCardData.GetCode(Code), 
                SmartCardData.GetResult(Result));
        }

    }
}
