// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Helper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Helper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <summary>
    /// The t 9 helper.
    /// </summary>
    public class T9Helper
    {
        /// <summary>
        /// The map t 9 inputs.
        /// </summary>
        /// <param name="countInput">
        /// The count input.
        /// </param>
        /// <param name="t9Input">
        /// The t 9 input.
        /// </param>
        /// <param name="allowIncompleteResult">
        /// The allow incomplete result.
        /// </param>
        /// <param name="t9Map">
        /// The t 9 map.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MapT9Inputs(IInputProcessor<string, uint> countInput, IInputProcessor<string, string> t9Input, bool allowIncompleteResult, Func<string, string> t9Map,out List<string> results)
        {
            results = null;

            return countInput.Process(out uint count) && t9Input.ProcessAll(count, t9Map, out results, allowIncompleteResult);
        }
    }
}
