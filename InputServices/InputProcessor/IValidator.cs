using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputServices.InputProcessor
{
    public interface IValidator<TSource>
    {
        bool Validate(TSource data);
    }
}
