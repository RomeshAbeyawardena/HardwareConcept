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

        private void _smartCard_Transmitting(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _smartCard_Connected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _smartCard_Authenticated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
                .Input(SmartCardData.Create(Code.Request, Pin.Reset, stripe)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe2)));

            Console.WriteLine(_smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe)));

        }
    }
}
