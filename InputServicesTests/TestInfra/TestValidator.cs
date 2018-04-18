using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServicesTests.TestInfra
{
    class TestValidator<TSource> : IValidator<TSource>
    {
        private Func<TSource, bool> validateStrategy;

        public TestValidator(Func<TSource, bool> validateStrategy)
        {
            this.validateStrategy = validateStrategy;
        }

        public bool Validate(TSource data)
        {
            return this.validateStrategy(data);
        }
    }
}
