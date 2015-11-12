using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPunto2
{
    class Program

    {
        //static int _value;
        
        static int[] array = new int[1001];
        static Object lockObj = new Object();
        

        static void Main(string[] args)
        {
            inicializaArray();
            muestraArrayPares();
            //Thread thread1 = new Thread(new ThreadStart(B));
            //thread1.Start();
            //thread1.Join();
            //Console.WriteLine(Program2.array);
            Console.ReadKey();
        }

        static void inicializaArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        static void muestraArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void muestraArrayPares()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                Console.WriteLine(array[i]);
            }
        }

        static void B()
        {
            // Add one then subtract two.
            //Interlocked.Increment();
        }
    }
}
