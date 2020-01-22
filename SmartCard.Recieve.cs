using System;

namespace sInference
{
    public partial class SmartCard
    {
        public event EventHandler Authenticated;
        public event EventHandler Connected;
        public event EventHandler Transmitting;
    }
}
