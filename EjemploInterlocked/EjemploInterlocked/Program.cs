using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjemploInterlocked
{
    class Program
    {
        static int _value = 6;

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(B));
            Thread thread2 = new Thread(new ThreadStart(B));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(Program._value);
            Console.ReadKey();

        }
        static void B()
        {
            // Add one then subtract two.
            Interlocked.Increment(ref Program._value);
            Interlocked.Decrement(ref Program._value);
            Interlocked.Decrement(ref Program._value);
        }
    }
}