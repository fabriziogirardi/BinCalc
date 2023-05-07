using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            string bits = ReadBits();

            int valueBSS = CalculateBSSValue(bits);
            int valueBCS = CalculateBCSValue(bits);
            int valueCA1 = CalculateCA1Value(bits);
            int valueCA2 = CalculateCA2Value(bits);
            int valueEX2 = CalculateEX2Value(bits);
            int valueEXCustom = CalculateEXCustomValue(bits);

            int width = Console.LargestWindowWidth;

            Console.WriteLine("\r\nEl valor de {0} en distintas interprestaciones es:\r\n", bits);
            WriteWithDots("Como BSS:", valueBSS.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
            WriteWithDots("Como BCS:", valueBCS.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
            WriteWithDots("Como CA1:", valueCA1.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
            WriteWithDots("Como CA2:", valueCA2.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
            WriteWithDots("Como EX2:", valueEX2.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
            WriteWithDots("Como EX2-1:", valueEXCustom.ToString(), ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White, 4);
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
            int width = Console.LargestWindowWidth;

            Console.ForegroundColor = leftColor;
            Console.Write(left + " ");

            int used = left.Length + right.Length;

            Console.ForegroundColor = dotColor;

            for (int i = 0; i < ((width / divider) - used - 2); i++)
                Console.Write(".");

            Console.ForegroundColor = rightColor;
            Console.Write(" " + right + "\r\n");
        }

        static private string ReadBits()
        {
            Console.WriteLine("\r\nIngrese una cadena de 1 y 0 para calcular su valor en los diferentes sistemas.\r\nEl binario será tratado como un entero.\r\n\r\nBinario:");

            string? bits = Console.ReadLine();

            string pattern = @"^[01]+$";
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

        static private int CalculateBSSValue(string bits)
        {
            int result = 0;
            int exp = 0;
            
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                result += Convert.ToInt32(char.GetNumericValue(bits[i]) * Math.Pow(2, exp));
                exp++;
            }

            return result;
        }

        static private int CalculateBCSValue(string bits)
        {
            int result = CalculateBSSValue(bits.Remove(0, 1));

            if (bits[0] == '1')
            {
                result *= -1;
            }

            return result;
        }

        static private string ReverseBits(string bits)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < bits.Length; i++)
            {
                sb.Append(bits[i] == '0' ? '1' : '0');
            }

            return sb.ToString();
        }

        static private int CalculateCA1Value(string bits)
        {
            if (bits[0] == '0')
                return CalculateBSSValue(bits);

            string newbits = ReverseBits(bits);
            
            return -1 * CalculateBSSValue(newbits);
        }

        static private int CalculateCA2Value(string bits)
        {
            if (bits[0] == '0')
                return CalculateBSSValue(bits);

            string newbits = ReverseBits(bits);

            return CalculateCA1Value(bits) - 1;
        }

        static private int CalculateEX2Value(string bits)
        {
            return CalculateBSSValue(bits) - Convert.ToInt32(Math.Pow(2, bits.Length - 1));
        }

        static private int CalculateEXCustomValue(string bits)
        {
            return CalculateEX2Value(bits) + 1;
        }
    }
}