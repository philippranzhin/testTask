// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9InputValidator.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9InputValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <inheritdoc />
    public class T9InputValidator<TSource> : IValidator<TSource>
    {
        /// <summary>
        /// The validation conditions.
        /// </summary>
        private readonly List<Func<TSource, bool>> conditions;

        /// <summary>
        /// Initializes a new instance of the <see cref="T9InputValidator{TSource}"/> class.
        /// </summary>
        /// <param name="conditions">
        /// The conditions.
        /// </param>
        public T9InputValidator(List<Func<TSource, bool>> conditions)
        {
            this.conditions = conditions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T9InputValidator{TSource}"/> class.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        public T9InputValidator(Func<TSource, bool> condition)
        {
            this.conditions = new List<Func<TSource, bool>>() { condition };
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Validate(TSource data)
        {
            foreach (var condition in this.conditions)
            {
                if (!condition(data))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
