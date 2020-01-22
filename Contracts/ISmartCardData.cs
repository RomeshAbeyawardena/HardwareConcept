using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Contracts
{
    public interface ISmartCardData
    {
        long Code { get; }
        byte Pin { get; }
        char[] Stripe { get; }
        IResult Result { get; }
        byte[] Data { get; }
        Code CodeType { get; }
        Pin PinType { get; }
        Result ResultType { get; }
    }
}
