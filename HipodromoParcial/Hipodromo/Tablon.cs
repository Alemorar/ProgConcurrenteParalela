using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hipodromo
{
    public class Personas
    {
        private int[] m_Posicion; 
        private int m_nParticipantes; // numero de participantes

        public Personas(int participantes)
        {
            // Crear la matriz de posiciones de los participantes
            // Los elementos son automaticamente iniciados a cero
            m_nParticipantes = participantes;
            m_Posicion = new int[m_nParticipantes];
        }

        public bool FinCarrera()
        {
            for (int i = 0; i < m_nParticipantes; ++i)
            {
                if (m_Posicion[i] == 4) // distancia a recorrer
                    return true; // final de la carrera
            }
           
            return false; // continuar
        }

        public void IncrementarPosicion(int dorsal)
        {
            m_Posicion[dorsal]++; // participante avanza
        }

        public int Posicion(int dorsal)
        {
            return (m_Posicion[dorsal]); // posicion actual
        }

        public int NumParticipantes()
        {
            return m_nParticipantes; // numero de participantes
        }
      
    }
   
}
