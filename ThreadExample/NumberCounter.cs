using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample
{
    public class NumberCounter
    {
        public void CounterUp()
        {
            try {
                Console.WriteLine("Count up is started------>");
                Thread.Sleep(1000);
                for (int i = 1; i <= 100; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i = {i}, ");
                    //Thread.Sleep(100);
                }

                Thread.Sleep(1000);
                Console.WriteLine("Count up is stopped->");

            } catch(ThreadInterruptedException ex)
            {
                Console.WriteLine("Count up thread is interrupt.");
            }
           
        }

        public void CounterDown()
        {
            Console.WriteLine("Count down is started------>");
            Thread.Sleep(1000);

            for (int j = 100; j >= 1; j--)
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
