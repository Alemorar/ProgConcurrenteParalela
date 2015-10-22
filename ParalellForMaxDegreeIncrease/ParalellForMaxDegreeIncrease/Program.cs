using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParalellForMaxDegreeIncrease
{
    class Program
    {
        static void Main(string[] args)
        {
            var locker = new Object();
            int count = 0;
            Stopwatch st1 = new Stopwatch();

            st1.Start();
            var parallelResult = Parallel.For
                (0
                 , 1000                 
                 , (i) =>
                 {
                     Interlocked.Increment(ref count);
                     lock (locker)
                     {
                         Console.WriteLine("Number of active threads:" + count);
                         Thread.Sleep(10);
                     }
                     Interlocked.Decrement(ref count);
                 }
                );
            while (parallelResult.IsCompleted == false) ;
            st1.Stop();
            Console.WriteLine("Tiempo Total:" + st1.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }
    }
}
