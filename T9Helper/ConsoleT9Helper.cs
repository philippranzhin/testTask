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
    using T9Helper.T9Service.Internal;

    /// <summary>
    /// The program.
    /// </summary>
    public class ConsoleT9Helper
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var helper = Init(new ServiceFactory(), Console.ReadLine, Console.WriteLine, "Invalid input");
            helper.Help(Console.WriteLine, true);
            Console.ReadLine();
        }

        /// <summary>
        /// The init.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="read">
        /// The read.
        /// </param>
        /// <param name="write">
        /// The write.
        /// </param>
        /// <param name="errMsg">
        /// The err Msg.
        /// </param>
        /// <returns>
        /// The <see cref="IT9Helper"/>.
        /// </returns>
        public static IT9Helper Init(IServiceFactory factory,Func<string> read, Action<string> write, string errMsg)
        {
            var mapper = factory.CreateMapper();

            var countErrorHandler = factory.CreateErrorHandler<string, uint>(() => write(errMsg));

            var countValidator = factory.CreateValidator(new Func<uint, bool>((input) => input >= 1 && input <= 100));

            var countInputProcessor = InputServices.Provider.CreateInputProcessor(
                read,
                countErrorHandler,
                countValidator);

            var messageErrorHandler = factory.CreateErrorHandler<string, string>(() => write(errMsg));

            List<Func<string, bool>> messageValidationConditions = new List<Func<string, bool>>(2)
                                                                       {
                                                                           new Func<string, bool>((input) => input.Length >= 1 && input.Length <= 1000),
                                                                           mapper.Contains
                                                                       };

            var messageValidator = factory.CreateValidator(messageValidationConditions);

            var messageInputProcessor = InputServices.Provider.CreateInputProcessor(
                read,
                messageErrorHandler,
                messageValidator);

            var mediator = factory.CreateMediator(countInputProcessor, messageInputProcessor, mapper);

            return factory.CreateHelper(mediator);
        }
    }
}
