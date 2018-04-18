using System;
using InputServices;
using InputServicesTests.TestInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputServicesTests
{
    [TestClass]
    public class ProviderTests
    {
        [TestMethod]
        public void Provider_CreateInputProcessor_should_create()
        {
            var handler = new TestInputErrorHandler<string, string>((data) => { }, (data) => { });
            var validator = new TestValidator<string>((data) => true);
            var inputProcessor = Provider.CreateInputProcessor<string, string, string>(() => "", (x) => x, handler, validator);

            Assert.IsNotNull(inputProcessor);
        }
    }
}
