namespace sInference.Enumerations
{
    public enum Result
    {
        Unauthorised = -4200,
        NotConnected = 3100,
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
        Connected = 4000,
        Disconnected = 4200
    }
}
