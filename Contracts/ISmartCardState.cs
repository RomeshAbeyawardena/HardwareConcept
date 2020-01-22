using System.Collections.Generic;

namespace sInference.Contracts
{
    public interface ISmartCardState
    {
        public bool IsConnected { get; set; }
        public IEnumerable<char> Stripe { get; set; }
        public bool IsTransmitting { get; set; }
        public IEnumerable<byte> Transmission { get; set; }
    }
}
