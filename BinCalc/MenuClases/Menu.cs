using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCalc.MenuClases
{
    public class Menu
    {
        private readonly string Separador = " " + new string('#', 100);
        private string Encabezado;
        private List<MenuItem> Opciones;
        private Menu? Root;
        public Menu(string header, List<MenuItem> opciones, Menu? root = null)
        {
            Encabezado = header;
            Opciones = opciones;
            Root = root;
        }
        private void Print()
        {
            for (int index = 0; index < Opciones.Count; index++)
            {
                Console.Write($" #    ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{index + 1}");
                Console.ResetColor();
                Console.WriteLine($".- {Opciones[index].Titulo}");
                Console.ResetColor();
            }

            Console.WriteLine(" #");
            Console.Write($" #  Presione la opción deseada, o ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Opciones.Count + 1}");
            Console.ResetColor();
            Console.WriteLine($" para {(Root == null ? "salir" : "volver atrás")}");
        }

        private void FullPrint()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Separador);
            Console.WriteLine(" #");
            Console.WriteLine(" #  " + Encabezado);
            Console.WriteLine(" #");
            Print();
            Console.WriteLine(" #");
            Console.WriteLine(Separador);
        }

        private void FullPrint(string error)
        {
            FullPrint();
            Console.WriteLine();
            Console.WriteLine($"    {error}");
        }

        private void PrintExit()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Separador);
            Console.WriteLine(" #");
            Console.WriteLine($" #  Gracias por usar la aplicacion! Presione cualquier tecla para finalizar");
            Console.WriteLine(" #");
            Console.WriteLine(Separador);
        }
        public void Run()
        {
            FullPrint();
            byte opcion = SeleccionDelUsuario();
            if (opcion == Opciones.Count + 1)
            {
                if (Root == null)
                {
                    PrintExit();
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    return;
                }
                else
                {
                    Root.Run();
                }
            } 
            else
            {
                var action = Opciones[(byte)opcion - 1].Accion;
                if (action != null)
                    action();
                else
                {
                    Console.WriteLine("Opción no existente, por favor intente nuevamente");
                    Console.ReadKey();
                    Run();
                }
            }
        }
        byte SeleccionDelUsuario()
        {
            byte seleccion = 0;
            Action parsearSeleccion = () =>
            {
                byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out seleccion);
            };
            parsearSeleccion();
            while (seleccion < 1 || seleccion > Opciones.Count + 1)
            {
                FullPrint($"La opción {seleccion} no es válida, intente nuevamente");
                parsearSeleccion();
            }
            return seleccion;
        }
    }
}
