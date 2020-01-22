using DNI.Shared.Shared.Extensions;
using sInference.Contracts;
using sInference.Contracts.Factories;
using sInference.Enumerations;

namespace sInference
{
    public partial class SmartCard : ISmartCard
    {
        private readonly ISmartCardState _smartCardState;
        private readonly IPinServiceFactory _pinServiceFactory;

        public SmartCard(IPinServiceFactory pinServiceFactory)
        {
            _smartCardState = new DefaultSmartCardState();
            _smartCardState.Authenticated += smartCardState_Authenticated;
            _smartCardState.Connected += smartCardState_Connected;
            _smartCardState.Transmitting += SmartCardState_Transmitting;

            _pinServiceFactory = pinServiceFactory;
        }

        private void SmartCardState_Transmitting(object sender, SmartCardEventArgs e)
        {
            Transmitting.InvokeIfAssigned(sender, e);
        }

        private void smartCardState_Connected(object sender, SmartCardEventArgs e)
        {
            Connected.InvokeIfAssigned(sender, e);
        }

        private void smartCardState_Authenticated(object sender, SmartCardEventArgs e)
        {
            Authenticated.InvokeIfAssigned(sender, e);
        }

        public ISmartCardData Input(ISmartCardData cardData)
        {
            return SmartCardData.Create(Handle(cardData));
        }

        private IResult Handle(ISmartCardData cardData)
        {
            var pin = SmartCardData.GetPin(cardData.Pin);
            var code = SmartCardData.GetCode(cardData.Code);

            var pinService = _pinServiceFactory
                .GetPinService(pin);

            if(pinService == null)
                return SmartCardResult
                    .CreateError(Result.UndeterminedResult);

            return pinService
                .Handle(code, _smartCardState, cardData);
        }
    }
}
