using sInference.Contracts;
using sInference.Enumerations;
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
        }

        public async Task Begin(IEnumerable<object> args)
        {
            var stripe = "BNA49349824398FHQA".ToCharArray();
            var stripe2 = "BNA49349824298FHQA".ToCharArray();
            var result = _smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe));

            var result2 = _smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe2));

            //var result3 = _smartCard.Input(SmartCard)

            var result3 = _smartCard.Input(SmartCardData.Create(Code.Request, Pin.Reset, stripe));

            var result4 = _smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe2));

            var result5 = _smartCard
                .Input(SmartCardData.Create(Code.Authenticate, Pin.Send, stripe));

        }
    }
}
