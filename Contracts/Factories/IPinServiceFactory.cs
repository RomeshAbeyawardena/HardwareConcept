using sInference.Contracts.Services;
using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Contracts.Factories
{
    public interface IPinServiceFactory
    {
        IPinService GetPinService(Pin pin);
    }
}
