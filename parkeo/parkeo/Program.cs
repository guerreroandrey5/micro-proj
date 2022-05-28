using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Proyecto
{
    class Program
    {
        #region Variables
        static string[,][] data = new string[10, 5][];
        static string[,] parkinglot = new string[10, 5];
        static string[] reservados = new string[20];
        static int[] ganancias = new int[3];
        static string[] reports = new string[10];
        static int ind = 16;
        #endregion
        static void Main(string[] args)
        {
            bool VIP = false;
            park();
            while (true)
            {
                #region Menu
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("|         Parqueo el Buen Espacio           |");
                Console.WriteLine("<------------------------------------------->");
                Console.ForegroundColor = ConsoleColor.Green;
                mostrar();
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("|  Disponibles    Ocupados    Reservados    |");
                Console.WriteLine("|    Verde          Rojo         Azul       |");
                Console.WriteLine("<------------------------------------------->");
                Console.WriteLine("Ingrese una opcion:\n1-Registrar Entrada Ocacionales\n2-Retirar Auto\n3-Pago de Mensualidades\n4-Reportes");
                int sel = int.Parse(Console.ReadLine());
                switch (sel)
                {
                    case 1:                       
                        registrar(VIP);
                        break;
                    case 2:
                        cobrar();
                        break;
                    case 3:
                        VIP = true;
                        registrar(VIP);
                        break;
                    case 4:
                        mostrarReporte();
                        break;
                    default:
                        break;
                }
                #endregion
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

        static void mostrar()
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

        static void registrar(bool VIP)
        {
            Console.WriteLine("Seleccione el campo que desea usar: ");
            string campo = Console.ReadLine();
            int num = comprobar(parkinglot, campo);
            int[] indice = getIndex(num);
            if (num > -1 && data[indice[0], indice[1]] == null && !Array.Exists(reservados, est => est == parkinglot[indice[0], indice[1]]))
            {
                Console.WriteLine("Ingrese la placa del vehiculo: ");
                string placa = Console.ReadLine();
                string fecha = DateTime.Now.ToString();
                if (!VIP)
                {
                    string[] dataArr = { placa, fecha };
                    data[indice[0], indice[1]] = dataArr;
                }                
                if (VIP)
                {
                    string rnd = "";
                    rnd = parkinglot[indice[0], indice[1]];
                    reservados.SetValue(rnd, ind);
                    ind++;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    ganancias[0] += 20000;
                }
                #region Prints de Registro/Reserva
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("<----------------------------------->");
                Console.WriteLine();
                Console.WriteLine("Espacio seleccionado correctamemte.");
                Console.WriteLine();
                Console.WriteLine("<----------------------------------->");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (VIP)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Console.WriteLine("<------------------------------------------------------------->");
                    Console.WriteLine("|                                                             |");
                    Console.WriteLine("|    Muchas gracias por reservar en Parqueo el Buen Espacio!  |");
                    Console.WriteLine("|                                                             |");
                    Console.WriteLine("<------------------------------------------------------------->");
                    Console.WriteLine("|  Espacio Reservado: {0}                                      |", campo);
                    Console.WriteLine("|  Placa del Vehículo: {0}                                  |", placa);
                    Console.WriteLine("|                                                             |");
                    Console.WriteLine("|  Total a Pagar: 20000 Colones                               |");
                    Console.WriteLine("<------------------------------------------------------------->");
                }
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
                #endregion
            }
        }
        
        static int[] getIndex(int num)
        {   
            //Obtiene el indice dentro de la matriz de un objeto en pantalla
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
            foreach (var item in matriz)
            {
                f++;
                if (item.TrimEnd(' ').Equals(dato))
                {
                    return f;
                }             
            }
            return -1;
        }

        static int comprobarData(string[,][] matriz, string dato)
        {
            int f = -1;
            foreach (var item in matriz)
            {
                f++;
                if (item != null && item[0].TrimEnd(' ').Equals(dato))
                {
                    return f;
                }
            }
            return -1;
        }

        static void print(string park, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(park + "  ");         
        }

        static void cobrar()
        {
            Console.WriteLine("Digite la placa del Vehiculo:");
            string placa = Console.ReadLine();
            string date = "";
            int pago = 0;
            int[] indice = null;
            bool lavado = false;
            DateTime now = DateTime.Now;
            TimeSpan hours;    
                int exts = comprobarData(data, placa);
                if (exts != -1)
                {
                    indice = getIndex(exts);
                    date = data[indice[0], indice[1]][1];
                    hours = now - DateTime.Parse(date);
                    pago = calcularPago(hours);
                }
                while (true)
                {
                    Console.WriteLine("Por favor indique si se uso el servicio de lavado\n1-Si\n2-No");
                    int select = int.Parse(Console.ReadLine());
                    if (select > 2)
                    {
                        Console.WriteLine();
                        print("Seleccion inválida", ConsoleColor.Red);
                        print("", ConsoleColor.White);
                    }
                    else if (select == 2)
                    {
                        break;
                    }
                    else if (select == 1)
                    {
                        ganancias[2] += 5000;
                        lavado = true;
                        pago += 5000;
                        break;
                    }
                }
                mostrarRecibo(date, now, parkinglot[indice[0], indice[1]], pago, lavado);
        }

        static void mostrarRecibo(string entrada, DateTime salida, string espacio, int total, bool serviciol)
        {
            String serv = "";
            if (serviciol){
                serv = "Si";
            }
            else
            {
                serv = "No";
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("<---------------------------------------------------------->");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|    Muchas gracias por venir al Parqueo el Buen Espacio!  |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("<---------------------------------------------------------->");
            Console.WriteLine("|  Espacio Utilizado:  {0}                             |", espacio);
            Console.WriteLine("|  Hora de Entrada:    {0}                  |", entrada);
            Console.WriteLine("|  Hora de Salida:     {0}                  |", salida);
            Console.WriteLine("|  Servicio de Lavado: {0}                                  |", serv);
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|  Total a Pagar: {0} Colones                             |", total);
            Console.WriteLine("<---------------------------------------------------------->");            
        }    

        static int calcularPago(TimeSpan tiempo)
        {
            int pago = 0;
            int horas = tiempo.Hours;
            if (horas == 0)
            {
                horas = 1;
            }

            Console.WriteLine(horas);
            while (horas != 0)
            {
                pago += 500;
                horas--;
            }
            ganancias[1] += pago;
            return pago;
        }

        static void mostrarReporte()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("<------------------------------------------------------------->");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|                     Reportes del Dia                        |");
            Console.WriteLine("|                                                             |");
            Console.WriteLine("<------------------------------------------------------------->");
            Console.WriteLine("|  Ganancias Obtenidas por miembros: {0} Colones            |", ganancias[0]);
            Console.WriteLine("|  Ganancias Obtenidas por Ocasionales: {0} Colones         |", ganancias[1]);
            Console.WriteLine("|  Ganancias Obtenidas por el Lavado de Autos: {0} Colones  |", ganancias[2]);
            Console.WriteLine("|                                                             |");
            Console.WriteLine("|  Total del Dia: {0} Colones                               |", (ganancias[0] + ganancias[1] + ganancias[2]));
            Console.WriteLine("<------------------------------------------------------------->");
        }
    }
}