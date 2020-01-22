using sInference.Enumerations;

namespace sInference.Contracts.Handlers
{
    public interface ISmartCardStateHandler
    {
        IResult Handle(Result result, ISmartCardState smartCardState);
    }
}
