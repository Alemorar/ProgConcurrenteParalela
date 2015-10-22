using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelMaxDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadExample ex = new ThreadExample();
            Console.ReadLine();
        }

        public class ThreadExample
        {
            int limit = 400;

            public ThreadExample()
            {
                Console.WriteLine("Starting threads...");
                int temp = 0;
                Parallel.For(temp, limit, new ParallelOptions { MaxDegreeOfParallelism = 10 }, i =>
                {
                    DoWork(temp);
                    temp++;
                });
            }

            public void DoWork(int info)
            {
                //Thread.Sleep(50); //doing some work here. 
                int num = info * 5;
                Console.WriteLine("Thread: {0}      Result: {1}", info.ToString(), num.ToString());
            }
        }

    }
}
