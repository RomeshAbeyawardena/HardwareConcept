using sInference.Contracts;
using sInference.Contracts.Handlers;
using sInference.Enumerations;
using System.Linq;

namespace sInference.Services
{
    public class SendPinService : PinBaseService
    {
        public SendPinService(ISmartCardStateHandler smartCardStateHandler)
            : base(smartCardStateHandler)
        {
            PinServiceHandleSwitch
                .CaseWhen(Code.Authenticate, Authenticate)
                .CaseWhen(Code.Connect, Connect);
        }

        private IResult Connect(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(!IsAuthenticated(smartCardState, smartCardData))
                return SmartCardResult.CreateError(Result.Unauthorised, Code.Rejected);

            if(smartCardState.IsConnected)
                return SmartCardResult.CreateError(Result.AlreadyConnected, Code.Rejected);

            smartCardState.IsConnected = true;
            return SmartCardResult.Create(Pin.Acknowledge, Code.Accepted, Result.Connected);
        }

        private IResult Authenticate(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(IsAuthenticated(smartCardState, smartCardData) 
                || (smartCardState.Stripe != null && smartCardState.Stripe.Any()))
                return SmartCardResult.CreateError(Result.AlreadyAuthenticated);

            smartCardState.Stripe = smartCardData.Stripe;
            return SmartCardResult
                .Create(Pin.Acknowledge, Code.Accepted, Result.AuthenticationSucceeded);
        }
    }
}
