using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjemploInterlocked
{
    class Program
    {
        static int _value;

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(A));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(Program._value);
            Console.ReadKey();

        }
        static void A()
        {
            // Add one then subtract two.
            Interlocked.Increment(ref Program._value);
            Interlocked.Decrement(ref Program._value);
            Interlocked.Decrement(ref Program._value);
        }
    }
}
