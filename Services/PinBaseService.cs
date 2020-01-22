using sInference.Contracts.Services;
using System;
using System.Linq;
using DNI.Shared.Contracts;
using DNI.Shared.Services;
using sInference.Contracts;
using sInference.Enumerations;

namespace sInference.Services
{
    public abstract class PinBaseService : IPinService
    {
        public virtual IResult Handle(Code code, ISmartCardState smartCardState, ISmartCardData cardData)
        {
            var action = PinServiceHandleSwitch.Case(code);

            if(action == null)
                return SmartCardResult
                    .CreateError(Result.UndeterminedResult, Code.Error);

            return action.Invoke(smartCardState, cardData);
        }

        protected PinBaseService()
        {
            PinServiceHandleSwitch = Switch
                .Create<Code, Func<ISmartCardState, ISmartCardData, IResult>>();
        }

        protected static bool IsAuthenticated(ISmartCardState smartCardState, ISmartCardData smartCard)
        {
            return smartCardState.Stripe != null 
                && smartCardState.Stripe.SequenceEqual(smartCard.Stripe);
        }

        protected ISwitch<Code, Func<ISmartCardState, ISmartCardData, IResult>> PinServiceHandleSwitch { get; }
    }
}
