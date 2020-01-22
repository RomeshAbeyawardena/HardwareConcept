using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Contracts
{
    public interface ISmartCard
    {
        ISmartCardData Input(ISmartCardData cardData);
    }
}
