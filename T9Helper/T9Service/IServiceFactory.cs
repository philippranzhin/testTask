// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceFactory.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (c)
// </copyright>
// <summary>
//   Defines the IServiceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    /// <summary>
    /// The ServiceFactory interface.
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// The create mapper.
        /// </summary>
        /// <returns>
        /// The <see cref="IT9Mapper"/>.
        /// </returns>
        IT9Mapper CreateMapper();

        /// <summary>
        /// The create error handler.
        /// </summary>
        /// <param name="write">
        /// The write.
        /// </param>
        /// <typeparam name="TSource">
        /// the source type
        /// </typeparam>
        /// <typeparam name="TConverted">
        /// the type to convert
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>IInputErrorHandler</cref>
        ///     </see>
        ///     .
        /// </returns>
        IInputErrorHandler<TSource, TConverted> CreateErrorHandler<TSource, TConverted>(Action write);

        /// <summary>
        /// The create validator.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <typeparam name="TSource">
        /// the type to validate
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>IValidator</cref>
        ///     </see>
        ///     .
        /// </returns>
        IValidator<TSource> CreateValidator<TSource>(Func<TSource, bool> condition);

        /// <summary>
        /// The create validator.
        /// </summary>
        /// <param name="conditions">
        /// The condition.
        /// </param>
        /// <typeparam name="TSource">
        /// the type to validate
        /// </typeparam>
        /// <returns>
        /// The <see>
        ///         <cref>IValidator</cref>
        ///     </see>
        ///     .
        /// </returns>
        IValidator<TSource> CreateValidator<TSource>(List<Func<TSource, bool>> conditions);

        /// <summary>
        /// The create mediator.
        /// </summary>
        /// <param name="countProcessor">
        /// The count processor.
        /// </param>
        /// <param name="messageProcessor">
        /// The message processor.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        /// <returns>
        /// The <see cref="IT9Mediator"/>.
        /// </returns>
        IT9Mediator CreateMediator(IInputProcessor<string, uint> countProcessor, IInputProcessor<string, string> messageProcessor, IT9Mapper mapper);

        /// <summary>
        /// The create helper.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <returns>
        /// The <see cref="IT9Helper"/>.
        /// </returns>
        IT9Helper CreateHelper(IT9Mediator mediator);
    }
}
