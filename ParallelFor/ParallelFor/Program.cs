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
        const int MAX = 100000;
        static double[]matriz = new double[MAX];
        static void Main(string[] args)
        {    
            Random rnd = new Random();
            for (int i = 0; i < MAX; i++)
            {
                matriz[i] = rnd.Next(100);
            }
            Stopwatch reloj = new Stopwatch();
            reloj.Start();
            Secuencial(); // Lo que se cuenta
            reloj.Stop();
            Console.WriteLine("Tiempo total: " + reloj.ElapsedMilliseconds);
            Console.WriteLine("----------");
            Console.WriteLine("Ejecucion Paralela");
            reloj.Reset();
            reloj.Start();
            Paralelo(); // Lo que se cuenta
            reloj.Stop();
            Console.WriteLine("Tiempo total paralelo: " + reloj.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static public void Secuencial()
        {
            double total = 0;
            for (int i = 0; i < MAX; i++)
            {
                //total += matriz[i];
                total += (System.Math.Sqrt(matriz[i])*System.Math.Cos(matriz[i])) / System.Math.E;
            }
            Console.WriteLine("Total: " + total.ToString());
        }

        static public void Paralelo()
        {
            double total = 0;
            Parallel.For(0, MAX, i =>
            {
                //total += matriz[i];
                total += (System.Math.Sqrt(matriz[i]) * System.Math.Cos(matriz[i])) / System.Math.E;
            });
            Console.WriteLine("Total: " + total.ToString());
        }
    }
}
