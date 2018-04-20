// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9HelperTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9HelperTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TestInfra;

    /// <summary>
    /// The t 9 helper tests.
    /// </summary>
    [TestClass]
    public class T9HelperTests
    {
        /// <summary>
        /// The help shold returns true and write results.
        /// </summary>
        [TestMethod]
        public void HelpSholdReturnsTrueAndWriteResults()
        {
            var expected = "Case #1: r1Case #2: r2";

            var mediator = new TestMediator();
            mediator.MapT9InputsReturns = true;
            mediator.MapT9InputsOut = new List<string>() { "r1", "r2" };

            var helper = TestServiceFactory.Factory.CreateHelper(mediator);
            var outresult = string.Empty;

            var result = helper.Help((data) => outresult += data, true);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, outresult);
        }

        /// <summary>
        /// The help shold returns true and write results.
        /// </summary>
        [TestMethod]
        public void HelpSholdReturnsFalseAndNotWriteResults()
        {
            var wrote = false;

            var mediator = new TestMediator();
            mediator.MapT9InputsReturns = false;
            mediator.MapT9InputsOut = new List<string>() { "r1", "r2" };

            var helper = TestServiceFactory.Factory.CreateHelper(mediator);

            var result = helper.Help((data) => wrote = true, true);

            Assert.IsFalse(result);
            Assert.IsFalse(wrote);
        }
    }
}
