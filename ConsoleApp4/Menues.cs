using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BinCalc
{
    internal class Menues
    {
        private int seleccionActual;
        private string[] opcionesMenu = new string[2];

        public Menues()
        {
            configurarItems();
            mostrarItems(opcionesMenu);
            leerOpcionSeleccionada();
        }

        private void configurarItems()
        {
            opcionesMenu[0] = "Convertir enteros de binario a decimal";
            opcionesMenu[1] = "Convertir enteros de decimal a binario";
        }

        private void mostrarItems(string[] menu, bool alert = false)
        {
            int itemIndex = 0;

            Console.Write("\r\nSeleccione una de las opciones a continuación:\r\n\r\n");

            foreach (string item in menu)
            {
                Console.WriteLine(itemIndex + ". " + item);
                itemIndex++;
            }
        }

        private void leerOpcionSeleccionada()
        {
            Regex r = new Regex("^\\d+$");
            ConsoleKeyInfo s = Console.ReadKey();
            while(!r.Match(s.KeyChar.ToString()).Success)
            {
                Console.WriteLine("Error leyendo");
                s = Console.ReadKey();
            }
        }
    }
}
