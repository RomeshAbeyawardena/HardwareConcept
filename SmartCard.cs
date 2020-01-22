using sInference.Contracts;
using sInference.Contracts.Factories;
using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference
{
    public partial class SmartCard : ISmartCard
    {
        private readonly ISmartCardState _smartCardState;
        private readonly IPinServiceFactory _pinServiceFactory;

        public SmartCard(IPinServiceFactory pinServiceFactory)
        {
            _smartCardState = new DefaultSmartCardState();
            _pinServiceFactory = pinServiceFactory;
        }

        public ISmartCardData Input(ISmartCardData cardData)
        {
            return SmartCardData.Create(Handle(cardData));
        }

        private IResult Handle(ISmartCardData cardData)
        {
            var pin = SmartCardData.GetPin(cardData.Pin);
            var code = SmartCardData.GetCode(cardData.Code);

            return _pinServiceFactory
                .GetPinService(pin)
                .Handle(code, _smartCardState, cardData);
        }
    }
}
