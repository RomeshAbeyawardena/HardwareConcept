using sInference.Contracts;
using System;
using System.Collections.Generic;

namespace sInference
{
    public class DefaultSmartCardState : ISmartCardState
    {
        private bool _isConnected = false;
        private bool _isTransmitting = false;
        private IEnumerable<char> _stripe;

        public IEnumerable<char> Stripe { get => _stripe; set { _stripe = value; Bind(Authenticated, EventArgs.Empty); } }
        public bool IsConnected { get => _isConnected; set { _isConnected = value; Bind(Connected, EventArgs.Empty); } }
        public bool IsTransmitting { get => _isTransmitting; set { _isTransmitting = value; Bind(Transmitting, EventArgs.Empty); } }
        public IEnumerable<byte> Transmission { get; set; }

        protected void Bind(EventHandler eventHandler, EventArgs e)
        {
            eventHandler?.Invoke(this, e);
        }

        public event EventHandler Authenticated;
        public event EventHandler Connected;
        public event EventHandler Transmitting;
    }
}
