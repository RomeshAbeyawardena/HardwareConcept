using sInference.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sInference
{
    public class SmartCardEventArgs
    {
        public ISmartCardState State { get; }
        public object StateResult { get; }
        private SmartCardEventArgs(ISmartCardState state, object stateResult)
        {
            State = state;
            StateResult = stateResult;
        }

        public static SmartCardEventArgs Create(ISmartCardState state, object stateResult = default)
        {
            return new SmartCardEventArgs(state, stateResult);
        }
    }
}
