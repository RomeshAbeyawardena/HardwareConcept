﻿using sInference.Contracts;
using sInference.Enumerations;
using System;

namespace sInference.Services
{
    public class ResetPinService : PinBaseService
    {
        public ResetPinService()
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
