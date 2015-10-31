using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hipodromo
{
    class Program
    {
        static Thread[] threads = new Thread[4];
        static int[] duracionCab = new int[4];
        static Random r = new Random();
        static string ganador = "";

        static int aux = 10000000;
        static void Main(string[] args)
        {
            int ii = 0;
            var parallelResult = Parallel.For(0, threads.Length, i =>
                {
                    threads[i] = new Thread(Carrera);
                    threads[i].Name = "Caballo " + (i + 1).ToString();
                    threads[i].Start();
                });

            Thread.Sleep(6000);
            while (parallelResult.IsCompleted == false) ;
            for (int i = 0; i < duracionCab.Length; i++)
            {
                Console.WriteLine("Duracion Caballo {0}, Tiempo {1}", i + 1, duracionCab[i]);
                if (duracionCab[i] < aux)
                {
                    aux = duracionCab[i];
                    ii = i;
                }
            }

            Console.WriteLine("El ganador es el Caballo {0}, duracion total {1}", ii+1, duracionCab[ii]);
            Console.Read();
        }

        static void Carrera()
        {
            int duracion;
            int indice = 0;
            for (int i = 0; i < 4; i++)
            {
                duracion = r.Next(500, 1000);
                Thread.Sleep(duracion);
                Console.WriteLine("{0} finalizo vuelta {1}, duracion {2}", Thread.CurrentThread.Name, i + 1, duracion);
                switch (Thread.CurrentThread.Name)
                {
                    case "Caballo 1":
                        indice = 0;
                        break;

                    case "Caballo 2":
                        indice = 1;
                        break;

                    case "Caballo 3":
                        indice = 2;
                        break;

                    case "Caballo 4":
                        indice = 3;
                        break;
                }
                duracionCab[indice] += duracion;
            }
            /*

            if (ganador.Length == 0)
            {
                ganador = Thread.CurrentThread.Name;
                
            }*/
        }
    }
}
