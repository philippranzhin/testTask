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
            var inputProcessor = Provider.CreateInputProcessor<string, string>(() => "", this.handler, validator);

            var processed = inputProcessor.Process(out string result);

            Assert.IsFalse(processed);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void Provider_Process_should_return_true_and_set_correct_result()
        {
            var handler = new TestInputErrorHandler<string, int>((data) => { }, (data) => { });

            var validator = new TestValidator<int>((data) => true);
            var expectedResult = 1;
            var inputProcessor = Provider.CreateInputProcessor<string, int>(() => "1", handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(processed);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Provider_Process_should_call_convert_error_handler()
        {
            bool called = false;
            var handler = new TestInputErrorHandler<string, int>((data) => { called = true; }, (data) => { });

            var validator = new TestValidator<int>((data) => true);
            var inputProcessor = Provider.CreateInputProcessor<string, int>(() => "invalid", handler, validator);

            var processed = inputProcessor.Process(out int result);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void Provider_Process_should_call_validation_error_handler()
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
