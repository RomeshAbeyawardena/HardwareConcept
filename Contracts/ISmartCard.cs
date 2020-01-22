using System;

namespace sInference.Contracts
{
    public interface ISmartCard
    {   
        public event EventHandler Authenticated;
        public event EventHandler Connected;
        public event EventHandler Transmitting;

        ISmartCardData Input(ISmartCardData cardData);
    }
}
