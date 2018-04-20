// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorHandlerTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the ErrorHandlerTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestInfra;

    /// <summary>
    /// The error handler tests.
    /// </summary>
    [TestClass]
    public class ErrorHandlerTests
    {
        /// <summary>
        /// The handle error should call strategy.
        /// </summary>
        [TestMethod]
        public void HandleErrorShouldCallStrategy()
        {
            bool called = false;
            var handler = TestServiceFactory.Factory.CreateErrorHandler<string, int>(() => { called = true; });

            handler.HandleError(1);

            Assert.IsTrue(called);
        }
    }
}
