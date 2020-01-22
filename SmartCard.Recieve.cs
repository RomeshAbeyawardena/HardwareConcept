using System;

namespace sInference
{
    public partial class SmartCard
    {
        public event EventHandler<SmartCardEventArgs> Authenticated;
        public event EventHandler<SmartCardEventArgs> Connected;
        public event EventHandler<SmartCardEventArgs> Transmitting;
    }
}
