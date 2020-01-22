using sInference.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference
{
    public class DefaultSmartCardState : ISmartCardState
    {
        public IEnumerable<char> Stripe { get; set; }
        public bool IsTransmitting { get; set; }
        public IEnumerable<byte> Transmission { get; set; }
    }
}
