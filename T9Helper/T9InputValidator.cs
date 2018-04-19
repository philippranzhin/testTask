using InputServices.InputProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    class T9InputValidator<TSource> : IValidator<TSource>
    {
        private List<Func<TSource, bool>> conditions;

        public T9InputValidator(List<Func<TSource, bool>> conditions)
        {
            this.conditions = conditions;
        }

        public T9InputValidator(Func<TSource, bool> condition)
        {
            this.conditions = new List<Func<TSource, bool>>() { condition };
        }

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
