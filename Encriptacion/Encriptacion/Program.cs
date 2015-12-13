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
        public static string[,] matString;//matriz que guarda en cada posicion un caracter de la cadena string
        public static string[,] matRef = new string[2,50] {{//Instanciamos la matriz de codificacion, y asignamos valores
"A","B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","W","X","Y","Z"," ","@","#","!","$","%","&","/","(",")","=","?","¿","0","1","2","3","4","5","6","7","8","9"},{
"27","26","25","24","23","22","21","20","19","18","17","16","15","14","13","12","11","10","9","8","7","6","5","4","3","2","1","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50"}};
        public static int[,] matCod;//matriz de codificacion, guarda las equivalencias de las posiciones de matString con matRef
        public static string[,] matDecod;
        public static int[,] matClave;//matriz 2x2 matClave generada aleatoriamente, se comprueba que la determinante sea distinta de 0
        public static int[,] matClaveInvert;//matriz que invierte matClave
        public static int[,] matClaveInvertTeclado;//matriz que invierte matClave
        public static int[,] matEncryp;//matriz producto de la matriz clave 2x2 matClave y la matriz matCod
        public static int[,] matEncrypTeclado;//matriz producto de la matriz clave 2x2 matClave y la matriz matCod
        public static int[,] matDesEncryp;//matriz matEncryp desencriptada, es igual a matCod, resultado del producto entre matClave y matCod
        public static string varString;//variable que captura el string ya sea asignando o desde el teclado.
        public static string opcion;
        public static int a = 0;
        public static int fila = 2;
        public static int col = 0;
        public static string str;
        public static int destr;
        public static int codRef;
        public static string strRef;
        public static string strRefDev;
        public static int det;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("-----------Encriptacion-----------");
                Console.WriteLine("1) Ingresar String");
                Console.WriteLine("2) Mostrar String");
                Console.WriteLine("3) Cargar String codificar y encriptar");
                Console.WriteLine("4) Ingresar encriptacion y matriz inversa");
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
                            //Console.Write("Ingrese cantida de filas de la Matriz: ");
                            //fila = Convert.ToInt32(Console.ReadLine());//definimos la cantidad de filas de la Matriz
                            col = CalcularCantCol(varString, fila, col);//llamamos la funcion para calcular la cantidad de columnas
                            CargarStringEnMatriz(fila, col, varString, a);
                            Codificar(matString);
                            CrearMatrizAleatoria();
                            //Console.WriteLine();
                            //Console.WriteLine("La matriz con el string cargado es: ");
                            //MostrarMatrizString();
                            //Console.WriteLine();
                            //Console.WriteLine("La matriz codificada es: ");
                            //MostrarMatrizCod();
                            Console.WriteLine();
                            Console.WriteLine("La matriz clave es: ");
                            MostrarMatrizAleat();
                            EncriptarMatrizCod();
                            //Console.WriteLine("La matriz encriptada es: ");
                            //MostrarMatrizEncrip();
                            Console.WriteLine();
                            Console.WriteLine("El mensaje encriptado es: ");
                            MostrarMensajeEncriptado();
                            Console.WriteLine();
                            Console.WriteLine("Guarde la matriz Clave: ");
                            //Console.WriteLine();
                            //InvertirMatrizClave();
                            //DesencriptarMatEncryp();
                            //Console.WriteLine();
                            //Console.WriteLine("La matriz clave invertida es: ");
                            //MostrarMatrizClaveInvert();
                            //Console.WriteLine();
                            //Console.WriteLine("La matriz desencriptada es: ");
                            //MostrarMatrizDesEncrip();
                        }
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Ingrese mensaje encriptado: ");
                        CargarMensajeEncryptado();
                        Console.WriteLine();
                        Console.WriteLine("Ingrese matriz clave invertida: ");
                        CargarMatClaveInvertTeclado();

                        break;
                    case "5":

                        break;
                    case "6":
                        
                    case "7":
                        
                        break;
                    case "8":
                        MatrizReferencia(matRef);
                        break;
                    case "20":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("****Test 20****\n");
                        varString = "ProBando 01";
                        Console.WriteLine("La cadena String es:\n'{0}'", varString);
                        if (String.IsNullOrEmpty(varString))
                        {
                            Console.WriteLine("Debe definir un String antes de cargar la Matriz");
                        }
                        else
                        {
                            col = CalcularCantCol(varString, fila, col);//llamamos la funcion para calcular la cantidad de columnas
                            CargarStringEnMatriz(fila, col, varString, a);
                        }
                        Codificar(matString);
                        matClave = new int[2,2] {{2,1},{1,1}};
                        Console.WriteLine();
                        Console.WriteLine("La matriz con el string cargado es: ");
                        MostrarMatrizString();
                        Console.WriteLine();
                        Console.WriteLine("La matriz codificada es: ");
                        MostrarMatrizCod();
                        Console.WriteLine();
                        Console.WriteLine("La matriz clave es: ");
                        MostrarMatrizAleat();
                        Console.WriteLine();
                        EncriptarMatrizCod();
                        Console.WriteLine("La matriz encriptada es: ");
                        MostrarMatrizEncrip();
                        Console.WriteLine();
                        Console.WriteLine("El mensaje encriptado es: ");
                        MostrarMensajeEncriptado();
                        Console.WriteLine();
                        InvertirMatrizClave();
                        DesencriptarMatEncryp();
                        Console.WriteLine();
                        Console.WriteLine("La matriz clave invertida es: ");
                        MostrarMatrizClaveInvert();
                        Console.WriteLine();
                        Console.WriteLine("La matriz desencriptada es: ");
                        MostrarMatrizDesEncrip();
                        Console.WriteLine();
                        Console.WriteLine("La matriz decodificada es: ");
                        DeCodificar();
                        MostrarMatrizDecod();
                        break;
                    case "21":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("****Test 21****\n");
                        varString = "QUEDAMOS EN EL ALTOZANO A LAS NUEVE";
                        Console.WriteLine("La cadena String es:\n'{0}'", varString);
                        if (String.IsNullOrEmpty(varString))
                        {
                            Console.WriteLine("Debe definir un String antes de cargar la Matriz");
                        }
                        else
                        {
                            col = CalcularCantCol(varString, fila, col);//llamamos la funcion para calcular la cantidad de columnas
                            CargarStringEnMatriz(fila, col, varString, a);
                        }
                        Codificar(matString);
                        matClave = new int[2,2] {{2,1},{1,1}};
                        Console.WriteLine();
                        Console.WriteLine("La matriz con el string cargado es: ");
                        MostrarMatrizString();
                        Console.WriteLine();
                        Console.WriteLine("La matriz codificada es: ");
                        MostrarMatrizCod();
                        Console.WriteLine();
                        Console.WriteLine("La matriz clave es: ");
                        MostrarMatrizAleat();
                        Console.WriteLine();
                        EncriptarMatrizCod();
                        Console.WriteLine("La matriz encriptada es: ");
                        MostrarMatrizEncrip();
                        Console.WriteLine();
                        Console.WriteLine("El mensaje encriptado es: ");
                        MostrarMensajeEncriptado();
                        Console.WriteLine();
                        InvertirMatrizClave();
                        DesencriptarMatEncryp();
                        Console.WriteLine();
                        Console.WriteLine("La matriz clave invertida es: ");
                        MostrarMatrizClaveInvert();
                        Console.WriteLine();
                        Console.WriteLine("La matriz desencriptada es: ");
                        MostrarMatrizDesEncrip();
                        Console.WriteLine();
                        Console.WriteLine("La matriz decodificada es: ");
                        DeCodificar();
                        MostrarMatrizDecod();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Console.Write("\npresione una tecla para continuar..........");
                Console.ReadLine();

            } while (opcion != "0");
        }

        public static void DesencriptarMatEncrypTeclado()
        {
            for (int l = 0; l < matEncrypTeclado.GetLength(1); l++)//col
            {
                matDesEncryp[0, l] = matClaveInvertTeclado[0, 0] * matEncrypTeclado[0, l] + matClaveInvertTeclado[0, 1] * matEncrypTeclado[1, l];//fila 0 de matCod
                matDesEncryp[1, l] = matClaveInvertTeclado[1, 0] * matEncrypTeclado[0, l] + matClaveInvertTeclado[1, 1] * matEncrypTeclado[1, l];//fila 0 de matCod
            }
        }

        public static void MostrarMatrizDesEncrip()
        {
            for (int i = 0; i < matDesEncryp.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matDesEncryp.GetLength(1); j++)//col
                {
                    if (matDesEncryp[i, j] < 10)
                    {
                        Console.Write("| {0}", matDesEncryp[i, j]);
                    }
                    else
                    {
                        Console.Write("|{0}", matDesEncryp[i, j]);
                    }
                }
                Console.WriteLine("|");
            }
        }

        public static void CargarMensajeEncryptado()
        {
            matEncrypTeclado = new int[fila,col];
            for (int i = 0; i < matEncrypTeclado.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matEncrypTeclado.GetLength(1); j++)//col
                {
                    Console.WriteLine("ingrese posicion {0}-{1}", i + 1, j + 1);
                    matEncrypTeclado[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
        }

        public static void CargarMatClaveInvertTeclado()
        {
            matClaveInvertTeclado = new int[fila, fila];
            Console.WriteLine("ingrese posicion 1-1");
            matClaveInvertTeclado[0, 0] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("ingrese posicion 1-2");
            matClaveInvertTeclado[0, 1] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("ingrese posicion 2-1");
            matClaveInvertTeclado[1, 0] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("ingrese posicion 2-2");
            matClaveInvertTeclado[1, 1] = Int32.Parse(Console.ReadLine());

        }

        public static void DeCodificar()//COMPARA CADA ELEMENTO DE matString CON LOS DE matRef
        {
            matDecod = new string[fila, col];
            for (int i = 0; i < matDesEncryp.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matDesEncryp.GetLength(1); j++)//col
                {
                    strRef = Convert.ToString(matDesEncryp[i, j]);
                    for (int k = 0; k < matRef.GetLength(1); k++)//col
                    {
                        if (matRef[1, k].Equals(strRef))//root.Equals(root2, StringComparison.OrdinalIgnoreCase)
                        {
                            matDecod[i, j] = matRef[0, k];
                            break;
                            //Console.Write("buscar {0} = {1}, strRef: {2}\n", matRef[1, j], matRef[0, j], strRefDev);
                        }
                    }
                }
            }
        }

        public static void MostrarMatrizDecod()
        {
            for (int i = 0; i < matDecod.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matDecod.GetLength(1); j++)//col
                {
                    Console.Write("| {0}", matDecod[i, j]);
                }
                Console.WriteLine("|");
            }
        }

        public static void InvertirMatrizClave()
        {
            matClaveInvert = new int[fila, fila];
            matClaveInvert[0, 0] = matClave[1, 1];
            matClaveInvert[0, 1] = matClave[0, 1] * (-1);
            matClaveInvert[1, 0] = matClave[1, 0] * (-1);
            matClaveInvert[1, 1] = matClave[0, 0];

        }

        public static void MostrarMatrizClaveInvert()
        {
            for (int i = 0; i < matClaveInvert.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matClaveInvert.GetLength(1); j++)//col
                {
                    if (matClaveInvert[i, j] < 10)
                    {
                        Console.Write("| {0}", matClaveInvert[i, j]);
                    }
                    else
                    {
                        Console.Write("|{0}", matClaveInvert[i, j]);
                    }
                }
                Console.WriteLine("|");
            }
        }

        public static void DesencriptarMatEncryp()
        {
            matDesEncryp = new int[fila,col];
            for (int l = 0; l < matEncryp.GetLength(1); l++)//col
            {
                matDesEncryp[0, l] = matClaveInvert[0, 0] * matEncryp[0, l] + matClaveInvert[0, 1] * matEncryp[1, l];//fila 0 de matCod
                matDesEncryp[1, l] = matClaveInvert[1, 0] * matEncryp[0, l] + matClaveInvert[1, 1] * matEncryp[1, l];//fila 0 de matCod
            }
        }

        public static void MostrarMatrizDesEncrip()
        {
            for (int i = 0; i < matDesEncryp.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matDesEncryp.GetLength(1); j++)//col
                {
                    if (matDesEncryp[i, j] < 10)
                    {
                        Console.Write("| {0}", matDesEncryp[i, j]);
                    }
                    else
                    {
                        Console.Write("|{0}", matDesEncryp[i, j]);
                    }
                }
                Console.WriteLine("|");
            }
        }

        public static void EncriptarMatrizCod()
        {
            matEncryp = new int[fila, col];
            for (int l = 0; l < matCod.GetLength(1); l++)//col
            {
                matEncryp[0,l] = matClave[0, 0] * matCod[0, l] + matClave[0, 1] * matCod[1, l];//fila 0 de matCod
                matEncryp[1,l] = matClave[1, 0] * matCod[0, l] + matClave[1, 1] * matCod[1, l];//fila 0 de matCod
            }
        }

        public static void MostrarMatrizEncrip()
        {
            for (int i = 0; i < matEncryp.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matEncryp.GetLength(1); j++)//col
                {
                    if (matEncryp[i, j] < 10)
                    {
                        Console.Write("| {0}", matEncryp[i, j]);
                    }else
                    {
                        Console.Write("|{0}", matEncryp[i, j]);
                    }
                }
                Console.WriteLine("|");
            }
        }

        public static void MostrarMensajeEncriptado()
        {
            for (int i = 0; i < matEncryp.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matEncryp.GetLength(1); j++)//col
                {
                    Console.Write("{0} ", matEncryp[i, j]);
                }
            }
        }

        public static void CrearMatrizAleatoria()//MATRIZ GENERADA ALEATORIAMENTE
        {
            Random rnd = new Random();
            matClave = new int[fila, fila];
            do
            {
                for (int i = 0; i < matClave.GetLength(0); i++)//fila
                {
                    for (int j = 0; j < matClave.GetLength(1); j++)//col
                    {
                        matClave[i, j] = rnd.Next(0, 10); //= rnd.Next(1, 50);// creates a number between 1 and 49
                    }
                }
                det = (matClave[0, 0] * matClave[1, 1]) - (matClave[0, 1] * matClave[1, 0]);
            } while (det != 1);
        }

        public static void MostrarMatrizAleat()
        {
            for (int i = 0; i < matClave.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matClave.GetLength(1); j++)//col
                {
                    if (matClave[i, j] < 10)
                    {
                        Console.Write("| {0}", matClave[i, j]);
                    }
                    else
                    {
                        Console.Write("|{0}", matClave[i, j]);
                    }
                }
                Console.WriteLine("|");
            }
        }

        public static void Codificar(string[,] matString)//COMPARA CADA ELEMENTO DE matString CON LOS DE matRef
        {
            matCod = new int[fila, col];
            for (int i = 0; i < matString.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matString.GetLength(1); j++)//col
                {
                    str = matString[i, j];
                    codRef = Int32.Parse(BuscarNroCodigo(str));//Envia el elemento a BuscarNroCodigo para 
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
                    //Console.WriteLine("str {0} / matRef {1},{2} es {3}", str, l, l, matRef[l,l]);
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
            matString = new string[fila,col];//instanciamos matString
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
                    //Console.Write("|{0}", matString[l, l]);
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

        public static void MostrarMatrizCod()
        {
            for (int i = 0; i < matCod.GetLength(0); i++)//fila
            {
                for (int j = 0; j < matCod.GetLength(1); j++)//col
                {
                    if (matCod[i, j] < 10)
                    {
                        Console.Write("| {0}", matCod[i, j]);
                    }else
                    {
                        Console.Write("|{0}", matCod[i, j]);
                    }
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
                    //if (l == 0)
                    //{
                        Console.Write("{0}", matRef[j, i]);
                    //}
                    //else
                    //{
                    //    Console.Write("{0}", matRef[l, l]);
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
