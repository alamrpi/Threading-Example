using System.Collections.Concurrent;

namespace ConcurrentCollectionExample
{
    public class Shared
    {
        public static ConcurrentQueue<int> Buffer = new(); //Buffer to store in data value
        public const int BufferCount = 5;

        public static ManualResetEvent ProducerEvent = new(true);
        public static ManualResetEvent ConsumerEvent = new(false);

        public static void Print()
        {
            Console.WriteLine("Buffer: ");
            foreach (var item in Buffer)
                Console.WriteLine($"{item}, ");
            Console.WriteLine();
        }

    }

    public class Producer
    {
        public void Produce()
        {
            Console.WriteLine("Producer: Generating Data");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Producer: Generating data");
                Thread.Sleep(7000);
                if (Shared.Buffer.Count == Shared.BufferCount)
                {
                    Console.WriteLine("Buffer is full. Waiting for signal from consumer.");
                   Shared.ProducerEvent.Reset();
                }
                Shared.ProducerEvent.WaitOne();
                Shared.Buffer.Enqueue(i);
                Console.WriteLine($"Producer produce: {i}");
                Shared.Print();
                Shared.ConsumerEvent.Set();
            }
            Console.WriteLine("Production Completed");
        }
    }

    public class Consumer
    {
        public void Consume()
        {
            Console.WriteLine("Consumer Started");
            for (int i = 0; i < Shared.BufferCount; i++)
            {
                if (Shared.Buffer.Count == 0)
                {
                    Console.WriteLine("Buffer is empty: Waiting for signal from producer");
                    Shared.ConsumerEvent.Reset();
                }

                Shared.ConsumerEvent.WaitOne();
                Console.WriteLine("Consumer: Proccesing Data");
                Thread.Sleep(2500); // 2.5 second

                bool isSuccess = Shared.Buffer.TryDequeue(out int val);
                if (isSuccess)
                {
                    Console.WriteLine($"Consumer consumed: {val}");
                }

                //Signal the producer that there is a space in the buffer
                Shared.ProducerEvent.Set();
            }

            Console.WriteLine("Consumption Completed");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Producer producer = new();
            Consumer consumer = new();

            //create delegate object of Producer and Consumer class
            ThreadStart threadStart1 = new(producer.Produce);
            ThreadStart threadStart2 = new(consumer.Consume);

            //Create thread objects
            Thread produceThread = new(threadStart1)
            {
                Name = "Producer thread"
            };
            Thread consumeThread = new(threadStart2)
            {
                Name = "Consumer thread"
            };

            //Start threads
            produceThread.Start();
            consumeThread.Start();

            //Join both threads to main thread
            produceThread.Join();
            consumeThread.Join();

        }
    }
}
