// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9MediatorTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (C)
// </copyright>
// <summary>
//   Defines the T9MediatorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestInfra;

    /// <summary>
    /// The t 9 mediator tests.
    /// </summary>
    [TestClass]
    public class T9MediatorTests
    {
        /// <summary>
        /// The map t 9 inputs should returns true and set valid out parameters.
        /// </summary>
        [TestMethod]
        public void MapT9InputsShouldReturnsTrueAndSetValidOutParameters()
        {
            var expectedResults = new List<string>() { "result1", "result2" };

            var countInput = new TestInutProcessor<string, uint, uint>();
            countInput.ProcessOut = 2;
            countInput.ProcessReturns = true;

            var messagesInput = new TestInutProcessor<string, string, string>();
            messagesInput.ProcessAllOut = expectedResults;
            messagesInput.ProcessAllReturns = true;

            var mediator = TestServiceFactory.Factory.CreateMediator(countInput, messagesInput, new TestMapper());

            var success = mediator.MapT9Inputs(false, out List<string> results);

            Assert.IsTrue(success);
            Assert.AreEqual(expectedResults, results);
        }

        /// <summary>
        /// The map t 9 inputs should returns false and set valid out parameters.
        /// </summary>
        [TestMethod]
        public void MapT9InputsShouldReturnsFalseAndSetNullOutParameters()
        {
            var unexpectedResults = new List<string>() { "result1", "result2" };

            var countInput = new TestInutProcessor<string, uint, uint>();
            countInput.ProcessOut = 2;
            countInput.ProcessReturns = false;

            var messagesInput = new TestInutProcessor<string, string, string>();
            messagesInput.ProcessAllOut = unexpectedResults;
            messagesInput.ProcessAllReturns = true;

            var mediator = TestServiceFactory.Factory.CreateMediator(countInput, messagesInput, new TestMapper());

            var success = mediator.MapT9Inputs(false, out List<string> results);

            Assert.IsFalse(success);
            Assert.IsNull(results);
        }
    }
}
