using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    class InputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        public bool ShouldRetry { get; set; } = true;

        private Action<string> writeStrategy;

        public InputErrorHandler(Action<string> writeStrategy)
        {
            this.writeStrategy = writeStrategy;
        }

        public void HandleError(TSource data)
        {
            this.writeStrategy($"{data} has incorrect type.");
        }

        public void HandleError(TConverted data)
        {
            this.writeStrategy($"{data} is incorrect input.");
        }
    }
}
