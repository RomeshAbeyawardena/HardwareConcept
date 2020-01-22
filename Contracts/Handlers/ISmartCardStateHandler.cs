using sInference.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference.Contracts.Handlers
{
    public interface ISmartCardStateHandler
    {
        IResult Handle(Result result, ISmartCardState smartCardState);
    }
}
