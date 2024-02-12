using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadExample.ThreadSyncronization
{
    public class ThreadSyncronizationExample
    {
        public static void ExecuteThread()
        {
            //Object of number counter
            NumberUpCounter numberUp = new()
            {
                Count = 100
            };

            //First thread start delegate
            ThreadStart countUpThread = new(() =>
            {
                numberUp.CounterUp((sum) =>
                {
                    Console.WriteLine($"Counter up sum is = {sum}");
                });
            });
            //Initialize thread 
            Thread thread1 = new(countUpThread)
            {
                Name = "Count-up Thread"
            };
            //Check the thread state
            Console.WriteLine($"{thread1.Name} ({thread1.ManagedThreadId}) is {thread1.ThreadState}");
            //Invok countUp method
            thread1.Start();
            //Check the thread state
            Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}");

            //Second thread start delegate
            NumberDownCounter numberDownCounter = new()
            {
                Count = 100
            };
            ThreadStart countDownThread = new(numberDownCounter.CounterDown);

            //Initialize thread 
            Thread thread2 = new(countDownThread)
            {
                Name = "Count-down Thread"
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

            //Shared resource print
            Console.WriteLine($"Shared resource is = {Shared.SharedResource}"); //Expected as 0
        }
    }
}
