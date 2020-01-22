using sInference.Contracts;
using sInference.Contracts.Handlers;
using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Services
{
    public class ResetPinService : PinBaseService
    {
        public ResetPinService(ISmartCardStateHandler smartCardStateHandler)
            : base(smartCardStateHandler)
        {
            PinServiceHandleSwitch.CaseWhen(Code.Request, RequestReset);
        }

        private IResult RequestReset(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(!IsAuthenticated(smartCardState, smartCardData))
                return SmartCardResult
                    .CreateError(Result.StripeResetRejected);

            smartCardState.Stripe = Array.Empty<char>();
            return SmartCardResult
                .Create(Pin.Acknowledge, Code.Accepted, Result.StripeResetCompleted);
        }

    }
}
