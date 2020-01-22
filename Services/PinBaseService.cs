﻿using sInference.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNI.Shared.Contracts;
using DNI.Shared.Services;
using sInference.Contracts;
using sInference.Enumerations;
using sInference.Contracts.Handlers;

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

        protected PinBaseService(ISmartCardStateHandler smartCardStateHandler)
        {
            SmartCardStateHandler = smartCardStateHandler;
            PinServiceHandleSwitch = Switch
                .Create<Code, Func<ISmartCardState, ISmartCardData, IResult>>();
        }

        protected static bool IsAuthenticated(ISmartCardState smartCardState, ISmartCardData smartCard)
        {
            return smartCardState.Stripe != null 
                && smartCardState.Stripe.SequenceEqual(smartCard.Stripe);
        }

        protected ISmartCardStateHandler SmartCardStateHandler;
        protected ISwitch<Code, Func<ISmartCardState, ISmartCardData, IResult>> PinServiceHandleSwitch { get; }
    }
}
