using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    public interface IInputProcessor<TSource, TConverted>
        where TSource : IConvertible
        where TConverted : IConvertible
    {
        bool Stopped { get; set; }

        Func<TSource> ReadStrategy { get; }

        IInputErrorHandler<TSource, TConverted> InputErrorHandler { get; }

        IValidator<TConverted> Validator { get; }

        bool Process(out TConverted processedResult);

        bool ProcessAll<TResult>(uint count, Func<TConverted, TResult> map, out List<TResult> results, bool allowIncompleteResult);
    }
}
