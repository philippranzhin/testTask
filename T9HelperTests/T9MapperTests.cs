// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9MapperTests.cs" company="Philiipp Ranzhin">
//   Philiipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9MapperTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestInfra;

    /// <summary>
    /// The t 9 mapper tests.
    /// </summary>
    [TestClass]
    public class T9MapperTests
    {
        /// <summary>
        /// The contains should returns true.
        /// </summary>
        [TestMethod]
        public void ContainsShouldReturnsTrue()
        {
            var mapper = TestServiceFactory.Factory.CreateMapper();
            var validMessage = "valid message";

            Assert.IsTrue(mapper.Contains(validMessage));
        }

        /// <summary>
        /// The contains should returns fals.
        /// </summary>
        [TestMethod]
        public void ContainsShouldReturnsFalse()
        {
            var mapper = TestServiceFactory.Factory.CreateMapper();
            var invalidMessage = "Invalid message";

            Assert.IsFalse(mapper.Contains(invalidMessage));
        }

        /// <summary>
        /// The map should returns found result.
        /// </summary>
        [TestMethod]
        public void MapShouldReturnsFoundResult()
        {
            var mapper = TestServiceFactory.Factory.CreateMapper();
            var message = "foo  bar";

            Assert.AreEqual(mapper.Map(message), "333666 6660 022 2777");
        }

        /// <summary>
        /// The map should throw key not found exception.
        /// </summary>
        [TestMethod]
        public void MapShouldThrowKeyNotFoundException()
        {
            var mapper = TestServiceFactory.Factory.CreateMapper();
            var message = "INVALID";

            Assert.ThrowsException<KeyNotFoundException>(() => mapper.Map(message));
        }
    }
}
