// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the IValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServices.InputProcessor
{
    /// <summary>
    /// The Validator interface. Describes objects, that can validate data
    /// </summary>
    /// <typeparam name="TSource">
    /// the type of the data to validate
    /// </typeparam>
    public interface IValidator<in TSource>
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// true, if the given data is valid
        /// </returns>
        bool Validate(TSource data);
    }
}
