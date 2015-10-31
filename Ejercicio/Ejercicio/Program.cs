using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EjercicioPreparcial
{
    class Program
    {
        static int[] lstNumeros = new int[1000];
        static int iResultado = 0;
        static Object lockObj = new Object();

        static void Main(string[] args)
        {
            InicializaArray();

            Thread thread1 = new Thread(new ThreadStart(Deposito));
            Thread thread2 = new Thread(new ThreadStart(Extraccion));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("El saldo de la cuenta es es {0}", Program.iResultado);
            Console.ReadKey();
        }

        static void InicializaArray()
        {
            for (int i = 0; i < lstNumeros.Length; i++)
            {
                lstNumeros[i] = 0;
            }
        }

        static void Deposito()
        {
            Random rnd = new Random();
            var parallelResult = Parallel.For(0, lstNumeros.Length, (i) =>
            {
                Console.WriteLine("Deposito pos {0}", i);
                lstNumeros[i] += rnd.Next(5000, 8000);
                //Thread.Sleep(100);
                lock (lockObj)
                {
                    iResultado += lstNumeros[i];
                }
            });

            //while (parallelResult.IsCompleted == false) ;
        }

        static void Extraccion()
        {
            Random rnd = new Random();
            var parallelResult = Parallel.For(0, lstNumeros.Length, (i) =>
            {
                Console.WriteLine("Extraccion pos {0}", i);
                lstNumeros[i] -= rnd.Next(8000, 10000);
                //Thread.Sleep(100);
                lock (lockObj)
                {
                    iResultado -= lstNumeros[i];
                }
            });

            //while (parallelResult.IsCompleted == false) ;
        }

        static void SumaArray()
        {
            var parallelResult = Parallel.For(0, lstNumeros.Length, (i) =>
            {
                while (lstNumeros[i] == 0)
                {
                    Console.WriteLine("La posición {0} no tiene valor", i);
                    Thread.Sleep(100);
                }
                //realizamos la suma;

                lock (lockObj)
                {
                    iResultado += lstNumeros[i];
                }
            });
        }
    }
}
