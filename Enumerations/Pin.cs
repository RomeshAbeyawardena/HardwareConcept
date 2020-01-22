using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Enumerations
{
    public enum Pin
    {
        Reset = 0x0000,
        Recieve = 0x0001,
        Transmit = 0x0002,
        Send = 0x0004,
        Acknowledge = 0x0006,
        Reject = 0x0008
    }
}
