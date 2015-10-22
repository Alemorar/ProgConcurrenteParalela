using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////////////
/// Procesos 
///
namespace ProgramaComoProceso
{
    class Test
    {
        //Un programa C# visto como proceso
        public static int NRandom(int n)
        {
            Random rnd = new Random();
            int limiteSup = n, limiteInf = 1;
            return (int)((limiteSup - limiteInf + 1) * rnd.NextDouble() +
                limiteInf);//valor entre 1 y n
        }

        public static void Esperar(int n)//Establecemos los Ticks o pasos. Cada Tick equivale a 100 nanosegundos
        {
            long tmi = DateTime.Now.Ticks;//Ticks
            while (DateTime.Now.Ticks < tmi);//Esperar n Ticks
        }

        public static void TomarMuestraTipoA(out int n)
        {
            n = NRandom(10);
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Tomando muestra de Tipo A");
                Esperar(500);
            }
        }

        public static void TomarMuestraTipoB(out int n)
        {
            n = NRandom(20);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Tomando muestra de Tipo B");
                Esperar(500);
            }
        }

        public static void Resultados(int n, int m)
        {
            Console.WriteLine("Muestras de Tipo A: " + n);
            Console.WriteLine("Muestras de Tipo B: " + m);
            Console.WriteLine("Total: " + (n + m));
        }

        public static void Main(string[] args)
        {
            int nMuestrasTipoA = 0;
            int nMuestrasTipoB = 0;
            TomarMuestraTipoA(out nMuestrasTipoA);
            TomarMuestraTipoB(out nMuestrasTipoB);
            Resultados(nMuestrasTipoA, nMuestrasTipoB);
            Console.ReadLine();
        }
    }
}
