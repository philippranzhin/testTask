using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    internal class DefaultInputProcessor<TSource, TConverted, TResult> : IInputProcessor<TSource, TConverted, TResult>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        public Func<TSource> ReadStrategy { get; private set; }

        public Func<TConverted, TResult> Mapper { get; private set; }

        public IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; private set; }

        public IValidator<TConverted> Validator { get; private set; }

        public DefaultInputProcessor(
            Func<TSource> readStrategy,
            Func<TConverted, TResult> mapper,
            IInputErrorHandler<TSource, TConverted> inputErrorHandler,
            IValidator<TConverted> validator)
        {
            this.ReadStrategy = readStrategy;
            this.Mapper = mapper;
            this.InputErrorHandler = inputErrorHandler;
            this.Validator = validator;
        }

        public bool Process(out TResult processedResult)
        {
            processedResult = default(TResult);
            TSource readedValue = ReadStrategy();
            if (TryCast<TConverted>(readedValue, out TConverted convertedValue))
            {
                if (Validator.Validate(convertedValue))
                {
                    processedResult = Mapper(convertedValue);
                    return true;
                }
                else
                {
                    InputErrorHandler.HandleError(convertedValue);
                    return InputErrorHandler.ShouldRetry ? Process(out processedResult) : false;
                }
            }
            else
            {
                InputErrorHandler.HandleError(readedValue);
                return InputErrorHandler.ShouldRetry ? Process(out processedResult) : false;
            }
        }

        private bool TryCast<T>(TSource toParse, out T result)
        {
            try
            {
                result = (T)Convert.ChangeType(toParse, typeof(T));
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
    }
}
