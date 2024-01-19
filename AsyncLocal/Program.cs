namespace AsyncLocalExample
{
    public static class AsyncLocal
    {
        static AsyncLocal<int> asyncLocalInt = new AsyncLocal<int>();

        public static async Task Main(string[] args)
        {
            asyncLocalInt.Value = 5;
            await RunAsyncCalls();

            Console.WriteLine("Press Return to finish");
            Console.ReadLine();
        }

        static async Task RunAsyncCalls()
        {
            Console.WriteLine($"Starting run. Async Local is {asyncLocalInt.Value}");

            await AsyncMethod1();

            Console.WriteLine($"Mid run. Async Local is {asyncLocalInt.Value}");

            await AsyncMethod2();

            Console.WriteLine($"End of run. Async Local is {asyncLocalInt.Value}");
        }

        static async Task AsyncMethod1()
        {
            Console.WriteLine($"\tStart of AsyncMethod1, Async Local is {asyncLocalInt.Value}");
            asyncLocalInt.Value = 15;
            Console.WriteLine($"\tMid of AsyncMethod1, Async Local is {asyncLocalInt.Value}");
            Thread.Sleep(1000);
            Console.WriteLine($"\tEnd of AsyncMethod1, Async Local is {asyncLocalInt.Value}");
        }

        static async Task AsyncMethod2()
        {
            Console.WriteLine($"\tStart of AsyncMethod2, Async Local is {asyncLocalInt.Value}");
            asyncLocalInt.Value = 214;
            Console.WriteLine($"\tMid of AsyncMethod2, Async Local is {asyncLocalInt.Value}");
            Thread.Sleep(100);
            Console.WriteLine($"\tEnd of AsyncMethod2, Async Local is {asyncLocalInt.Value}");
        }
    }
}