using System;
using System.Threading;
/////////////////////////////////////////////////////////////////////////////////////
///Hilos.
///

public class CHilo//Clase que define un hilo secundario
{
    private Thread hilo;//identificador del hilo
    
    public CHilo() : this(null) {}
    public CHilo(string nombreHilo)
    {
        //Crear el hilo identificado por hilo
        hilo = new Thread(ProcHilo);
        if (nombreHilo != null) hilo.Name = nombreHilo;
        //Iniciar el hilo
        hilo.Start();
    }

    public Thread HiloSubyacente
    {
        get { return hilo; }//referencia al objeto Thread
    }

    private void ProcHilo()
    {
        //codigo que ejecuta el hilo
        Console.WriteLine("El hilo finalizo");
    }
}
