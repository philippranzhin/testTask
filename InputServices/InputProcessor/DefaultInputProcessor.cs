// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultInputProcessor.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the DefaultInputProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServices.InputProcessor
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The default input processor.
    /// </summary>
    /// <typeparam name="TSource">
    ///     the source type
    /// </typeparam>
    /// <typeparam name="TConverted">
    /// the type to convert
    /// </typeparam>
    internal class DefaultInputProcessor<TSource, TConverted> : IInputProcessor<TSource, TConverted>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultInputProcessor{TSource,TConverted}"/> class.
        /// </summary>
        /// <param name="readStrategy">
        /// The read strategy.
        /// </param>
        /// <param name="inputErrorHandler">
        /// The input error handler.
        /// </param>
        /// <param name="validator">
        /// The validator.
        /// </param>
        public DefaultInputProcessor(
            Func<TSource> readStrategy,
            IInputErrorHandler<TSource, TConverted> inputErrorHandler,
            IValidator<TConverted> validator)
        {
            this.ReadStrategy = readStrategy;
            this.InputErrorHandler = inputErrorHandler;
            this.Validator = validator;
        }

        /// <inheritdoc />
        public bool Stopped { get; set; } = false;

        /// <inheritdoc />
        public Func<TSource> ReadStrategy { get; private set; }

        /// <inheritdoc />
        public IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; private set; }

        /// <inheritdoc />
        public IValidator<TConverted> Validator { get; private set; }

        /// <inheritdoc />
        public bool Process(out TConverted processedResult)
        {
            processedResult = default(TConverted);
            TSource readedValue = this.ReadStrategy();

            if(this.Stopped)
            {
                return false;
            }

            if (this.TryCast(readedValue, out TConverted convertedValue))
            {
                if (this.Validator.Validate(convertedValue))
                {
                    processedResult = convertedValue;
                    return true;
                }
                else
                {
                    this.InputErrorHandler.HandleError(convertedValue);
                    return this.InputErrorHandler.ShouldRetry && this.Process(out processedResult);
                }
            }
            else
            {
                this.InputErrorHandler.HandleError(readedValue);
                return this.InputErrorHandler.ShouldRetry && this.Process(out processedResult);
            }
        }

        /// <inheritdoc />
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

        /// <summary>
        /// The try cast.
        /// </summary>
        /// <param name="toParse">
        /// The to parse.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <typeparam name="T">
        /// type to cast
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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
