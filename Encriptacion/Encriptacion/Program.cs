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
            String varString = "Hola Tano estas verdaderamente loco hijo de la chingad";
            Console.WriteLine("Longitud de Cadena {0}", varString.Length);
            int fila = 4;
            int col = 0;
            if (varString.Length % fila == 0)
            {
                col = (int)Math.Truncate(varString.Length / (double)fila);
                Console.WriteLine("Mod =0 {0}", col);
            }else
            {
                col = (int)(Math.Truncate(varString.Length / (double)fila) + 1);
                Console.WriteLine("Mod !0 {0}", col);
            }
            Console.WriteLine("Cociente Long Cadena({0}) / fila({1}) = {2}", varString.Length, fila,
                (double)varString.Length / fila);
            Console.WriteLine("La cadena es: ''{0}''\n", varString);
            String[,] matFrase = new String[fila, col];
            //Cargamos la matriz matFrase
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < fila; j++)
                {
                    try
                    {
                        Console.Write("{0}", matFrase[j, i] = varString.Substring(a, 1));
                        a++;
                    }
                    catch (Exception e)
                    {
                        Console.Write("{0}", matFrase[j, i] = " ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            //hacemos la transpuesta de matFrase
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("{0}  ", matFrase[i, j]);
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
