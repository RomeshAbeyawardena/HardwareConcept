using DNI.Shared.Services;
using DNI.Shared.Services.Abstraction;
using DNI.Shared.Services.Extensions;
using System;
using System.Threading.Tasks;

namespace sInference
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AppHost.Build<Startup>().ConfigureServices(services => services.RegisterServiceBroker<ServiceBroker>())
                .ConfigureStartupDelegate(async(startup, arguments) => await startup.Begin(arguments))
                .Start(args);
        }
    }

    class ServiceBroker : ServiceBrokerBase
    {
        public ServiceBroker()
        {
            Assemblies = new [] { GetAssembly<ServiceBroker>() };
        }
    }
}
