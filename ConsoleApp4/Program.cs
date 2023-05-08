using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace BinCalc
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            Menues m = new();
            
            #pragma warning disable CA1416 // Validate platform compatibility
            Console.WindowWidth = 100;
            Console.WindowHeight = 25;
            #pragma warning restore CA1416 // Validate platform compatibility

            string bits = ReadBits();

            CalcularBinariosEnteros bits2 = new(bits);

            Console.WriteLine("\r\nEl valor de {0} en distintas interprestaciones es:\r\n", bits);

            WriteWithDots("Como BSS:", bits2.CalcularBSS().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            WriteWithDots("Como BCS:", bits2.CalcularBCS().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            WriteWithDots("Como CA1:", bits2.CalcularCA1().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            WriteWithDots("Como CA2:", bits2.CalcularCA2().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            WriteWithDots("Como EX2:", bits2.CalcularEX2().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            WriteWithDots("Como EX2-1:", bits2.CalcularEX2Menos1().ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 2);
            Console.ResetColor();

            Console.WriteLine("\r\n\r\nPresione ENTER para repetir con otro número, o ESC para salir");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

            while (consoleKeyInfo.Key != ConsoleKey.Escape && consoleKeyInfo.Key != ConsoleKey.Enter)

                consoleKeyInfo = Console.ReadKey(true);

            if (consoleKeyInfo.Key == ConsoleKey.Escape)
                return;

            if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main(args);
            }
        }

        static public void WriteWithDots(string left,
                                         string right,
                                         ConsoleColor leftColor = ConsoleColor.White,
                                         ConsoleColor rightColor = ConsoleColor.White,
                                         ConsoleColor dotColor = ConsoleColor.White,
                                         int divider = 2)
        {
            int width = Console.WindowWidth;

            Console.ForegroundColor = leftColor;
            Console.Write("  - " + left + " ");

            int used = left.Length + right.Length;

            Console.ForegroundColor = dotColor;

            for (int i = 0; i < ((width) - used - 10); i++)
                Console.Write(".");

            Console.ForegroundColor = rightColor;
            Console.Write(" " + right + "    \r\n");
        }

        static private string ReadBits()
        {
            Console.WriteLine("\r\nIngrese una cadena de 1 y 0 para calcular su valor en los diferentes sistemas.\r\nEl binario será tratado como un entero.\r\n\r\nBinario (min 2 bits, max 32 bits):");

            string? bits = Console.ReadLine();

            string pattern = @"^[01]{2,32}$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled);
            Match match = reg.Match(bits != null ? bits : "");

            while (bits == null || !match.Success)
            {
                Console.Clear();
                Console.BackgroundColor =ConsoleColor.Red;
                Console.WriteLine("\r\nNo se aceptan cadenas vacías, ni cadenas con otros carácteres que no sean 1 y 0. Intente nuevamente.");
                Console.ResetColor();
                bits = ReadBits();
                match = reg.Match(bits);
            }

            return bits;
        }
    }
}