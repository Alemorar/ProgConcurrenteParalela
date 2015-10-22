using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] itemList = new int[10];

            Stopwatch st1 = new Stopwatch();
            st1.Start();
            //bucle for comun
            for (int i = 0; i < itemList.Count(); i++)
            {
                itemList[i] += (int)Math.Cos(i);
            }
            st1.Stop();
            Console.WriteLine("Tiempo bucle for comun (ns):" + st1.Elapsed.TotalMilliseconds );

            Stopwatch st2 = new Stopwatch();
            st2.Start();
            //bucle for parallel
            var parallelResult = Parallel.For(0, itemList.Count(), (i) =>
                {
                    itemList[i] += (int)Math.Cos(i);
                });

            while (parallelResult.IsCompleted == false) ;
            st2.Stop();
            Console.WriteLine("Tiempo parallel For (ns):" + st2.Elapsed.TotalMilliseconds );
            Console.ReadLine();
        }
    }
}
