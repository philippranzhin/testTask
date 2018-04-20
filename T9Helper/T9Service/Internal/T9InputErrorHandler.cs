// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9InputErrorHandler.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9InputErrorHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service.Internal
{
    using System;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    internal class T9InputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        /// <summary>
        /// The type error handle strategy.
        /// </summary>
        private readonly Action<TSource> typeErrorHandleStrategy;

        /// <summary>
        /// The validation error handle strategy.
        /// </summary>
        private readonly Action<TConverted> validationErrorHandleStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T9InputErrorHandler{TSource,TConverted}"/> class.
        /// </summary>
        /// <param name="typeErrorHandleStrategy">
        /// The type error handle strategy.
        /// </param>
        /// <param name="validationErrorHandleStrategy">
        /// The validation error handle strategy.
        /// </param>
        public T9InputErrorHandler(Action<TSource> typeErrorHandleStrategy, Action<TConverted> validationErrorHandleStrategy)
        {
            this.typeErrorHandleStrategy = typeErrorHandleStrategy;
            this.validationErrorHandleStrategy = validationErrorHandleStrategy;
        }

        /// <inheritdoc />
        public bool ShouldRetry { get; set; } = true;

        /// <inheritdoc />
        public void HandleError(TSource data)
        {
            this.typeErrorHandleStrategy(data);
        }

        /// <inheritdoc />
        public void HandleError(TConverted data)
        {
            this.validationErrorHandleStrategy(data);
        }
    }
}
