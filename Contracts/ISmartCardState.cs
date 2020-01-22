using System;
using System.Collections.Generic;

namespace sInference.Contracts
{
    public interface ISmartCardState
    {
        event EventHandler Authenticated;
        event EventHandler Connected;
        event EventHandler Transmitting;
        public bool IsConnected { get; set; }
        public IEnumerable<char> Stripe { get; set; }
        public bool IsTransmitting { get; set; }
        public IEnumerable<byte> Transmission { get; set; }
    }
}
