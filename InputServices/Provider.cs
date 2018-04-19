// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Provider.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   The provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServices
{
    using System;

    using InputServices.InputProcessor;

    /// <summary>
    /// The provider.
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// The create input processor.
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
        /// <typeparam name="TSource">
        /// source type
        /// </typeparam>
        /// <typeparam name="TConverted">
        /// type to convert
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>IInputProcessor</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static IInputProcessor<TSource, TConverted> CreateInputProcessor<TSource, TConverted>(
            Func<TSource> readStrategy,
            IInputErrorHandler<TSource, TConverted> inputErrorHandler,
            IValidator<TConverted> validator)
            where TSource : IConvertible where TConverted : IConvertible => new DefaultInputProcessor<TSource, TConverted>(readStrategy, inputErrorHandler, validator);
    }
}
