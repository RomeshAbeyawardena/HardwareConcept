using System;

namespace sInference.Contracts
{
    public interface ISmartCard
    {   
        public event EventHandler<SmartCardEventArgs> Authenticated;
        public event EventHandler<SmartCardEventArgs> Connected;
        public event EventHandler<SmartCardEventArgs> Transmitting;

        ISmartCardData Input(ISmartCardData cardData);
    }
}
