// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputValidatorTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the InputValidatorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestInfra;

    /// <summary>
    /// The input validator tests.
    /// </summary>
    [TestClass]
    public class InputValidatorTests
    {
        /// <summary>
        /// The validate should returns false.
        /// </summary>
        [TestMethod]
        public void ValidateShouldReturnsFalse()
        {
            var validator = TestServiceFactory.Factory.CreateValidator<int>((data) => false);

            Assert.IsFalse(validator.Validate(1));
        }

        /// <summary>
        /// The validate should returns true.
        /// </summary>
        [TestMethod]
        public void ValidateShouldReturnsTrue()
        {
            var validator = TestServiceFactory.Factory.CreateValidator<int>((data) => true);

            Assert.IsTrue(validator.Validate(1));
        }
    }
}
