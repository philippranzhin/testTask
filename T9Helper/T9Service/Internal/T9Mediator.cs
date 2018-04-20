// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Mediator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Mediator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service.Internal
{
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    internal class T9Mediator : IT9Mediator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T9Mediator"/> class.
        /// </summary>
        /// <param name="countInput">
        /// The count input.
        /// </param>
        /// <param name="messagesInput">
        /// The messages input.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public T9Mediator(IInputProcessor<string, uint> countInput, IInputProcessor<string, string> messagesInput, IT9Mapper mapper)
        {
            this.CountInput = countInput;
            this.MessagesInput = messagesInput;
            this.Mapper = mapper;
        }

        /// <inheritdoc />
        public IInputProcessor<string, uint> CountInput { get; }

        /// <inheritdoc />
        public IInputProcessor<string, string> MessagesInput { get; }

        /// <inheritdoc />
        public IT9Mapper Mapper { get; }


        /// <inheritdoc />
        public bool MapT9Inputs(bool allowIncompleteResult, out List<string> results)
        {
            results = null;
                return this.CountInput.Process(out uint count) && this.MessagesInput.ProcessAll(
                           count,
                           this.Mapper.Map,
                           out results,
                           allowIncompleteResult);
        }
    }
}
