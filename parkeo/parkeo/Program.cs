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
                    break;
                default:
                    break;
            }
        }
        static void park()
        {
            string[,] parkinglot = new string[50, 10];
            print(parkinglot);
            //Console.WriteLine(parkinglot);
        }
        static void print(string[,] park)
        {
            Console.WriteLine("<=======================>");
            foreach (var val in park)
            {
                Console.WriteLine(val);
            }
        }
    }
}
