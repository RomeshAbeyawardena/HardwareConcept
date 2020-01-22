using sInference.Enumerations;

namespace sInference.Contracts.Services
{
    public interface IPinService
    {
        IResult Handle(Code code, ISmartCardState smartCardState, ISmartCardData cardData);
    }
}
