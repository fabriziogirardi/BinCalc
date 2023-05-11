using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BinCalc.Calculadoras;
using BinCalc.MenuClases;

namespace BinCalc.Calculos
{
    internal class Enteros
    {
        public Menu menuAnterior { get; private set; }

        private bool errorLectura = false;

        private string? ultimaLectura;
        public Enteros(Menu root)
        {
            menuAnterior = root;
            Console.Clear();
        }

        public string LeerEntero()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el número entero: ");
            string? numero = Console.ReadLine();

            if (numero == null || numero == "")
            {
                menuAnterior.Run();
            }

            return numero;
        }

        public string LeerBinario(CalcularBinariosEnteros calc)
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("Ingrese el número binario (presione enter sin ingresar nada para volver atras): ");

            if (ultimaLectura != null && errorLectura)
            {
                Console.WriteLine($"La cadena {ultimaLectura} no es una cadena válida, intente nuevamente");
            }

            Console.WriteLine();

            if (calc.getBinario() != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Último binario procesado correctamente: {calc.getBinario()} ({calc.getBinario().Length} bits)");
                calc.MostrarResultados();
            }

            if (ultimaLectura != null && errorLectura)
                Console.SetCursorPosition(0, 2);
            else
                Console.SetCursorPosition(0, 1);
            string? bits = Console.ReadLine();

            string pattern = @"^[01]{2,32}$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled);
            Match match = reg.Match(bits != null ? bits : "");

            if (bits == null || bits == "")
            {
                Console.CursorVisible = false;
                menuAnterior.Run();
            }

            while (!match.Success)
            {
                
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nNo se aceptan cadenas vacías, ni cadenas con otros carácteres que no sean 1 y 0. Intente nuevamente.");
                Console.ResetColor();
                errorLectura = true;
                ultimaLectura = bits;
                bits = LeerBinario(calc);
                match = reg.Match(bits);
            }

            errorLectura = false;
            ultimaLectura = null;
            return bits;
        }

        public void EnteroBinario()
        {
            string entero = LeerEntero();
        }

        public void BinarioEntero()
        {
            CalcularBinariosEnteros calc = new CalcularBinariosEnteros();
            while (true)
            {
                string binario = LeerBinario(calc);
                calc.setBinario(binario);
            }
        }
    }
}
