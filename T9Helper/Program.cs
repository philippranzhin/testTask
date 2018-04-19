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
            var helper = new T9Helper();
            helper.Help(Console.ReadLine, Console.WriteLine);
        }
    }
}
