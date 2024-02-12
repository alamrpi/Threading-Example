namespace ThreadExample.CustomThread
{
    public class NumberUpCounter
    {
        public int Count { get; set; }
        public void CounterUp()
        {
            try
            {
                Console.WriteLine("Count up is started------>");
                Thread.Sleep(1000);

                for (int i = 1; i <= Count; i++)
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
    }
    public class NumberDownCounter
    {
        public int Count { get; set; }
        public void CounterDown()
        {
            Console.WriteLine("Count down is started------>");
            Thread.Sleep(1000);

            for (int j = Count; j >= 1; j--)
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
