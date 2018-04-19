// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputProcessorTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the InputProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServicesTests
{
    using InputServices;

    using InputServicesTests.TestInfra;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The input processor tests.
    /// </summary>
    [TestClass]
    public class InputProcessorTests
    {
        /// <summary>
        /// The handler.
        /// </summary>
        private readonly TestInputErrorHandler<string, string> errorHandler = new TestInputErrorHandler<string, string>((data) => { }, (data) => { });

        /// <summary>
        /// The provider process should return false and set default result.
        /// </summary>
        [TestMethod]
        public void ProviderProcessShouldReturnFalseAndSetDefaultResult()
        {
            var validator = new TestValidator<string>((data) => false);
            var inputProcessor = Provider.CreateInputProcessor<string, string>(() => string.Empty, this.errorHandler, validator);

            var processed = inputProcessor.Process(out string result);

            Assert.IsFalse(processed);
            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The provider process should return true and set correct result.
        /// </summary>
        [TestMethod]
        public void ProviderProcessShouldReturnTrueAndSetCorrectResult()
        {
            var handler = new TestInputErrorHandler<string, int>((data) => { }, (data) => { });

            var validator = new TestValidator<int>((data) => true);
            var expectedResult = 1;
            var inputProcessor = Provider.CreateInputProcessor<string, int>(() => "1", handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(processed);
            Assert.AreEqual(result, expectedResult);
        }

        /// <summary>
        /// The provider process should call convert error handler.
        /// </summary>
        [TestMethod]
        public void ProviderProcessShouldCallConvertErrorHandler()
        {
            bool called = false;
            var handler = new TestInputErrorHandler<string, int>((data) => { called = true; }, (data) => { });

            var validator = new TestValidator<int>((data) => true);
            var inputProcessor = Provider.CreateInputProcessor<string, int>(() => "invalid", handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(called);
        }

        /// <summary>
        /// The provider process should call validation error handler.
        /// </summary>
        [TestMethod]
        public void ProviderProcessShouldCallValidationErrorHandler()
        {
            bool called = false;
            var handler = new TestInputErrorHandler<int, int>((data) => { }, (data) => { called = true; });

            var validator = new TestValidator<int>((data) => false);
            var inputProcessor = Provider.CreateInputProcessor<int, int>(() => 1, handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(called);
        }
    }
}
