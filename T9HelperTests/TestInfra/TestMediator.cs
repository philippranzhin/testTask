// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMediator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the TestMediator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests.TestInfra
{
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    using T9Helper.T9Service;

    /// <summary>
    /// The test mediator.
    /// </summary>
    public class TestMediator : IT9Mediator
    {
        /// <summary>
        /// Gets or sets a value indicating whether map t 9 inputs returns.
        /// </summary>
        public bool MapT9InputsReturns { get; set; }

        /// <summary>
        /// Gets or sets the map t 9 inputs out.
        /// </summary>
        public List<string> MapT9InputsOut { get; set; }

        /// <inheritdoc />
        public IInputProcessor<string, uint> CountInput { get; set; }

        /// <inheritdoc />
        public IInputProcessor<string, string> MessagesInput { get; set; }

        /// <inheritdoc />
        public IT9Mapper Mapper { get; set; }

        /// <inheritdoc />
        public bool MapT9Inputs(bool allowIncompleteResult, out List<string> results)
        {
            results = this.MapT9InputsOut;
            return this.MapT9InputsReturns;
        }
    }
}
