using DNI.Shared.Shared.Extensions;
using sInference.Contracts;
using sInference.Enumerations;
using System.Linq;

namespace sInference.Services
{
    public class RecievePinService : PinBaseService
    {
        public RecievePinService()
        {
            PinServiceHandleSwitch
                .CaseWhen(Code.BeginTransmit, BeginTransmit)
                .CaseWhen(Code.DataTransmit, DataTransmit)
                .CaseWhen(Code.BinaryTransmit, BinaryTransmit)
                .CaseWhen(Code.EndTransmit, EndTransmit);
        }

        private IResult BinaryTransmit(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(!IsAuthenticated(smartCardState, smartCardData))
                return SmartCardResult.CreateError(Result.Unauthorised, Code.Rejected);

            if(!smartCardState.IsTransmitting)
                return SmartCardResult.CreateError(Result.RecieveFailure, Code.Denied);

            smartCardState.Transmission = smartCardState.Transmission.Append(smartCardData.Data);

            return SmartCardResult.Create(Pin.Acknowledge, Code.Accepted, Result.ContinueTransmission);
        }

        private IResult EndTransmit(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(!IsAuthenticated(smartCardState, smartCardData))
                return SmartCardResult.CreateError(Result.Unauthorised, Code.Rejected);

            if(!smartCardState.IsTransmitting)
                return SmartCardResult.CreateError(Result.RecieveFailure, Code.Denied);

            smartCardState.IsTransmitting = false;

            return SmartCardResult.Create(Pin.Acknowledge, Code.Accepted, Result.TransmissionEnded);
        }

        private IResult DataTransmit(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            return BinaryTransmit(smartCardState, smartCardData);
        }

        private IResult BeginTransmit(ISmartCardState smartCardState, ISmartCardData smartCardData)
        {
            if(!IsAuthenticated(smartCardState, smartCardData))
                return SmartCardResult.CreateError(Result.Unauthorised, Code.Rejected);

            if(smartCardState.IsTransmitting)
                return SmartCardResult.CreateError(Result.RecieveFailure, Code.Denied);

            smartCardState.IsTransmitting = true;

            return SmartCardResult.Create(Pin.Acknowledge, Code.Accepted, Result.TransmissionEnded);
        }
    }
}
