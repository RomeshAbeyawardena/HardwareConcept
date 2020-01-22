using sInference.Contracts.Services;
using sInference.Enumerations;

namespace sInference.Contracts.Factories
{
    public interface IPinServiceFactory
    {
        IPinService GetPinService(Pin pin);
    }
}
