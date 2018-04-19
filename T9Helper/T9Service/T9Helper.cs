// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Helper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Helper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;
    using System.Collections.Generic;

    /// <inheritdoc />
    public class T9Helper : IT9Helper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T9Helper"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public T9Helper(IT9Mediator mediator)
        {
            this.T9Mediator = mediator;
        }

        /// <inheritdoc />
        public IT9Mediator T9Mediator { get; }

        /// <inheritdoc />
        public bool Help(Action<string> write, bool allowIncompleteResult)
        {
            if (this.T9Mediator.MapT9Inputs(allowIncompleteResult, out List<string> results))
            {
                int index = 1;
                foreach (var result in results)
                {
                    write($"Case #{index}: {result}");
                    index++;
                }

                return true;
            }

            return false;
        }
    }
}
