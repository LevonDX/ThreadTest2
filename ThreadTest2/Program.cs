namespace ThreadTest2
{
    internal class Program
    {
       
        static void F1()
        {
            long s = 0;
            for (int i = 0; i < 1E10; i++)
            {
                Console.WriteLine("F1");
                Thread.Sleep(500);
            }
        }

        static void F2()
        {
            long s = 0;
            for (int i = 0; i < 1E10; i++)
            {
                Console.WriteLine("F2");
                Thread.Sleep(500);
            }
        }

        static void Main()
        {
            Thread t1 = new Thread(F1);
            Thread t2 = new Thread(F2);

            Console.WriteLine("F1 started");
            t1.Start();

            Console.WriteLine("F2 started");
            t2.Start();

            Console.WriteLine("F2 finished");
        }
    }
}