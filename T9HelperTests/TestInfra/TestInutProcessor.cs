// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestInutProcessor.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the TestInutProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests.TestInfra
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    public class TestInutProcessor<TSource, TConverted, TResultTest> : IInputProcessor<TSource, TConverted>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        /// <summary>
        /// Gets or sets a value indicating whether process returns.
        /// </summary>
        public bool ProcessReturns { get; set; }

        /// <summary>
        /// Gets or sets the process out.
        /// </summary>
        public TConverted ProcessOut { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether process all returns.
        /// </summary>
        public bool ProcessAllReturns { get; set; }

        /// <summary>
        /// Gets or sets the process all out.
        /// </summary>
        public List<TResultTest> ProcessAllOut { get; set; }

        /// <inheritdoc />
        public bool Stopped { get; set; }

        /// <inheritdoc />
        public Func<TSource> ReadStrategy { get; set; }

        /// <inheritdoc />
        public IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; set; }

        /// <inheritdoc />
        public IValidator<TConverted> Validator { get; set; }

        /// <inheritdoc />
        public bool Process(out TConverted processedResult)
        {
            processedResult = (TConverted)this.ProcessOut;
            return this.ProcessReturns;
        }

        /// <inheritdoc />
        public bool ProcessAll<TResult>(uint count, Func<TConverted, TResult> map, out System.Collections.Generic.List<TResult> results, bool allowIncompleteResult)
        {
            results = this.ProcessAllOut as List<TResult>;
            return this.ProcessAllReturns;
        }
    }
}
