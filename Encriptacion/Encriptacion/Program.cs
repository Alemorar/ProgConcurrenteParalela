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
        public static string[,] matString;
        public static string[,] matRef = new string[2,49] {{
"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"," ","@","#","!","$","%","&","/","(",")","=","?","¿","0","1","2","3","4","5","6","7","8","9"},{
"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49"}};
        
        public static int[,] matCod;
        public static string varString;
        public static string opcion;
        public static int a = 0;
        public static int fila = 0;
        public static int col = 0;
        public static string str;
        public static int codRef;
        public static string strRef;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("-----------Encriptacion-----------");
                Console.WriteLine("1) Ingresar String");
                Console.WriteLine("2) Mostrar String");
                Console.WriteLine("3) Cargar String en Matriz");
                Console.WriteLine("4) ");
                Console.WriteLine("5) ");
                Console.WriteLine("6) Codificar Matriz");
                Console.WriteLine("7) Mostrar Matriz Cod");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine();
                        Console.Write("Ingrese String: ");
                        varString = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("La cadena String es:\n'{0}'", varString);
                        break;
                    case "3":
                        if (String.IsNullOrEmpty(varString))
                        {
                            Console.WriteLine("Debe definir un String antes de cargar la Matriz");
                        }
                        else
                        {
                            Console.Write("Ingrese cantida de filas de la Matriz: ");
                            fila = Convert.ToInt32(Console.ReadLine());//definimos la cantidad de filas de la Matriz
                            col = CalcularCantCol(varString, fila, col);//llamamos la funcion para calcular la cantidad de columnas
                            CargarStringEnMatriz(fila, col, varString, a);
                            Console.WriteLine();
                            MostrarMatrizString();
                        }
                        break;
                    case "4":
                        Codificar(matString);
                        Console.WriteLine();
                        Console.WriteLine("La cadena String es:\n'{0}'", varString);
                        MostrarMatrizString();
                        Console.WriteLine();
                        MostrarMatrizCod(matCod);
                        Console.WriteLine();
                        MatrizReferencia(matRef);
                        break;
                    case "5":
                        
                        break;
                    case "6":
                        
                        break;
                    case "7":
                        
                        break;
                    case "8":
                        MatrizReferencia(matRef);
                        break;
                    case "9":
                        varString = "STRING DE prueba PARA ENCRIPTACION DE MENSAJES 0123456789";
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Console.Write("\npresione una tecla para continuar..........");
                Console.ReadLine();

            } while (opcion != "0");
        }

        public static void Codificar(string[,] matString)
        {
            matCod = new int[fila, col];
            for (int i = 0; i < matString.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matString.GetLength(1); j++)//col
                {
                    str = matString[i, j];
                    codRef = Int32.Parse(BuscarNroCodigo(str));
                    matCod[i, j] = codRef;
                }
            }
        }

        public static string BuscarNroCodigo(string str)
        {            
            for (int i = 0; i < matRef.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matRef.GetLength(1); j++)//col
                {
                    if (i == 1)
                    {
                        break;
                    }
                    //Console.WriteLine("str {0} / matRef {1},{2} es {3}", str, i, j, matRef[i,j]);
                    if (matRef[i, j].Equals(str, StringComparison.OrdinalIgnoreCase))//root.Equals(root2, StringComparison.OrdinalIgnoreCase)
                    {
                        strRef = matRef[i + 1, j];
                        break;
                    }
                }
            }            
            return strRef;
        }

        public static string[,] CargarStringEnMatriz(int fila, int col, string varString, int a)
        {
            matString = InstanciarMatString();//instanciamos matString
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
                    catch (Exception)
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
                    //Console.Write("|{0}", matString[i, j]);
                }
            }
            return matString;
        }

        public static void MostrarMatrizString()
        {
            for (int i = 0; i < matString.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matString.GetLength(1); j++)//col
                {
                    Console.Write("| {0}", matString[i, j]);
                }
                Console.WriteLine("|");
            }
        }

        public static string[,] InstanciarMatString()
        {
            string[,] matString = new string[fila, col];
            return matString;
        }

        public static void MostrarMatrizCod(int[,] matCod)
        {
            for (int i = 0; i < matCod.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matCod.GetLength(1); j++)//col
                {
                    Console.Write("|{0}", matCod[i, j]);
                }
                Console.WriteLine("|");
            }
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

        public static void MatrizReferencia(string[,] matRef)
        {
            for (int i = 0; i < matRef.GetLength(1); i++)//col
            {
                for (int j = 0; j < matRef.GetLength(0); j++)//fila
                {
                    //if (i == 0)
                    //{
                        Console.Write("{0}", matRef[j, i]);
                    //}
                    //else
                    //{
                    //    Console.Write("{0}", matRef[i, j]);
                    //}
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}

/* Form1 is the name of the Form and : is used to inherit the properties of base class.
 * Here Form represents System.Windows.Forms.Form. We are inheriting to access the properties and methods of base class.
 * https://msdn.microsoft.com/en-us/library/wa80x488.aspx
 */
