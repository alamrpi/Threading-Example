namespace ThreadExample.ParameterizedThread
{
    public class ParameterizedThreadExample
    {
        public static void ExecuteThread()
        {
            //Object of number counter
            NumberCounter counter = new();

            //First thread start delegate
            ParameterizedThreadStart countUpThread = new(counter.CounterUp);
            //Initialize thread 
            Thread thread1 = new(countUpThread)
            {
                Name = "Count-up Thread",
                Priority = ThreadPriority.Highest
            };
            //Check the thread state
            Console.WriteLine($"{thread1.Name} ({thread1.ManagedThreadId}) is {thread1.ThreadState}");
            //Invok countUp method
            MaxCount maxCount = new() { Count = 150 };
            thread1.Start(maxCount);
            //Check the thread state
            Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}");

            //Second thread start delegate
            //ThreadStart countDownThread = new(counter.CounterDown);
            ParameterizedThreadStart countDownThread = new(counter.CounterDown);

            //Initialize thread 
            Thread thread2 = new(countDownThread)
            {
                Name = "Count-down Thread",
                Priority = ThreadPriority.Normal
            };
            //Check the thread state
            Console.WriteLine($"{thread2.Name} ({thread2.ManagedThreadId}) is {thread2.ThreadState}");

            //Invok countDown method
            MaxCount maxCount1 = new() { Count = 150};
            thread2.Start(maxCount1);
            //Check the thread state
            Console.WriteLine($"{thread2.Name} is {thread2.ThreadState}");

            //Join
            thread1.Join();
            thread2.Join();
        }
    }
}
