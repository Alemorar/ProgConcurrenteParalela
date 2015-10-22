using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Hipodromo
{
    public class Hipodromo
    {
        public static void Main(string[] args)
        {
           
            string nomCaballo = null;
            const int num_participantes = 5;

            Tablon Tablon = new Tablon(num_participantes);
            Caballo[] participante = new Caballo[num_participantes];
            Posiciones Marcador = new Posiciones(Tablon);

            //Iniciar el hilo marcador
            Marcador.HiloSubyacente.Start();
            for (int i = 0; i < num_participantes; ++i)
            {
                //Datos de los participantes
                nomCaballo = "CABALLO " + i;
                participante[i] = new Caballo(i, nomCaballo, Tablon);
                //Iniciar los hilos de los caballos participantes
                participante[i].HiloSubyacente.Start();
               
            }
         
            Console.ReadLine();
        }
  
    }
}
