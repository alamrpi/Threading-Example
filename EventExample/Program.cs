namespace EventExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Producer producer = new();
            Consumer consumer = new();

            //create delegate object of Producer and Consumer class
            ThreadStart threadStart1 = new(producer.Produce);
            ThreadStart threadStart2 = new(consumer.Consume);

            //Create thread objects
            Thread produceThread = new(threadStart1) { 
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
