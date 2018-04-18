using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    internal class DefaultInputProcessor<TSource, TConverted> : IInputProcessor<TSource, TConverted>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        public bool Stopped { get; set; } = false;

        public Func<TSource> ReadStrategy { get; private set; }

        public IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; private set; }

        public IValidator<TConverted> Validator { get; private set; }

        public DefaultInputProcessor(
            Func<TSource> readStrategy,
            IInputErrorHandler<TSource, TConverted> inputErrorHandler,
            IValidator<TConverted> validator)
        {
            this.ReadStrategy = readStrategy;
            this.InputErrorHandler = inputErrorHandler;
            this.Validator = validator;
        }

        public bool Process(out TConverted processedResult)
        {
            processedResult = default(TConverted);
            TSource readedValue = ReadStrategy();

            if(this.Stopped)
            {
                return false;
            }

            if (TryCast<TConverted>(readedValue, out TConverted convertedValue))
            {
                if (Validator.Validate(convertedValue))
                {
                    processedResult = convertedValue;
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

        public bool ProcessAll<TResult>(uint count, Func<TConverted, TResult> map, out List<TResult> results, bool allowIncompleteResult)
        {
            var resultCollection = new List<TResult>((int)count);
            results = null;

            if (count == 0)
            {
                throw new ArgumentException("count shouldn't be equals to 0");
            }

            for (uint i = 0; i < count; i++)
            {
                if (this.Process(out TConverted processedResult))
                {
                    resultCollection.Add(map(processedResult));
                }
                else if (!allowIncompleteResult)
                {
                    return false;
                }
            }
            if(resultCollection.Count > 0)
            {
                results = resultCollection;
                return true;
            }
            else
            {
                return false;
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
