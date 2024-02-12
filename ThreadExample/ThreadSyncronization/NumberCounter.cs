namespace ThreadExample.ThreadSyncronization
{
    public static class Shared
    {
        public static int SharedResource { get; set; } = 0;
        public static readonly object objectLock  = new();
    }
    public class NumberUpCounter
    {
        public int Count { get; set; }

        public void CounterUp(Action<long> callBack)
        {
            int sum = 0;
            try
            {
                Console.WriteLine("Count up is started------>");
                Thread.Sleep(1000);

                for (int i = 1; i <= Count; i++)
                {
                    ////Using monitor synchronizations
                    //Monitor.Enter(Shared.objectLock); // Wait for the lock gets opened
                    //Shared.SharedResource++;
                    //Monitor.Exit(Shared.objectLock); // closed or realeased 

                    //Thread synchronizations using lock statement
                    lock (Shared.objectLock)
                    {
                        Shared.SharedResource++;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"i = {i}, ");
                    sum += i;
                    //Thread.Sleep(100);
                }

                Thread.Sleep(1000);
                Console.WriteLine("Count up is stopped---->");

            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine("Count up thread is interrupt.");
            }
            finally
            {
                callBack(sum);
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

                //Using monitor synchronizations
                //Monitor.Enter(Shared.objectLock); // Wait for the lock gets opened
                //Shared.SharedResource--;
                //Monitor.Exit(Shared.objectLock); // closed or realeased 

                //Thread synchronizations using lock statement
                lock (Shared.objectLock)
                {
                    Shared.SharedResource--;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"j = {j}, ");
                //Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Count down is stopped---->");
        }
    }
}
