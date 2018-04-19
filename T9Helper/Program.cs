// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using InputServices.InputProcessor;

    using T9Helper.T9Service;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var helper = Init();
            helper.Help(Console.WriteLine, true);
            Console.ReadLine();
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <returns>
        /// The <see cref="IT9Helper"/>.
        /// </returns>
        private static IT9Helper Init()
        {
            var mapper = new T9Mapper();

            var countErrorHandler = new T9InputErrorHandler<string, uint>((data) => Console.WriteLine("incorrect input"), (data) => Console.WriteLine("incorrect input"));

            var countValidator =
                new T9InputValidator<uint>(new Func<uint, bool>((input) => input >= 1 && input <= 100));

            var countInputProcessor = InputServices.Provider.CreateInputProcessor(
                Console.ReadLine,
                countErrorHandler,
                countValidator);

            var messageErrorHandler = new T9InputErrorHandler<string, string>((data) => Console.WriteLine("incorrect input"), (data) => Console.WriteLine("incorrect input"));

            List<Func<string, bool>> messageValidationConditions = new List<Func<string, bool>>(2)
                                                                       {
                                                                           new Func<string, bool>((input) => input.Length >= 1 && input.Length <= 1000),
                                                                           mapper.Contains
                                                                       };

            var messageValidator = new T9InputValidator<string>(messageValidationConditions);

            var messageInputProcessor = InputServices.Provider.CreateInputProcessor(
                Console.ReadLine,
                messageErrorHandler,
                messageValidator);

            var mediator = new T9Mediator(countInputProcessor, messageInputProcessor, mapper);

            return new T9Helper(mediator);
        }
    }
}
