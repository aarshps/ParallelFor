using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();

            Console.ReadKey();
        }
    }

    internal class Engine
    {
        private readonly List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        internal void Run()
        {
            Parallel.ForEach(numbers, new ParallelOptions { MaxDegreeOfParallelism = 2 }, OutWithWait);
        }

        private void OutWithWait(int number)
        {
            WriteLineAsync(number).GetAwaiter().GetResult();
            Thread.Sleep(number * 1000);
            WriteLineAsync(number).GetAwaiter().GetResult();
        }

        private async Task WriteLineAsync(int number)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(number);
            });
        }
    }
}
