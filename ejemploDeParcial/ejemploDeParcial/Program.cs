using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AppSemaforos
{
    class Program
    {
        static Thread[] threads = new Thread[50];
        static Semaphore sem1 = new Semaphore(1, 1);
        static Semaphore sem2 = new Semaphore(0, 1);
        static Semaphore sem3 = new Semaphore(0, 1);
        static Random r = new Random();
        static Stopwatch relojPrincipal = new Stopwatch();
        static int numPersonas = 0;
        static int numAtendidos = 0;
        static int[] tiempoAtencionBoleteria = new int[3] { 0, 0, 0 };
        static int[] personasPorBoleteria = new int[3] { 0, 0, 0 };

        static void Main(string[] args)
        {
            relojPrincipal.Restart();
            for (int i = 0; i < threads.Count(); i++)
            {

                threads[i] = new Thread(C_sharpcorner);
                threads[i].Name = "Cliente_" + i;
                threads[i].Start();
            }

            Thread.Sleep(4000); //demora de 4 segundos
            sem2.Release(); //los dos cajeros se liberan y comienzan a atender
            sem3.Release(); //los dos cajeros se liberan y comienzan a atender

            Console.ReadLine();
            //imprimimos los resultados
            Console.WriteLine("El tiempo promedio de permanencia de una persona es: {0} ", relojPrincipal.ElapsedMilliseconds / threads.Count());
            Console.WriteLine("Boleteria 1 - Personas atendidas: {0} - Tiempo de atencion: {1} ", personasPorBoleteria[0], tiempoAtencionBoleteria[0]);
            Console.WriteLine("Boleteria 2 - Personas atendidas: {0} - Tiempo de atencion: {1} ", personasPorBoleteria[1], tiempoAtencionBoleteria[1]);
            Console.WriteLine("Boleteria 3 - Personas atendidas: {0} - Tiempo de atencion: {1} ", personasPorBoleteria[2], tiempoAtencionBoleteria[2]);
            Console.ReadLine();
        }

        static void C_sharpcorner()
        {
            int duracion = 0, s = 0;
            string nomSem = "";
            Console.WriteLine("{0} en Fila", Thread.CurrentThread.Name);

            s = r.Next(1, 4);
            switch (s)
            {
                case 1:
                    sem1.WaitOne();
                    nomSem = "Semaforo 1";
                    personasPorBoleteria[0] += 1;
                    break;
                case 2:
                    sem2.WaitOne();
                    nomSem = "Semaforo 2";
                    personasPorBoleteria[1] += 1;
                    break;
                case 3:
                    sem3.WaitOne();
                    nomSem = "Semaforo 3";
                    personasPorBoleteria[2] += 1;
                    break;
            }

            Console.WriteLine("{0} en atencion - " + nomSem, Thread.CurrentThread.Name);
            duracion = r.Next(1000, 2000);
            switch (s)
            {
                case 1:
                    tiempoAtencionBoleteria[0] += duracion;
                    break;
                case 2:
                    tiempoAtencionBoleteria[1] += duracion;
                    break;
                case 3:
                    tiempoAtencionBoleteria[2] += duracion;
                    break;
            }
            Thread.Sleep(duracion); //Demora variable entre 1 y 2 segundos
            numPersonas += 1;
            Console.WriteLine("Existen {0} personas en el parque", numPersonas);
            Console.WriteLine("{0} en Parque", Thread.CurrentThread.Name);
            duracion = r.Next(1500, 1800);
            Thread.Sleep(duracion); //Demora variable para la permanencia dentro del parque
            numPersonas -= 1;
            numAtendidos += 1;
            Console.WriteLine("{0} saliendo del Parque.", Thread.CurrentThread.Name);
            switch (s)
            {
                case 1:
                    sem1.Release();
                    break;
                case 2:
                    sem2.Release();
                    break;
                case 3:
                    sem3.Release();
                    break;
            }

            if (numAtendidos == threads.Count())
                relojPrincipal.Stop();

        }
    }
}
