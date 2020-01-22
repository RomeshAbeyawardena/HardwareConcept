using DNI.Shared.Shared.Extensions;
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

        public IEnumerable<char> Stripe { get => _stripe; set { _stripe = value; Bind(Authenticated, SmartCardEventArgs.Create(this, value)); } }
        public bool IsConnected { get => _isConnected; set { _isConnected = value; Bind(Connected, SmartCardEventArgs.Create(this, value)); } }
        public bool IsTransmitting { get => _isTransmitting; set { _isTransmitting = value; Bind(Transmitting, SmartCardEventArgs.Create(this, value)); } }
        public IEnumerable<byte> Transmission { get; set; }

        protected void Bind(EventHandler<SmartCardEventArgs> eventHandler, SmartCardEventArgs e)
        {
            eventHandler.InvokeIfAssigned(this, e);
        }

        public event EventHandler<SmartCardEventArgs> Authenticated;
        public event EventHandler<SmartCardEventArgs> Connected;
        public event EventHandler<SmartCardEventArgs> Transmitting;
    }
}
