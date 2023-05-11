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
        private Dictionary<int, Dictionary<string, string>> menuPrincipal = new Dictionary<int, Dictionary<string, string>>();
        private string[] submenuDecimalesABinario = new string[2];


        public Menues()
        {
            configurarItems();
            mostrarItems(menuPrincipal);
            leerOpcionSeleccionada();
        }

        private void configurarItems()
        {
            menuPrincipal[0].Add("Hola", "lala");
            //menuPrincipal[1] = "Convertir enteros de decimal a binario";
            submenuDecimalesABinario[0] = "Restringido a X cantidad de bits";
            submenuDecimalesABinario[1] = "Sin restricciones de bits (usar los que sean necesarios)";
        }

        private void mostrarItems(Dictionary<int, Dictionary<string, string>> menu, bool alert = false)
        {
            int itemIndex = 0;

            Console.Write("\r\nSeleccione una de las opciones a continuación:\r\n\r\n");

            foreach (KeyValuePair<int, Dictionary<string, string>> item in menu)
            {
                foreach (KeyValuePair<string, string> keyValuePair in menu[item.Key]) { 
                    Console.WriteLine(keyValuePair.Value);
                }
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
