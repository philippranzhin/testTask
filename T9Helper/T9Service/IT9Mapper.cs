// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IT9Mapper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   Defines the IT9Mapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System.Collections.Generic;

    /// <summary>
    /// The T9Mapper interface.
    /// </summary>
    public interface IT9Mapper
    {
        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Contains(string data);

        /// <summary>
        /// The map.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        ///     throw if there is not map for the <param name="data"/>
        /// </exception>
        string Map(string data);
    }
}
