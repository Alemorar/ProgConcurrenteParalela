using System;

public class Test2
{
	public Test2()
	{

	}
}

public class Test
{
    //Hilo primario
    public static void Main()
    {
        CHilo hiloSecundario = new CHilo();
        //Esperar a que el hilo secundario finalice.
        hiloSecundario.HiloSubyacente.Join();
    }
}


