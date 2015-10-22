using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hipodromo
{
    // Clase que define un hilo secundario
    public abstract class Hilos
    {
        private Thread hilo; // identificador del hilo

        public Hilos() : this(null) { }

        public Hilos(string nombreHilo)
        {
            // Crear el hilo identificado por hilo
            hilo = new Thread(ProcHilo);
            if (nombreHilo != null) hilo.Name = nombreHilo;
        }

        public Thread HiloSubyacente
        {
            get { return hilo; } // referencia al objeto Thread
        }

        public abstract void ProcHilo();
    }
}
