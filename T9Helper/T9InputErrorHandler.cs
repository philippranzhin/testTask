// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9InputErrorHandler.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9InputErrorHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper
{
    using System;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    public class T9InputErrorHandler<TSource, TConverted> : IInputErrorHandler<TSource, TConverted>
    {
        /// <summary>
        /// The type error handle strategy.
        /// </summary>
        private readonly Action<TSource, string> typeErrorHandleStrategy;

        /// <summary>
        /// The validation error handle strategy.
        /// </summary>
        private readonly Action<TConverted, string> validationErrorHandleStrategy;

        /// <summary>
        /// The error message.
        /// </summary>
        private readonly string errorMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="T9InputErrorHandler{TSource,TConverted}"/> class.
        /// </summary>
        /// <param name="typeErrorHandleStrategy">
        /// The type error handle strategy.
        /// </param>
        /// <param name="validationErrorHandleStrategy">
        /// The validation error handle strategy.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        public T9InputErrorHandler(Action<TSource, string> typeErrorHandleStrategy, Action<TConverted, string> validationErrorHandleStrategy, string msg)
        {
            this.typeErrorHandleStrategy = typeErrorHandleStrategy;
            this.validationErrorHandleStrategy = validationErrorHandleStrategy;
            this.errorMessage = msg;
        }

        /// <inheritdoc />
        public bool ShouldRetry { get; set; } = true;

        /// <inheritdoc />
        public void HandleError(TSource data)
        {
            this.typeErrorHandleStrategy(data, this.errorMessage);
        }

        /// <inheritdoc />
        public void HandleError(TConverted data)
        {
            this.validationErrorHandleStrategy(data, this.errorMessage);
        }
    }
}
