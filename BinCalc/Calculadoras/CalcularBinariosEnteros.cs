using System.Text;
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
        private string bits = "", bitsInvertidos = "";

        /// <summary>
        /// Variables que contienen los valores de los cálculos de los distintos tipos de interpretación.
        /// </summary>
        private int ENT, ENTINV, BSS, BCS, CA1, CA2, EX2, EX2_1;

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

        /// <summary>
        /// Método para setear el binario externamente.
        /// </summary>
        /// <param name="bits">La cadena binaria a procesar</param>
        public void SetBinario(string bits)
        {
            this.bits = bits;
        }

        /// <summary>
        /// Método para obtener desde el exterior
        /// la cadena binaria actualmente almacenada en la clase.
        /// </summary>
        /// <returns><see cref="string"/>, la cadena binaria actual.</returns>
        public string GetBinario()
        {
            return bits;
        }

        /// <summary>
        /// Ejecuta las acciones de cálculos y genera los resultados.
        /// </summary>
        public void Run()
        {
            CalcularEntero();
            InvertirBits();
            CalcularEnteroInv();
            CalcularBSS();
            CalcularBCS();
            CalcularCA1();
            CalcularCA2();
            CalcularEX2();
            CalcularEX2Menos1();
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena de bits normal.
        /// </summary>
        private void CalcularEntero()
        {
            ENT = 0;
            int exp = 0;
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                ENT += Convert.ToInt32(char.GetNumericValue(bits[i]) * Math.Pow(2, exp));
                exp++;
            }
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena de bits invertidos.
        /// </summary>
        private void CalcularEnteroInv()
        {
            ENTINV = 0;
            int exp = 0;
            for (int i = bitsInvertidos.Length - 1; i >= 0; i--)
            {
                ENTINV += Convert.ToInt32(char.GetNumericValue(bitsInvertidos[i]) * Math.Pow(2, exp));
                exp++;
            }
        }

        /// <summary>
        /// Invierte la cadena de bits y la almacena en la propiedad "bitsInvertidos"
        /// convirtiendo los ceros en unos y viceversa.
        /// </summary>
        private void InvertirBits()
        {
            bitsInvertidos = "";

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < bits.Length; i++)
            {
                sb.Append(bits[i] == '0' ? '1' : '0');
            }

            bitsInvertidos = sb.ToString();
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena, interpretándola como BSS<br />
        /// Utiliza el valor almacenado en la propiedad "bits"
        /// </summary>
        //public void CalcularBSS()
        //{
        //    //BSS = CalcularBSS(bits ?? "");
        //}

        /// <summary>
        /// Calcula el valor decimal de la cadena, interpretándola como BCS
        /// </summary>
        public void CalcularBSS()
        {
            BSS = ENT;
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena, interpretándola como BCS
        /// </summary>
        public void CalcularBCS()
        {
            int result = BSS;

            if (bits[0] == '1')
            {
                result -= Convert.ToInt32(Math.Pow(2, bits.Length - 1));
                result *= -1;
            }

            BCS = result;
        }

        /// <summary>
        /// Calcula el valor decimal de la cadena, interpretándola como CA1
        /// </summary>
        public void CalcularCA1()
        {
            if (bits[0] == '0')
                CA1 = BSS;
            else
                CA1 = -1 * ENTINV;
        }

        public void CalcularCA2()
        {
            if (bits[0] == '0')
                CA2 = BSS;
            else
                CA2 = CA1 - 1;
        }

        public void CalcularEX2()
        {
            EX2 = BSS - Convert.ToInt32(Math.Pow(2, bits.Length - 1));
        }

        public void CalcularEX2Menos1()
        {
            EX2_1 = EX2 + 1;
        }

        public void MostrarResultados()
        {
            Run();
            FormatearTexto.RenglonesPunteados("BSS", BSS.ToString());
            FormatearTexto.RenglonesPunteados("BCS", BCS.ToString());
            FormatearTexto.RenglonesPunteados("CA1", CA1.ToString());
            FormatearTexto.RenglonesPunteados("CA2", CA2.ToString());
            FormatearTexto.RenglonesPunteados("EX2", EX2.ToString());
        }
    }
}
