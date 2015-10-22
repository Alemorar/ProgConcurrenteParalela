using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hipodromo
{
    public class Posiciones : Hilos
    {
        private Personas m_Tablon; // ACCESO DE LOS CABALLOS AL TABLON

        public Posiciones(Personas Tablon)
        {
            m_Tablon = Tablon;
        }

        public override void ProcHilo()
        {
            int nParticipantes;
            nParticipantes = m_Tablon.NumParticipantes();
            while (!m_Tablon.FinCarrera())
            {
                Console.WriteLine("POSICIONES DE LA CARRERA");
                Console.WriteLine("**************************");
                for (int i = 0; i < nParticipantes; ++i)
                {
                    for (int p = 0; p < m_Tablon.Posicion(i) + 1; ++p)
                        Console.Write("."); // distancia recorrida
                    Console.WriteLine("->"); // -> = caballo
                    Console.WriteLine("ES EL CABALLO : " + i);
                }

               Thread.Sleep(500);
            }
          
        }
    }
}
