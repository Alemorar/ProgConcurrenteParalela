using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Test
    {
        //Hilo primario
        public static void Main()
        {
            CHilo hiloA = new CHilo("Hilo A");
            CHilo hiloB = new CHilo("Hilo B");
            hiloA.HiloSubyacente.Start(10);//máximo 10 muestras
            hiloB.HiloSubyacente.Start(20);//máximo 20 muestras
            hiloA.HiloSubyacente.Join();
            hiloB.HiloSubyacente.Join();
            //Resultados
            Console.WriteLine(hiloA.HiloSubyacente.Name + " muestras tomadas: " + hiloA.MuestrasTomadas);
            Console.WriteLine(hiloB.HiloSubyacente.Name + " muestras tomadas: " + hiloB.MuestrasTomadas);
            Console.WriteLine("Total: " + (hiloA.MuestrasTomadas + hiloB.MuestrasTomadas));
            Console.ReadLine();
        }
    }
}
