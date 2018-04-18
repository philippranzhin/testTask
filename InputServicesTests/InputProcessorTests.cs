using System;
using InputServices;
using InputServicesTests.TestInfra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputServicesTests
{
    [TestClass]
    public class InputProcessorTests
    {
        private TestInputErrorHandler<string, string> handler = new TestInputErrorHandler<string, string>((data) => { }, (data) => { });

        [TestMethod]
        public void Provider_Process_should_return_false_and_set_default_result()
        {
            var validator = new TestValidator<string>((data) => false);
            var inputProcessor = Provider.CreateInputProcessor<string, string, string>(() => "", (x) => x, this.handler, validator);

            var processed = inputProcessor.Process(out string result);

            Assert.IsFalse(processed);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void Provider_Process_should_return_true_and_set_result()
        {
            var validator = new TestValidator<string>((data) => true);
            var expectedResult = "expectedResult";
            var inputProcessor = Provider.CreateInputProcessor<string, string, string>(() => "", (x) => expectedResult, this.handler, validator);

            var processed = inputProcessor.Process(out string result);

            Assert.IsTrue(processed);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Provider_Process_should_return_true_and_set_correct_result()
        {
            var handler = new TestInputErrorHandler<string, int>((data) => { }, (data) => { });

            var validator = new TestValidator<int>((data) => true);
            var expectedResult = 1;
            var inputProcessor = Provider.CreateInputProcessor<string, int, int>(() => "1", (x) => x, handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(processed);
            Assert.AreEqual(result, expectedResult);
        }
    }
}
