// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the ProviderTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServicesTests
{
    using InputServices;

    using InputServicesTests.TestInfra;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The provider tests.
    /// </summary>
    [TestClass]
    public class ProviderTests
    {
        /// <summary>
        /// The provider_ create input processor_should_create.
        /// </summary>
        [TestMethod]
        public void ProviderCreateInputProcessorShouldCreate()
        {
            var handler = new TestInputErrorHandler<string, string>((data) => { }, (data) => { });
            var validator = new TestValidator<string>((data) => true);
            var inputProcessor = Provider.CreateInputProcessor<string, string>(() => string.Empty, handler, validator);

            Assert.IsNotNull(inputProcessor);
        }
    }
}
