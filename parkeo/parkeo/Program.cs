using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Proyecto
{
    class Program
    {
        static string[,][] data = new string[10, 5][];
        static string[,] parkinglot = new string[10, 5];
        static string[] reservados = new string[15];
        //static string[] ocupados = new string[15];

        static void Main(string[] args)
        {
            park();
            while (true)
            {
                
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("|         Parqueo el Buen Espacio           |");
                Console.WriteLine("<------------------------------------------->");
                Mostrar();
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("|  Disponibles    Ocupados    Reservados    |");
                Console.WriteLine("|    Verde          Rojo         Azul       |");
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("Ingrese una opcion:\n1-Registrar Entrada Ocacionales\n2-Retirar Auto\n3-Pago de Mensualidades\n4-Reportes");
                int sel = int.Parse(Console.ReadLine());
                switch (sel)
                {
                    case 1:
                        registrar();
                        break;
                    default:
                        break;
                }
            }
        }

        static void park()
        {
           
            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M","N", "O", "P", "Q", "R","S","T","U", "V","W","X","Y","Z" };
            
            for (int f = 0; f < parkinglot.GetLength(0); f++)
                
            {
                for (int c = 0; c < parkinglot.GetLength(1); c++)
                {
                    string linea;
                    if (f == 9)
                    {
                       linea = letras[c] + (f + 1) + "    ";
                    }
                    else
                    {
                        linea = letras[c] + (f + 1) + "     ";
                       
                    }
                    parkinglot[f, c] = (linea);
                }
            }
            string rnd = "";
            int ocupadosIndx = 0;
            Random random = new Random();
            while (ocupadosIndx < 15)
            {
                int[] indx = getIndex(random.Next(50));
                rnd = parkinglot[indx[0], indx[1]];
                while (Array.Exists(reservados, numero => numero == rnd))
                {
                    indx = getIndex(random.Next(50));
                    rnd = parkinglot[indx[0], indx[1]];
                }
                reservados.SetValue(rnd, ocupadosIndx);
                ocupadosIndx++;
            }

        }

        static void Mostrar()
        {
            for (int f = 0; f < parkinglot.GetLength(0); f++)
            {
                
                for (int c = 0; c < parkinglot.GetLength(1); c++)
                {
                    if (Array.Exists(reservados, numero => numero == parkinglot[f, c]))
                    {
                        print(parkinglot[f, c], ConsoleColor.Blue);
                    } else if (data[f,c] == null)
                    {
                        print(parkinglot[f, c], ConsoleColor.Green);
                    } else
                    {
                        print(parkinglot[f, c], ConsoleColor.Red);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            
        }

        static void registrar()
        {
            Console.WriteLine("Seleccione el campo que desea usar: ");
            string campo = Console.ReadLine();
            int num = comprobar(parkinglot, campo);
            int[] indice = getIndex(num);
            if (num > -1 && data[indice[0],indice[1]] == null && !Array.Exists(reservados, est => est == parkinglot[indice[0],indice[1]]))
            {
                Console.WriteLine("Ingrese la placa del vehiculo: ");
                string placa = Console.ReadLine();
                string fecha = DateTime.Now.ToString();
                string[] dataArr = {placa, fecha };
                data[indice[0], indice[1]] = dataArr;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("<---------------------------------------->");
                Console.WriteLine();
                Console.WriteLine("Espacio seleccionado correctamemte.");
                Console.WriteLine();
                Console.WriteLine("<---------------------------------------->");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("<---------------------------------------------------------->");
                Console.WriteLine();
                Console.WriteLine("El espacio seleccionado no esta disponible en este momento.");
                Console.WriteLine();
                Console.WriteLine("<---------------------------------------------------------->");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static int[] getIndex(int num)
        { //Obtiene el indice dentro de la matriz de un objeto en pantalla
            int[] index = new int[2];
            int uno = 0;
            for (int i = 0; i < parkinglot.GetLength(0); i++)
            {
                for (int j = 0; j < parkinglot.GetLength(1); j++)
                {
                    int dos = j;
                    int k = uno + dos;
                    if (num == k)
                    {
                        index[0] = i;
                        index[1] = j;
                        return index;
                    }
                }
                uno += parkinglot.GetLength(1); // Indica el numero de filas de la matriz. Siempre debe ser igual para evitar errores

            }
            return index;
        }

        static int comprobar(string[,] matriz, string dato)
        {
            int f = -1;
            
            foreach (string item in matriz)
            {
                f++;
                if (item.TrimEnd(' ').Equals(dato))
                {
                    int index = f;
                    return index;
                }
               
            }


            return -1;
        }

        static void print(string park, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(park + "  ");
     
          
        }
    }
}
