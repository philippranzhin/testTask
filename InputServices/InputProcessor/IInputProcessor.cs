using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    public interface IInputProcessor<TSource, TConverted,TResult> 
        where TSource:  IConvertible
        where TConverted: IConvertible
    {
        Func<TSource> ReadStrategy { get; }

        Func<TConverted, TResult> Mapper { get; }

        IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; }

        IValidator<TConverted> Validator { get; }

        bool Process(out TResult processedResult);
    }
}
