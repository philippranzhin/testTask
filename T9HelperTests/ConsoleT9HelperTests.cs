﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleT9HelperTests.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the UnitTest1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using T9Helper;
    using T9Helper.T9Service;

    /// <summary>
    /// The console t 9 helper tests.
    /// </summary>
    [TestClass]
    public class ConsoleT9HelperTests
    {
        /// <summary>
        /// The init should create helper.
        /// </summary>
        [TestMethod]
        public void InitShouldCreateHelper()
        {
            Assert.IsNotNull(ConsoleT9Helper.Init(new ServiceFactory(), () => string.Empty, (d) => { }, string.Empty));
        }
    }
}
