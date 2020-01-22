using sInference.Contracts;
using System.Collections.Generic;

namespace sInference
{
    public class DefaultSmartCardState : ISmartCardState
    {
        public IEnumerable<char> Stripe { get; set; }
        public bool IsConnected { get; set; }
        public bool IsTransmitting { get; set; }
        public IEnumerable<byte> Transmission { get; set; }
    }
}
