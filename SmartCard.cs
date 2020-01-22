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
            _smartCardState.Authenticated += _smartCardState_Authenticated;
            _smartCardState.Connected += _smartCardState_Connected;
            _smartCardState.Transmitting += _smartCardState_Transmitting;

            _pinServiceFactory = pinServiceFactory;
        }

        private void _smartCardState_Transmitting(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _smartCardState_Connected(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void _smartCardState_Authenticated(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
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
