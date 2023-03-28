using System.Diagnostics;
using System.Threading;
using ThreadState = System.Threading.ThreadState;

namespace ThreadTest2
{
    internal class Program
    {
        const long max = (long)1E9;
        long parSum = 0;

        long SerialSum()
        {
            long s = 0;
            for (long i = 0; i < max; i++)
            {
                s += i;
            }

            return s;
        }

        void F(long start, long end)
        {
            // sum of start to end
            for (long i = start; i < end; i++)
            {
                parSum += i;
            }
        }

        static void Main()
        {
            Program p = new Program();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            long result = p.SerialSum();
            sw.Stop();

            Console.WriteLine($"Serial sum = {sw.ElapsedMilliseconds}");

            ///////////////////////////////
            
            sw.Reset();

            sw.Start();

            Thread t1 = new Thread(() => p.F(0, max / 5));
            Thread t2 = new Thread(() => p.F(max / 5, max / 5 * 2));
            Thread t3 = new Thread(() => p.F(max / 5 * 2, max / 5 * 3));
            Thread t4 = new Thread(() => p.F(max / 5 * 3, max / 5 * 4));
            Thread t5 = new Thread(() => p.F(max / 5 * 4, max));

            t1.Start();

            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            while (t1.ThreadState == ThreadState.Running ||
                t2.ThreadState == ThreadState.Running ||
                    t3.ThreadState == ThreadState.Running ||
                    t4.ThreadState == ThreadState.Running ||
                    t5.ThreadState == ThreadState.Running) ;
          

            sw.Stop();

            Console.WriteLine($"Parallel sum = {sw.ElapsedMilliseconds}, result = {p.parSum}");
        }
    }
}