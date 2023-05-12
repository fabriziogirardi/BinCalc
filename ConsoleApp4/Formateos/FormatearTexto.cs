using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCalc.Formateos
{
    internal class FormatearTexto
    {
        static public void RenglonesPunteados(string left,
                                             string right,
                                             ConsoleColor leftColor = ConsoleColor.Green,
                                             ConsoleColor rightColor = ConsoleColor.Green,
                                             ConsoleColor dotColor = ConsoleColor.White)
        {
            int width = Console.WindowWidth;


            Console.ForegroundColor = leftColor;
            Console.Write($"- {left} ");
            Console.ResetColor();

            int used = left.Length + right.Length;
            int free = width - used - 10;

            Console.ForegroundColor = dotColor;
            for (int i = 0; i < free; i++)
                Console.Write($".");
            Console.ResetColor();

            Console.ForegroundColor = rightColor;
            Console.Write($" {right}    \r\n");
            Console.ResetColor();
        }
    }
}
