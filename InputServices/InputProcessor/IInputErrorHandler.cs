using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    public interface IInputErrorHandler<TSource, TConverted>
    {
        bool ShouldRetry { get; }

        void HandleError(TSource data);

        void HandleError(TConverted data);
    }
}
