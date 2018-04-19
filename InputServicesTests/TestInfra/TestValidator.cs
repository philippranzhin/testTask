// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestValidator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the TestValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace InputServicesTests.TestInfra
{
    using System;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    public class TestValidator<TSource> : IValidator<TSource>
    {
        /// <summary>
        /// The validate strategy.
        /// </summary>
        private readonly Func<TSource, bool> validateStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestValidator{TSource}"/> class.
        /// </summary>
        /// <param name="validateStrategy">
        /// The validate strategy.
        /// </param>
        public TestValidator(Func<TSource, bool> validateStrategy)
        {
            this.validateStrategy = validateStrategy;
        }

        /// <inheritdoc />
        public bool Validate(TSource data)
        {
            return this.validateStrategy(data);
        }
    }
}
