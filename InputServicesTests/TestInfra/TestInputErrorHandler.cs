// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestInputErrorHandler.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the TestInputErrorHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServicesTests.TestInfra
{
    using System;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    public class TestInputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        /// <summary>
        /// The handle source.
        /// </summary>
        private Action<TSource> handleSource;

        /// <summary>
        /// The handle converted.
        /// </summary>
        private Action<TConverted> handleConverted;

        /// <inheritdoc />
        public bool ShouldRetry { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestInputErrorHandler{TSource,TConverted}"/> class.
        /// </summary>
        /// <param name="handleSource">
        /// The handle source.
        /// </param>
        /// <param name="handleConverted">
        /// The handle converted.
        /// </param>
        /// <param name="shouldRetry">
        /// The should retry.
        /// </param>
        public TestInputErrorHandler(Action<TSource> handleSource, Action<TConverted> handleConverted, bool shouldRetry = false)
        {
            this.handleSource = handleSource;
            this.handleConverted = handleConverted;
            this.ShouldRetry = shouldRetry;
        }

        /// <summary>
        /// The handle error.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void HandleError(TSource data)
        {
            this.handleSource(data);
        }

        /// <summary>
        /// The handle error.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public void HandleError(TConverted data)
        {
            this.handleConverted(data);
        }
    }
}
