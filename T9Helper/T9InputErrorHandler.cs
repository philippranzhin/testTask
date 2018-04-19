using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    class T9InputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        public bool ShouldRetry { get; set; } = true;

        private Action<TSource, string> typeErrorHandleStrategy;
        private Action<TConverted, string> validationErrorHandleStrategy;
        private string errorMessage;

        public T9InputErrorHandler(Action<TSource, string> typeErrorHandleStrategy, Action<TConverted, string> validationErrorHandleStrategy, string msg)
        {
            this.typeErrorHandleStrategy = typeErrorHandleStrategy;
            this.validationErrorHandleStrategy = validationErrorHandleStrategy;
            this.errorMessage = msg;
        }

        public void HandleError(TSource data)
        {
            this.typeErrorHandleStrategy(data, this.errorMessage);
        }

        public void HandleError(TConverted data)
        {
            this.validationErrorHandleStrategy(data, this.errorMessage);
        }
    }
}
