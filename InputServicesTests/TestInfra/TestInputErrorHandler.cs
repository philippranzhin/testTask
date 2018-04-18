using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServicesTests.TestInfra
{
    class TestInputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        private Action<TSource> handleSource;
        private Action<TConverted> handleConverted;

        public bool ShouldRetry { get; set; }

        public TestInputErrorHandler(Action<TSource> handleSource, Action<TConverted> handleConverted, bool shouldRetry = false)
        {
            this.handleSource = handleSource;
            this.handleConverted = handleConverted;
            this.ShouldRetry = shouldRetry;
        }


        public void HandleError(TSource data)
        {
            this.handleSource(data);
        }

        public void HandleError(TConverted data)
        {
            this.handleConverted(data);
        }
    }
}
