// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMapper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the TestMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests.TestInfra
{
    using T9Helper.T9Service;

    /// <summary>
    /// The test mapper.
    /// </summary>
    public class TestMapper : IT9Mapper
    {
        /// <summary>
        /// Gets or sets a value indicating whether contains returns.
        /// </summary>
        public bool ContainsReturns { get; set; }

        /// <summary>
        /// Gets or sets the map returns.
        /// </summary>
        public string MapReturns { get; set; }

        /// <inheritdoc />
        public bool Contains(string data)
        {
            return this.ContainsReturns;
        }

        /// <inheritdoc />
        public string Map(string data)
        {
            return this.MapReturns;
        }
    }
}
