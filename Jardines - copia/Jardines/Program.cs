﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jardín
{
    class Program
    {
        static Thread[] threads = new Thread[50];
        static Semaphore sem = new Semaphore(1, 1);
        static int p = 20;
        static void Main(string[] args)
        {
            for (int i = 0; i < 25; i++)
            {
                threads[i] = new Thread(aumentar);
                threads[i].Start();
            }
            for (int j = 25; j < 50; j++)
            {
                threads[j] = new Thread(disminuir);
                threads[j].Start();
            }
            Console.ReadLine();
        }

        public static void aumentar()
        {
            sem.WaitOne();
            p +=  1;
            Console.WriteLine("Entrando: "+p);
            Thread.Sleep(200);
            sem.Release();
            Thread.Sleep(1000);
            Console.WriteLine("Paseando...");
        }

        public static void disminuir()
        {
            sem.WaitOne();
            p -= 1;
            Thread.Sleep(100);
            Console.WriteLine("Saliendo: " + p);
            sem.Release();
        }
    }
}

