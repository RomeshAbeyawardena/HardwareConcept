using DNI.Shared.Contracts;
using DNI.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using sInference.Contracts;
using sInference.Contracts.Factories;
using sInference.Enumerations;
using sInference.Factories;
using sInference.Services;
using System;

namespace sInference
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ISmartCard,SmartCard>()
                .AddSingleton<IPinServiceFactory, PinServiceFactory>()
                .AddSingleton<SendPinService>()
                .AddSingleton<ResetPinService>()
                .AddSingleton<RecievePinService>()
                .AddSingleton(Switch
                    .Create<Pin,Type>()
                        .CaseWhen(Pin.Send, typeof(SendPinService))
                        .CaseWhen(Pin.Reset, typeof(ResetPinService))
                        .CaseWhen(Pin.Recieve, typeof(RecievePinService)));
        }
    }
}
