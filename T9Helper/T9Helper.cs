using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    class T9Helper
    {
        bool MapT9Inputs(IInputProcessor<string, uint> countInput, IInputProcessor<string, string> t9input, bool allowIncompleteResult, Func<string, string> t9map,out List<string> results)
        {
            results = null;

            if (countInput.Process(out uint count))
            {
                if (t9input.ProcessAll(count, t9map, out results, allowIncompleteResult))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
         }
    }
}
