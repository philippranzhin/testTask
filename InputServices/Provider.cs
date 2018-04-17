using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices
{
    public class Provider
    {
        public static IInputProcessor<TSource, TConverted, TResult> CreateInputProcessor<TSource, TConverted, TResult>(
            Func<TSource> readStrategy,
            Func<TConverted, TResult> mapper,
            IInputErrorHandler<TSource, TConverted> inputErrorHandler,
            IValidator<TConverted> validator
            )
            where TSource : IConvertible
            where TConverted : IConvertible => new DefaultInputProcessor<TSource, TConverted, TResult>(readStrategy, mapper, inputErrorHandler, validator);
    }
}
