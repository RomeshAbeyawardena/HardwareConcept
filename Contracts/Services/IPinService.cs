using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Contracts.Services
{
    public interface IPinService
    {
        IResult Handle(Code code, ISmartCardState smartCardState, ISmartCardData cardData);
    }
}
