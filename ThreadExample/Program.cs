using ThreadExample.CallbackInThread;
using ThreadExample.CustomThread;
using ThreadExample.ParameterizedThread;
using ThreadExample.ThreadSyncronization;

namespace ThreadExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainThread = Thread.CurrentThread;
            mainThread.Name = "main";

            ////Multithread Example
            //MultiThreadExample.ExecuteThread();

            ////Parameterized thread
            //ParameterizedThreadExample.ExecuteThread();

            ////Custom Thread 
            //CustomThreadExample.ExecuteThread();

            ////Callback example
            //CallbackExample.ExecuteThread();

            //Thread Syncronization example
            ThreadSyncronizationExample.ExecuteThread();

            //Complete the main thread
            Console.WriteLine("Complated main thread");

        }
    }
}
