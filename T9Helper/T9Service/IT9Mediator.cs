// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IT9Mediator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the IT9Mediator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <summary>
    /// The T9Mediator interface.
    /// </summary>
    public interface IT9Mediator
    {
        /// <summary>
        /// Gets the count input.
        /// </summary>
        IInputProcessor<string, uint> CountInput { get; }

        /// <summary>
        /// Gets the messages input.
        /// </summary>
        IInputProcessor<string, string> MessagesInput { get; }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        IT9Mapper Mapper { get; }

        /// <summary>
        /// The map t 9 inputs.
        /// </summary>
        /// <param name="allowIncompleteResult">
        /// The allow incomplete result.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool MapT9Inputs(bool allowIncompleteResult, out List<string> results);
    }
}
