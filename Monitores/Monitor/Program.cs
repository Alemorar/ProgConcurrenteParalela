using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Monitores
{
    class Program
    {
        static object locker = new object();
        static void ThreadMain()
        {
            Thread.Sleep(800);
            WriteToFile();
        }

        static void WriteToFile()
        {
            String ThreadName = Thread.CurrentThread.Name;
            Console.WriteLine("{0} utilizando", ThreadName);
            Monitor.Enter(locker);
            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Rodrigo\Documents\test.txt", true))
                {
                    sw.WriteLine(ThreadName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            finally
            {
                Monitor.Exit(locker);
                Console.WriteLine("{0} liberando", ThreadName);
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++) 
            {
                Thread thread = new Thread(new ThreadStart(ThreadMain));
                thread.Name = String.Concat(" Thread - ", i);
                thread.Start();
            }
            Console.ReadLine();
        }
    }
}
