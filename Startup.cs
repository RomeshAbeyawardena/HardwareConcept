using sInference.Contracts;
using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sInference
{
    public class Startup
    {
        private readonly ISmartCard _smartCard;

        public Startup(ISmartCard smartCard)
        {
            _smartCard = smartCard;
            _smartCard.Authenticated += _smartCard_Authenticated;
            _smartCard.Connected += _smartCard_Connected;
            _smartCard.Transmitting += _smartCard_Transmitting;
        }

        private void _smartCard_Transmitting(object sender, SmartCardEventArgs e)
        {
            Console.WriteLine("{0} transmitting = {1}", string.Join('-',e.State.Stripe), e.StateResult);
        }

        private void _smartCard_Connected(object sender, SmartCardEventArgs e)
        {
            Console.WriteLine("{0} connected = {1}", string.Join('-',e.State.Stripe), e.StateResult);
        }

        private void _smartCard_Authenticated(object sender, SmartCardEventArgs e)
        {
            Console.WriteLine("{0} authenticated", string.Join('-',e.State.Stripe));
        }

        public async Task Begin(IEnumerable<object> args)
        {
            var stripe = "BNA49349824398FHQA".ToCharArray();
            var stripe2 = "BNA49349824298FHQA".ToCharArray();
            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe2)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Connect, Pin.Send, stripe)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Disconnect, Pin.Send, stripe)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Request, Pin.Reset, stripe)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe2)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe)));

        }
    }
}
