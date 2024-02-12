using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    public class Shared
    {
        public static int[] Data { get; set; } //Store data values
        public static int DataCount { get; set; } // Total Number of values
        public static int BatchCount { get; set; }
        public static int BatchSize { get; set; }

        public static ManualResetEvent Event { get; set; }
        static Shared()
        {
            Data = new int[15];
            DataCount = Data.Length;
            BatchCount = 5;
            BatchSize = 3;
            Event = new ManualResetEvent(false); //Unsignled state
        }
    }

    //Re-present producer thread
    class Producer
    {
        public void Produce()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Started.");

            //Generate some data nad store it in the data array
            for ( int i = 0; i < Shared.BatchCount; i++)
            {
                for (int j = 0; j < Shared.BatchSize; j++)
                {
                    Shared.Data[i * Shared.BatchSize + j] = (i * Shared.BatchSize) + j + 1;
                    Thread.Sleep(300); //simular artificial latency (delay)
                }

                //Set the signal (Signal that the producer has finished generating data)
                Shared.Event.Set();

                //Reset the signal (makes the consumer thread wait for signal before reading next batch)
                Shared.Event.Reset();
            }

           
            Console.WriteLine($"{Thread.CurrentThread.Name} completed.");
        }
    }

    //Represent consumer thread
    class Consumer
    {
        public void Consume()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Started.");

            Console.WriteLine("Consumer thread is waiting for producer thread to finished generating data:::::::::::::::::-->");
            for (int i = 0; i < Shared.BatchCount; i++)
            {
                Shared.Event.WaitOne(); //consumer thread waits until the status of event become signaled.
                Console.WriteLine("Consumer has received a signal from producer:::::::::::::::::-->");
                //Read data
                Console.WriteLine("Data is ----->");
                for (int j = 0; j < Shared.BatchSize; j++)
                {
                    Console.WriteLine(Shared.Data[Shared.BatchSize * i + j]);
                }
            }
           
           
            Console.WriteLine($"{Thread.CurrentThread.Name} completed.");
        }
    }
}
