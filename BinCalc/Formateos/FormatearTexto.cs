using System.Runtime.CompilerServices;

namespace BinCalc.Formateos
{
    /// <summary>
    /// Clase que contiene métodos estáticos para formatear texto en la consola.
    /// </summary>
    internal class FormatearTexto
    {
        /// <summary>
        /// Método para mostrar un renglón formateado a modo de columnas izquierda y derecha,
        /// con separación central de puntos.
        /// </summary>
        /// <param name="left">El valor a mostrar en la izquierda de la tabla.</param>
        /// <param name="right">El valor a mostrar en la derecha de la tabla.</param>
        /// <param name="leftColor">El color de los elementos de la izquierda.</param>
        /// <param name="rightColor">El color de los elementos de la derecha.</param>
        /// <param name="dotColor">El color de los puntos que separan los elementos.</param>
        static public void RenglonesPunteados(string left,
                                             string right,
                                             ConsoleColor leftColor = ConsoleColor.Green,
                                             ConsoleColor rightColor = ConsoleColor.Green,
                                             ConsoleColor dotColor = ConsoleColor.White)
        {

            int free = Console.WindowWidth - (left.Length + right.Length) - 11;

            ColorearRapido($"  - {left} ", leftColor);

            ColorearRapido(new string('.', free), dotColor);

            ColorearRapido($" {right}    \r\n", rightColor);
        }

        /// <summary>
        /// Método para mostrar rápidamente una cadena de texto con un color específico.
        /// No deja saltos de línea al finalizar.
        /// </summary>
        /// <param name="text">Texto a mostrar</param>
        /// <param name="color">Color a utilizar</param>
        static private void ColorearRapido(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
