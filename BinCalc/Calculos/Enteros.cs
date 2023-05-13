using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

        private bool errorLectura = false, breakLoop = false;

        private string? ultimaLectura;
        public Enteros(Menu root)
        {
            menuAnterior = root;
            Console.Clear();
        }

        public int LeerEntero(CalcularEnterosBinarios calc)
        {
            Console.Clear();
            Console.WriteLine("ATENCION! Por limitaciones de la calculadora, el número entero debe estar entre -2147483648 y 2147483647 (inclusive).");
            Console.WriteLine("Ingrese el número entero (presione enter sin ingresar nada para volver atras): ");

            if (ultimaLectura != null && errorLectura)
            {
                Console.WriteLine($"{ultimaLectura} no es un número entero válido, intente nuevamente");
            }

            Console.WriteLine();

            int? ultimoEntero = calc.GetEntero();

            if (ultimoEntero != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Último entero procesado correctamente: {ultimoEntero}");
                calc.MostrarResultados();
            }

            if (ultimaLectura != null && errorLectura)
                Console.SetCursorPosition(0, 3);
            else
                Console.SetCursorPosition(0, 2);

            string? numeroString = Console.ReadLine();

            if (numeroString == null || numeroString == "")
            {
                breakLoop = true;
                return 0;
            }

            if (!int.TryParse(numeroString, out int numero))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\nSolo se pueden ingresar números positivos o negativos.");
                Console.ResetColor();
                errorLectura = true;
                ultimaLectura = numeroString;
                numeroString = LeerEntero(calc).ToString();
            }

            errorLectura = false;
            ultimaLectura = null;
            return numero;
        }

        public string LeerBinario(CalcularBinariosEnteros calc)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el número binario (presione enter sin ingresar nada para volver atras): ");

            if (ultimaLectura != null && errorLectura)
            {
                Console.WriteLine($"La cadena {ultimaLectura} no es una cadena binaria válida, intente nuevamente");
            }

            Console.WriteLine();

            string ultimoBinario = calc.GetBinario();

            if (ultimoBinario != "")
            {
                Console.WriteLine();
                Console.WriteLine($"Último binario procesado correctamente: {ultimoBinario} ({ultimoBinario.Length} bits)");
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
                breakLoop = true;
                return "";
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
            CalcularEnterosBinarios calc = new CalcularEnterosBinarios();
            errorLectura = false;
            ultimaLectura = null;
            breakLoop = false;

            while (!breakLoop)
            {
                int entero = LeerEntero(calc);
                if (!breakLoop)
                    calc.SetEntero(entero);
            }

            menuAnterior.Run();
        }

        public void BinarioEntero()
        {
            CalcularBinariosEnteros calc = new CalcularBinariosEnteros();
            errorLectura = false;
            ultimaLectura = null;
            breakLoop = false;
            Console.CursorVisible = true;

            while (!breakLoop)
            {
                string binario = LeerBinario(calc);
                if (!breakLoop)
                    calc.SetBinario(binario);
            }

            Console.CursorVisible = false;
            menuAnterior.Run();
        }
    }
}
