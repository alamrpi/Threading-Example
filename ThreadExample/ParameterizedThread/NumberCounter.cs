using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample.ParameterizedThread
{
    public class MaxCount
    {
        public int Count { get; set; }
    }
    public class NumberCounter
    {
        public void CounterUp(object? obj)
        {
            try
            {
                Console.WriteLine("Count up is started------>");
                Thread.Sleep(1000);

                var maxCount = (MaxCount?)obj;
                if (maxCount is null) return;

                for (int i = 1; i <= maxCount.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i = {i}, ");
                    //Thread.Sleep(100);
                }

                Thread.Sleep(1000);
                Console.WriteLine("Count up is stopped->");

            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine("Count up thread is interrupt.");
            }

        }

        public void CounterDown(object? obj)
        {
            Console.WriteLine("Count down is started------>");
            Thread.Sleep(1000);

            var maxCount = (MaxCount?)obj;
            if (maxCount is null) return;

            for (int j = maxCount.Count; j >= 1; j--)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"j = {j}, ");
                //Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Count down is stopped->");
        }
    }
}
