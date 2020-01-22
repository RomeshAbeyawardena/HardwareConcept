using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Enumerations
{
    public enum Result
    {
        Unauthorised = -4200,
        AlreadyConnected = -3200,
        AlreadyAuthenticated = -2200,
        RecieveFailure = -1200,
        UndeterminedResult = -1100,
        StripeResetFailed = -1000,
        StripeResetRejected = -2000,
        StripeResetCompleted = 1000,
        ContinueTransmission = 2000,
        TransmissionEnded = 2200,
        AuthenticationSucceeded = 3000,
        Connected = 4000
    }
}
