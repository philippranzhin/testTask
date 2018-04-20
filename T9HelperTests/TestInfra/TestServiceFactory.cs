// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestServiceFactory.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the TestServiceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9HelperTests.TestInfra
{
    using T9Helper.T9Service;

    /// <summary>
    /// The test service factory.
    /// </summary>
    public class TestServiceFactory
    {
        /// <summary>
        /// Gets the factory.
        /// </summary>
        public static IServiceFactory Factory => new ServiceFactory();
    }
}
