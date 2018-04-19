// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T9Helper.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the T9Helper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The t 9 helper.
    /// </summary>
    public class T9Helper
    {
        public void Help(Func<string> read, Action<string> write)
        {
            var mapper = new T9Mapper();

            var countValidator =
                new T9InputValidator<uint>(new Func<uint, bool>((input) => input >= 1 && input <= 100));

            var countErrorHanlder = CreateErrorHandler<string, uint>();

            var countInput = InputServices.Provider.CreateInputProcessor(Console.ReadLine, countErrorHanlder, countValidator);

            List<Func<string, bool>> messageValidationConditions = new List<Func<string, bool>>(2)
                                                                       {
                                                                           new Func<string, bool>((input) => input.Length >= 1 && input.Length <= 1000),
                                                                           mapper.Contains
                                                                       };

            var messageValidator = new T9InputValidator<string>(messageValidationConditions);

            var messageErrorHanlder = CreateErrorHandler<string, string>();

            var messageInput = InputServices.Provider.CreateInputProcessor(read, messageErrorHanlder, messageValidator);

            var mediator = new T9Mediator();

            if (mediator.MapT9Inputs(countInput, messageInput, false, mapper.Map, out List<string> results))
            {
                int index = 1;
                foreach (var result in results)
                {
                    write($"Case #{index}: {result}");
                    index++;
                }

                read();
            }
            else
            {
                write("Incorrect input");
                read();
            }
        }

        /// <summary>
        /// The create error handler.
        /// </summary>
        /// <typeparam name="TSource">
        /// the source type
        /// </typeparam>
        /// <typeparam name="TConverted">
        /// the type to convert
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>T9InputErrorHandler</cref>
        ///     </see>
        ///     .
        /// </returns>
        private T9InputErrorHandler<TSource, TConverted> CreateErrorHandler<TSource, TConverted>()
        {
            return new T9InputErrorHandler<TSource, TConverted>((data) => throw new ArgumentException(), (data) => throw new ArgumentException());
        }
    }
}
