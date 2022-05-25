using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Proyecto
{
    class Program
    {
        static string[,] data = new string[10, 5];
        static string[,] parkinglot = new string[10, 5];
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una opcion:\n1-Parkeo");
            int sel = int.Parse(Console.ReadLine());
            park();
            switch (sel)
            {
                case 1:
                    registrar();
                    break;
                default:
                    break;
            }
        }

        static void park()
        {
           
            string[] letras = { "A", "B", "C", "D", "E" };
            
            for (int f = 0; f < 10; f++)
                
            {
                for (int c = 0; c < 5; c++)
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
            
        }

        static void registrar()
        {
            for (int f = 0; f < 10; f++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (data[f,c] == null)
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
            Console.WriteLine("Seleccione el campo que desea usar: ");
            string campo = Console.ReadLine();
            int[] adsdas = {1,2,3 }; 
            if(comprobar(parkinglot, campo))
            {
                Console.WriteLine("YES");
            } else
            {
                Console.WriteLine("Mamaste");
            }
        }

        static bool comprobar(string[,] matriz, string dato)
        {
            bool check = false;

            foreach (string item in matriz)
            {
               if(item == dato)
                {
                    return true;
                }
            }

            return check;
        }

        static void print(string park, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(park + "  ");
     
          
        }
    }
}
