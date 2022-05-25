using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una opcion:\n1-Parkeo");
            int sel = int.Parse(Console.ReadLine());
            switch (sel)
            {
                case 1:
                    park();
                    //wapo
                    break;
                default:
                    break;
            }
        }
        static void park()
        {
            string[,] parkinglot = new string[10, 5];
            string[] letras = { "A", "B", "C", "D", "E" };
            for (int f = 0; f < 10; f ++)
            {
                for (int c = 0; c < 5; c++)
                {
                    string linea;
                    linea = letras[c] + (f);
                    parkinglot[f, c] = (linea);
                }
            }
            print(parkinglot);
        }
        static void print(string[,] park)
        {
            {
                for (int f = 0; f < 10; f++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        Console.Write(park[f, c] + "  ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
}
