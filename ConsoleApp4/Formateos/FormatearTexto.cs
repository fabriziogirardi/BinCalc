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
                                             string leftColor = "\u001b[92m",
                                             string rightColor = "\u001b[92m",
                                             string dotColor = "\u001b[0m")
        {
            int width = Console.WindowWidth;
            string resetColor = "\u001b[0m";

            Console.Write($"{leftColor}  - {left} {resetColor}");

            int used = left.Length + right.Length;
            int free = width - used - 10;

            for (int i = 0; i < free; i++)
                Console.Write($"{dotColor}.");

            Console.Write($"{rightColor} {right}    {resetColor}\r\n");
        }
    }
}
