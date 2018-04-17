using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = InputServices.Provider.CreateInputProcessor(Console.ReadLine, (d) => d, new x(99906), new v());
            if (processor.Process(out int result))
            {
                Console.WriteLine(result);
            }
            if (processor.Process(out int result1))
            {
                Console.WriteLine(result1);
            }
        }
    }

    class x : InputServices.InputProcessor.IInputErrorHandler<string, int>
    {
        public uint MaxCount { get; private set; }

        public uint Count { get; private set; } = 0;

        public x(uint max)
        {
            this.MaxCount = max;
        }

        public bool ShouldRetry => this.Count < this.MaxCount;

        public void HandleError(int data)
        {
            this.Count++;
            if (this.ShouldRetry)
            {
                Console.WriteLine($"{data} - is invalid parameter. Try again");
            }
        }

        public void HandleError(string data)
        {
            this.Count++;
            Console.WriteLine($"{data} - is invalid parameter. Try again (you have {this.MaxCount - this.Count} tryings)");
        }
    }

    class v : InputServices.InputProcessor.IValidator<int>
    {
        public bool Validate(int data)
        {
            return true;
        }
    }
}
