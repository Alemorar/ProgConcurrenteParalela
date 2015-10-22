using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hipodromo
{
    public class Caballo : Hilos
    {
        private Tablon; // ACCESO DE LOS CABALLOS AL TABLON
        private int dorsal; // NUMERO DE CABALLO
        private string nombre; // NOMBRE DEL CABALLO

        public Caballo()
        {
            nombre = "Caballo desconocido";
            dorsal = 0;
        }

        public Caballo(int dor, string nom, Tablon t)
        {
            dorsal = dor;
            nombre = nom;
            Tablon = t;
        }

        public override void ProcHilo()
        {
            Random rnd = new Random(
                unchecked((int)DateTime.Now.Ticks) * (dorsal + 1));
            int limiteInf = 500, limiteSup = 1000; // DURACION EN MILISEGUNDOS

            while (!Tablon.FinCarrera())
            {
                Thread.Sleep((int)(
                   (limiteSup-limiteInf) * rnd.NextDouble() + limiteInf));
                Tablon.IncrementarPosicion(dorsal);

            }
            PosicionFinal();

        }
         public void PosicionFinal() 
        {
            dorsal = dorsal + 1;
                 Console.WriteLine("Posicion Caballo : " + dorsal);
        }

    }

}