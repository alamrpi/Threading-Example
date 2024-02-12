using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample
{
    public class MultiThreadExample
    {
        public static void ExecuteThread()
        {
            //Object of number counter
            NumberCounter counter = new();

            //First thread start delegate
            ThreadStart countUpThread = new(counter.CounterUp);
            //Initialize thread 
            Thread thread1 = new(countUpThread)
            {
                Name = "Count-up Thread",
                Priority = ThreadPriority.Highest
            };
            //Check the thread state
            Console.WriteLine($"{thread1.Name} ({thread1.ManagedThreadId}) is {thread1.ThreadState}");
            //Invok countUp method
            thread1.Start();
            //Check the thread state
            Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}");

            //Second thread start delegate
            //ThreadStart countDownThread = new(counter.CounterDown);
            ThreadStart countDownThread = new(() =>
            {
                counter.CounterDown();
            }); //Parameterized thread 

            //Initialize thread 
            Thread thread2 = new(countDownThread)
            {
                Name = "Count-down Thread",
                Priority = ThreadPriority.Normal
            };
            //Check the thread state
            Console.WriteLine($"{thread2.Name} ({thread2.ManagedThreadId}) is {thread2.ThreadState}");
            //Invok countDown method
            thread2.Start();
            //Check the thread state
            Console.WriteLine($"{thread2.Name} is {thread2.ThreadState}");

            //Join
            thread1.Join();
            thread2.Join();

            //Interrupt
            //Thread.Sleep(1000);
            //thread1.Interrupt();
        }
    }
}
