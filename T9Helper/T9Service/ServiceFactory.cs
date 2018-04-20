// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactory.cs" company="Philipp Ranzhin">
//   Philipp Ranzhin (C)
// </copyright>
// <summary>
//   Defines the ServiceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace T9Helper.T9Service
{
    using System;
    using System.Collections.Generic;

    using InputServices.InputProcessor;

    using T9Helper.T9Service.Internal;

    /// <inheritdoc />
    public class ServiceFactory : IServiceFactory
    {
        /// <inheritdoc />
        public IT9Mapper CreateMapper()
        {
            return new T9Mapper();
        }

        /// <inheritdoc />
        public IInputErrorHandler<TSource, TConverted> CreateErrorHandler<TSource, TConverted>(Action write)
        {
            return new T9InputErrorHandler<TSource, TConverted>((data) => write(), (data) => write());
        }

        /// <inheritdoc />
        public IValidator<TSource> CreateValidator<TSource>(Func<TSource, bool> condition)
        {
            return new T9InputValidator<TSource>(condition);
        }

        /// <inheritdoc />
        public IValidator<TSource> CreateValidator<TSource>(List<Func<TSource, bool>> conditions)
        {
            return new T9InputValidator<TSource>(conditions);
        }

        /// <inheritdoc />
        public IT9Mediator CreateMediator(IInputProcessor<string, uint> countProcessor, IInputProcessor<string, string> messageProcessor, IT9Mapper mapper)
        {
            return new T9Mediator(countProcessor, messageProcessor, mapper);
        }

        /// <inheritdoc />
        public IT9Helper CreateHelper(IT9Mediator mediator)
        {
            return new T9Helper(mediator);
        }
    }
}
