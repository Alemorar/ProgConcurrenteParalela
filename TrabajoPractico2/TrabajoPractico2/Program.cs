using System;
using System.Threading;
/////////////////////////////////////////
// Hilos.
/////////////////////////////////////////
public class CHilo
{
    //Clase que define un hilo secundario
    private Thread hilo; // identificador del hilo
    private int nMuestras;

    public CHilo()
        : this(null)
    {
    }

    public CHilo(string nombreHilo)
    {
        nMuestras = 0;
        //Crear el hilo identificado por hilo
        hilo = new Thread(ProcHilo);
        if (nombreHilo != null) hilo.Name = nombreHilo;
    }

    public Thread HiloSubyacente//proceso thread
    {
        get { return hilo; } //referencia al objeto Thread
    }

    private void ProcHilo(Object datos)
    {
        nMuestras = NRandom((int)datos);
        for (int i = 0; i < nMuestras; i++)
        {
            Console.WriteLine(hilo.Name + " tomando muestra " + (i + 1));
            Esperar(500); //ticks
        }
    }

    private int NRandom(int n)
    {
        Random rnd = new Random();
        int limiteSup = n, limiteInf = 1;
        return (int)((limiteSup - limiteInf + 1) * rnd.NextDouble() +
            limiteInf); // valor entre 1 y n
    }

    private void Esperar(int n)
    {
        long tmi = DateTime.Now.Ticks + n;//ticks
        while (DateTime.Now.Ticks < tmi) ;//esperar n ticks
    }

    public int MuestrasTomadas
    {
        get { return nMuestras; }
    }
} 
