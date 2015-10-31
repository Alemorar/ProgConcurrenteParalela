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
        static int DimThread = 10;
        static Thread[] A = new Thread[DimThread];//Generamos Arreglo "A" de tipo Thread, de 10 posiciones
        static int[] duracionCab = new int[4];
        static Random r = new Random();//Agregamos la semilla random
        static string ganador = "";
        static int aux = 10000000;

        static void Main(string[] args)//Proceso Main
        {
            int ii = 0;
            var parallelResult = Parallel.For(0, A.Length, i =>
            {
                A[i] = new Thread(ProcesoA);
                A[i] = new Thread(ProcesoB);
                A[i].Name = "A[] en pos " + (i + 1).ToString();
                A[i].Start();
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

            Console.WriteLine("El ganador es el Caballo {0}, duracion total {1}", ii + 1, duracionCab[ii]);
            Console.Read();
        }

        static void ProcesoA()//ProcesoA que sera lanzado por Thread
        {
            int rand;
            rand = r.Next(1, 100);//Genera aleatorio 1 a 100 y guarda en posicion i
            Thread.Sleep(rand);
            Console.WriteLine("{0}, guardo {1} y suma", Thread.CurrentThread.Name, rand);// {1} ,i + 1
        }

        static void ProcesoB()//ProcesoB que sera lanzado por Thread
        {
            //int n = 0;
            Console.WriteLine("probando");//Aca voy acumulando el total de A para devolverlo parcialmente
            //return n;
        }

            /*int rand;
            int indice = 0;
            for (int i = 0; i < A.Length; i++)
            {
                rand = r.Next(1, 100);//Genera aleatorio 1 a 100 y guarda en posicion i
                Thread.Sleep(rand);
                Console.WriteLine("{0}, guardo {1}", Thread.CurrentThread.Name, rand);// {1} ,i + 1
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
                duracionCab[indice] += rand;
            }*/
            /*

            if (ganador.Length == 0)
            {
                ganador = Thread.CurrentThread.Name;
                
            }*/
        }
    }
}

