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
        public static void Main(string[] args)
        {
            string varString = "";
            string opcion = "";
            int a = 0;
            int fila = 0;
            int col = 0;
            string[,] matString;
            do
            {
                Console.Clear();
                Console.WriteLine("-----------Encriptacion-----------");
                Console.WriteLine("1) Ingresar String");
                Console.WriteLine("2) Mostrar String");
                Console.WriteLine("3) Cargar String en Matriz");
                Console.WriteLine("4) Mostrar String en Matriz");
                Console.WriteLine("5) Codificar Matriz");
                Console.WriteLine("6) Encriptar Matriz");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {                    
                    case "1":
                        Console.Write("Ingrese String: ");
                        varString = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("La cadena String es: '{0}'\n", varString);
                        break;
                    case "3":
                        if (varString.Length <= 1)
                        {
                            Console.WriteLine("Debe definir un String antes de cargar la Matriz");
                        }
                        else
                        {
                            Console.Write("Ingrese cantida de filas de la Matriz: ");
                            fila = Convert.ToInt32(Console.ReadLine());//definimos la cantidad de filas de la Matriz
                            col = CalcularCantCol(varString, fila, col);//llamamos la funcion para calcular la cantidad de columnas
                            matString = InstanciarMatriz(fila, col);
                            matString = CargarStringEnMatriz(matString, fila, col, varString, a);
                        }
                        break;
                    case "4":
                        ///MostrarMatrizString(matString);
                        break;
                    case "8":
                        Console.WriteLine("");
                        MatrizReferencia();
                        break;
                    case "9":
                        varString = StringPredeterminado();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Console.Write("\npresione una tecla para continuar..........");
                Console.ReadLine();

            } while (opcion != "0");
        }

        public static String[,] CargarStringEnMatriz(string[,] matString, int fila, int col, string varString, int a)
        {
            //Cargamos la matriz matString
            for (int i = 0; i < matString.GetLength(1); i++)//col
            {
                for (int j = 0; j < matString.GetLength(0); j++)//fila
                {
                    try
                    {
                        matString[j, i] = varString.Substring(a, 1);
                        a++;
                    }
                    catch (Exception e)
                    {
                        matString[j, i] = " ";
                    }
                }
            }
            //hacemos la transpuesta de matString
            for (int i = 0; i < matString.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matString.GetLength(1); j++)//col
                {
                    Console.Write("|{0}", matString[i, j]);
                }
                Console.WriteLine("|");
            }
            return matString;
        }

        public static void MostrarMatrizString(string[,] matString)
        {
            for (int i = 0; i < matString.GetLength(1); i++)//col
            {
                for (int j = 0; j < matString.GetLength(0); j++)//fila
                {
                    Console.Write("|{0}", matString[i, j]);
                }
                Console.WriteLine("|");
            }
        }

        public static string StringPredeterminado()
        {
            string varString = "Hola Tano estas verdaderamente loco, estamos probando el codigo";
            return varString;
        }

        public static string[,] InstanciarMatriz(int fila, int col)
        {
            string[,] matString = new string[fila, col];
            return matString;
        }

        public static int CalcularCantCol(string varString, int fila, int col)//calculamos la cantidad de columnas de la Matriz
        {
            if (varString.Length % fila == 0)
            {
                col = (int)Math.Truncate(varString.Length / (double)fila);
            }
            else
            {
                col = (int)(Math.Truncate(varString.Length / (double)fila) + 1);
            }
            return col;
        }

        public static void MatrizReferencia()
        {
            string[,] matRef = {{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W",
                                  "X","Y","Z"," "},{"01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16",
                                      "17","18","19","20","21","22","23","24","25","26","27"}};

            for (int i = 0; i < matRef.GetLength(0); i++)//col
            {
                for (int j = 0; j < matRef.GetLength(1); j++)//fila
                {
                    if (i == 0)
                    {
                        Console.Write(" {0} ", matRef[i, j]);
                    }
                    else
                    {
                        Console.Write("{0} ", matRef[i, j]);
                    }
                }
            }
        }
    }
}

/* Form1 is the name of the Form and : is used to inherit the properties of base class.
 * Here Form represents System.Windows.Forms.Form. We are inheriting to access the properties and methods of base class.
 * https://msdn.microsoft.com/en-us/library/wa80x488.aspx
 */
