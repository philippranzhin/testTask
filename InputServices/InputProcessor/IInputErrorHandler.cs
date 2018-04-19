// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInputErrorHandler.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the IInputErrorHandler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServices.InputProcessor
{
    /// <summary>
    /// The InputErrorHandler interface.
    /// </summary>
    /// <typeparam name="TSource">
    /// the source type
    /// </typeparam>
    /// <typeparam name="TConverted">
    /// the type to convert
    /// </typeparam>
    public interface IInputErrorHandler<in TSource, in TConverted>
    {
        /// <summary>
        /// Gets a value indicating whether should retry in case of error.
        /// </summary>
        bool ShouldRetry { get; }

        /// <summary>
        /// Handle convert error.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        void HandleError(TSource data);

        /// <summary>
        /// Handle validation error.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        void HandleError(TConverted data);
    }
}
