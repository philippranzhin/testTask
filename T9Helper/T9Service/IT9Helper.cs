// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IT9Helper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the IT9Helper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;

    /// <summary>
    /// The T9Helper interface.
    /// </summary>
    public interface IT9Helper
    {
        /// <summary>
        /// Gets the t 9 mediator.
        /// </summary>
        IT9Mediator T9Mediator { get; }

        /// <summary>
        /// The help.
        /// </summary>
        /// <param name="write">
        /// The write.
        /// </param>
        /// <param name="allowIncompleteResult">
        /// The allow incomplete result.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Help(Action<string> write, bool allowIncompleteResult);
    }
}
