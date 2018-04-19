// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Mediator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Mediator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <summary>
    /// The t 9 helper.
    /// </summary>
    public class T9Mediator
    {
        /// <summary>
        /// The map t 9 inputs.
        /// </summary>
        /// <param name="countInput">
        /// The count input.
        /// </param>
        /// <param name="messagesInput">
        /// The messages Input.
        /// </param>
        /// <param name="allowIncompleteResult">
        /// The allow incomplete result.
        /// </param>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MapT9Inputs(IInputProcessor<string, uint> countInput, IInputProcessor<string, string> messagesInput, bool allowIncompleteResult, Func<string, string> map,out List<string> results)
        {
            results = null;
            try
            {
                return countInput.Process(out uint count) && messagesInput.ProcessAll(
                           count,
                           map,
                           out results,
                           allowIncompleteResult);
            }
            catch (Exception ex)
            {
                if (results != null && results.Count > 0 && allowIncompleteResult)
                {
                    return true;
                }
                else
                {
                    results = null;
                    return false;
                }
            }
        }
    }
}
