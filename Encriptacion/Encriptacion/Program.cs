using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encriptacion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            String varString = "Hola Tano estas verdaderamente loco hijo de la chingada madre";
            Console.WriteLine("Longitud de Cadena {0}", varString.Length);
            int fila = 4;
            int col = 0;
            if (varString.Length % fila == 0)
            {
                col = (int)Math.Truncate(varString.Length / (double)fila);
            }else
            {
                col = (int)(Math.Truncate(varString.Length / (double)fila) + 1);
            }
            Console.WriteLine("Cociente Long Cadena({0}) / fila({1}) = {2} col {3}", varString.Length, fila,
                (double)varString.Length / fila, col);
            Console.WriteLine("La cadena es: '{0}'\n", varString);
            String[,] matFrase = new String[fila, col];
            //Cargamos la matriz matFrase
            for (int i = 0; i < matFrase.GetLength(1); i++)//col
            {
                for (int j = 0; j < matFrase.GetLength(0); j++)//fila
                {
                    try
                    {
                        matFrase[j, i] = varString.Substring(a, 1);
                        a++;
                    }
                    catch (Exception e)
                    {
                        matFrase[j, i] = " ";
                    }
                }
            }
            Console.WriteLine("");
            //hacemos la transpuesta de matFrase
            for (int i = 0; i < matFrase.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matFrase.GetLength(1); j++)//col
                {
                    Console.Write("{0}|", matFrase[i, j]);
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}

/* Form1 is the name of the Form and : is used to inherit the properties of base class.
 * Here Form represents System.Windows.Forms.Form. We are inheriting to access the properties and methods of base class.
 * https://msdn.microsoft.com/en-us/library/wa80x488.aspx
 */
