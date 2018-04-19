// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInputProcessor.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   The InputProcessor interface. Describes the objects, that can process input
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServices.InputProcessor
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The InputProcessor interface. Describes the objects, that can process input
    /// </summary>
    /// <typeparam name="TSource">
    /// the source type
    /// </typeparam>
    /// <typeparam name="TConverted">
    /// the type to convert
    /// </typeparam>
    public interface IInputProcessor<TSource, TConverted>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        /// <summary>
        /// Gets or sets a value indicating whether processing stopped.
        /// </summary>
        bool Stopped { get; set; }

        /// <summary>
        /// Gets the read strategy.
        /// </summary>
        Func<TSource> ReadStrategy { get; }

        /// <summary>
        /// Gets the input error handler.
        /// </summary>
        IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; }

        /// <summary>
        /// Gets the validator.
        /// </summary>
        IValidator<TConverted> Validator { get; }

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="processedResult">
        /// The processed result.
        /// </param>
        /// <returns>
        /// true, if input processed succesfully
        /// </returns>
        bool Process(out TConverted processedResult);

        /// <summary>
        /// The process all.
        /// </summary>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <param name="allowIncompleteResult">
        /// The allow incomplete result. If it is false, method will return true only in case, in which all entries were processed without errors
        /// </param>
        /// <typeparam name="TResult">
        /// the type of the result
        /// </typeparam>
        /// <returns>
        /// true, if entries was completed succesfully. Depends on <param name="allowIncompleteResult"/>
        /// </returns>
        bool ProcessAll<TResult>(uint count, Func<TConverted, TResult> map, out List<TResult> results, bool allowIncompleteResult);
    }
}
