using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            uint count = 0;
            Func<string> read = () => {
                count++;
                return "";
            };

            uint max = 10;

            var processor = InputServices.Provider.CreateInputProcessor(read, (d) => d, new x(max), new v());
            if (processor.Process(out int result))
            {
                Console.WriteLine(result);
            }
            Assert.AreEqual(count, max);
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
}
