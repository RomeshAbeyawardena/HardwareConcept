using DNI.Shared.Contracts;
using sInference.Contracts.Factories;
using sInference.Contracts.Services;
using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Factories
{
    public class PinServiceFactory : IPinServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISwitch<Pin, Type> _pinTypeSwitch;

        public IPinService GetPinService(Pin pin)
        {
            var pinServiceType = _pinTypeSwitch.Case(pin);
            return (IPinService)_serviceProvider.GetService(pinServiceType);
        }

        public PinServiceFactory(ISwitch<Pin, Type> pinTypeSwitch, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _pinTypeSwitch = pinTypeSwitch;
        }
    }
}
