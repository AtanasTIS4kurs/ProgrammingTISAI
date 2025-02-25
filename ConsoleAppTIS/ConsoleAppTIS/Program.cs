namespace ConsoleAppTIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Run(() => GetDataFromNet());
           // task1.Wait();
            Task task2 = Task.Run(() => GetDataFromData());
           // task2.Wait();
            Task task3 = Task.Run(() => GetDataFromCalc());
            //task2.Wait();
            Task.WaitAll(task1,task2,task3);
        }
        static void GetDataFromNet()
        {
            Console.WriteLine("Getting Data From Network");
            Thread.Sleep(6000);
            Console.WriteLine("Done1");
        }
        static void GetDataFromData()
        {
            Console.WriteLine("Getting Data From Database");
            Thread.Sleep(4000);
            Console.WriteLine("Done2");
        }
        static void GetDataFromCalc()
        {
            Console.WriteLine("Getting Data From Calculation");
            Thread.Sleep(2000);
            Console.WriteLine("Done3");
        }
    }
}
