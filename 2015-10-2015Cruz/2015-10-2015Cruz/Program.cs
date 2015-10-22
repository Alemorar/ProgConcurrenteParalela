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
        static Random r = new Random();
        static string ganador = "";
       
        static void Main(string[] args)
        {
            Parallel.For(0, threads.Length, i =>
                {
                    threads[i] = new Thread(Carrera);
                    threads[i].Name = "Caballo " + (i + 1).ToString();
                    threads[i].Start();
                });
            Console.Read();
        }

        static void Carrera()
        {
            int duracion;

            for (int i = 0; i < 4; i++)
            {
                duracion = r.Next(500, 1000);
                Thread.Sleep(duracion);
                Console.WriteLine("{0} finalizo vuelta {1}, duracion {2}", Thread.CurrentThread.Name, i + 1, duracion);
            }

            if (ganador.Length == 0)
            {
                ganador = Thread.CurrentThread.Name;
                Console.WriteLine("El ganador es el {0}", Thread.CurrentThread.Name);
            }
        }
    }
}
