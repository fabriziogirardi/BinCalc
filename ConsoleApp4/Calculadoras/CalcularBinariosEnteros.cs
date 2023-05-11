using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinCalc.Formateos;

namespace BinCalc.Calculadoras
{
    /// <summary>
    /// Clase que genera los cálculos necesarios para saber cual es la correcta <br />
    /// interpretación de un binario como un entero en los distintos tipos <br />
    /// de interpretación <b>BSS</b>, <b>BCS</b>, <b>CA1</b>, <b>CA2</b>, <b>EX2</b>, <b>EX2-1</b>
    /// </summary>
    internal class CalcularBinariosEnteros
    {
        /// <summary>
        /// Variable que contiene la cadena de bits como string.
        /// </summary>
        private string? bits;

        /// <summary>
        /// Clase que genera los cálculos necesarios para saber cual es la correcta <br />
        /// interpretación de un binario como un entero en los distintos tipos <br />
        /// de interpretación <b>BSS</b>, <b>BCS</b>, <b>CA1</b>, <b>CA2</b>, <b>EX2</b>, <b>EX2-1</b>
        /// </summary>
        public CalcularBinariosEnteros()
        {
        }

        /// <summary>
        /// Clase que genera los cálculos necesarios para saber cual es la correcta <br />
        /// interpretación de un binario como un entero en los distintos tipos <br />
        /// de interpretación <b>BSS</b>, <b>BCS</b>, <b>CA1</b>, <b>CA2</b>, <b>EX2</b>, <b>EX2-1</b>
        /// </summary>
        /// <param name="bits">Cadena de bits que se usará para los cálculos</param>
        public CalcularBinariosEnteros(string bits)
        {
            this.bits = bits;
        }

        public void setBinario(string? bits)
        {
            this.bits = bits;
        }

        public string? getBinario()
        {
            return bits;
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena, interpretándola como BSS<br />
        /// Utiliza el valor almacenado en la propiedad "bits"
        /// </summary>
        /// <returns>int</returns>
        public int CalcularBSS()
        {
            return CalcularBSS(bits);
        }

        public int CalcularBSS(string bits)
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

        public int CalcularBCS()
        {
            int result = CalcularBSS(bits.Remove(0, 1));

            if (bits[0] == '1')
            {
                result *= -1;
            }

            return result;
        }

        private string InvertirBits()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < bits.Length; i++)
            {
                sb.Append(bits[i] == '0' ? '1' : '0');
            }

            return sb.ToString();
        }

        public int CalcularCA1()
        {
            if (bits[0] == '0')
                return CalcularBSS();

            string newbits = InvertirBits();

            return -1 * CalcularBSS(newbits);
        }

        public int CalcularCA2()
        {
            if (bits[0] == '0')
                return CalcularBSS();

            string newbits = InvertirBits();

            return CalcularCA1() - 1;
        }

        public int CalcularEX2()
        {
            return CalcularBSS() - Convert.ToInt32(Math.Pow(2, bits.Length - 1));
        }

        public int CalcularEX2Menos1()
        {
            return CalcularEX2() + 1;
        }

        public void MostrarResultados()
        {
            FormatearTexto.RenglonesPunteados("BSS", CalcularBSS().ToString());
            FormatearTexto.RenglonesPunteados("BCS", CalcularBCS().ToString());
            FormatearTexto.RenglonesPunteados("CA1", CalcularCA1().ToString());
            FormatearTexto.RenglonesPunteados("CA2", CalcularCA2().ToString());
            FormatearTexto.RenglonesPunteados("EX2", CalcularEX2().ToString());
            FormatearTexto.RenglonesPunteados("EX2-1", CalcularEX2Menos1().ToString());
        }
    }
}
