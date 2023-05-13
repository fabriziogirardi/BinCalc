using BinCalc.Formateos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace BinCalc.Calculadoras
{
    internal class CalcularEnterosBinarios
    {
        private int? entero;

        private string ABS = "",
                        INV = "", 
                        BSS = "", 
                        BCS = "", 
                        CA1 = "", 
                        CA2 = "", 
                        EX2 = "";

        private bool negativo = false, cero = false;

        public CalcularEnterosBinarios()
        {
        }

        public CalcularEnterosBinarios(int entero)
        {
            this.entero = entero;
        }

        public void SetEntero(int entero)
        {
            if (entero == -0)
                entero = 0;

            this.entero = entero;
            negativo = entero < 0;
            cero = entero == 0;
        }

        public int? GetEntero()
        {
            return entero;
        }

        public string CalcularEnteroBSS()
        {
            BSS = "";

            if (negativo)
            {
                BSS = "No se pueden representar negativos";
                return BSS;
            }

            else if (entero == 0)
                BSS = "0";

            else
            {
                BSS = ABS;
            }

            BSS = LlenarCerosPositivo(BSS);

            return BSS;
        }

        public string CalcularEnteroBCS()
        {
            BCS = "";
            //int? enteroTmp = entero;

            //if (negativo)
            //    enteroTmp *= -1;

            //while (enteroTmp != 0)
            //{
            //    BCS = enteroTmp % 2 + BCS;
            //    enteroTmp /= 2;
            //}

            BCS = (negativo ? "1" : "0") + ABS;

            BCS = LlenarCerosNegativo(BCS);

            return BCS;
        }

        public string CalcularEnteroCA1()
        {
            CA1 = "";

            if (!negativo || cero)
            {
                CA1 = "0" + ABS;
                //CA1 = LlenarCerosPositivo(CA1);
            }
            else
            {
                CA1 = "1" + INV;
                //for (int i = 0; i < BCS.Length; i++)
                //{
                //    if (ABS[i] == '0')
                //        CA1 += '1';
                //    else
                //        CA1 += '0';
                //}

                //if (CA1[0] == '0')
                //    CA1 = CA1.Remove(0, 1);

                //CA1 = "1" + CA1.Remove(0, 1);
                //CA1 = LlenarUnos(CA1);
            }

            return CA1;
        }

        public string CalcularEnteroCA2()
        {
            CA2 = "";

            if (!negativo || cero)
                CA2 = CA1;
            else
            {
                CA2 = SumarBinarios(CA1.Remove(0,1), "1");

                if (CA2.Length == CA1.Length)
                {
                    CA2 = CA2.Remove(0, 1);
                }
                CA2 = "1" + CA2;
            }
            
            return CA2;
        }

        public string CalcularEnteroEX2()
        {
            EX2 = (QuitarPrecedentesCA2(CA2)[0] == '0' ? '1' : '0') + QuitarPrecedentesCA2(CA2).Remove(0, 1);

            return EX2;
        }

        public static string SumarBinarios(string a, string b)
        {
            string result = "";

            int s = 0;

            int i = a.Length - 1, j = b.Length - 1;

            while (i >= 0 || j >= 0 || s == 1)
            {
                s += ((i >= 0) ? a[i] - '0' : 0);
                s += ((j >= 0) ? b[j] - '0' : 0);
                result = (char)(s % 2 + '0') + result;

                s /= 2;
                i--; j--;
            }

            return result;
        }

        private void CalcularAbsoluto()
        {
            ABS = "";
            decimal.TryParse(entero.ToString(), out decimal absoluto);
            int.TryParse(Math.Abs(absoluto).ToString(), out int enteroTmp);

            while (enteroTmp > 0)
            {
                ABS = enteroTmp % 2 + ABS;
                enteroTmp /= 2;
            }
        }

        private void InvertirAbsoluto()
        {
            INV = "";
            for (int i = 0; i < ABS.Length; i++)
            {
                if (ABS[i] == '0')
                    INV += '1';
                else
                    INV += '0';
            }
        }

        private void CalculosIniciales()
        {
            CalcularAbsoluto();
            InvertirAbsoluto();
        }

        private string LlenarCerosPositivo(string valor)
        {
            string cerosAdicionales = "";
            int calculoFaltantes = valor.Length % 8;
            int cantidadDeCeros = calculoFaltantes != 0 ? 8 - calculoFaltantes : 0;

            for (int i = 0; i < cantidadDeCeros; i++)
            {
                cerosAdicionales += "0";
            }

            return cerosAdicionales + valor;
        }

        private string LlenarCerosNegativo(string valor)
        {
            string cerosAdicionales = "";
            int calculoFaltantes = valor.Length % 8;
            int cantidadDeCeros = calculoFaltantes != 0 ? 8 - calculoFaltantes : 0;

            for (int i = 0; i < cantidadDeCeros; i++)
            {
                cerosAdicionales += "0";
            }

            return valor[0] + cerosAdicionales + valor.Remove(0, 1);
        }

        private string LlenarUnos(string valor)
        {
            string unosAdicionales = "";
            int calculoFaltantes = valor.Length % 8;
            int cantidadDeUnos = calculoFaltantes != 0 ? 8 - calculoFaltantes : 0;

            for (int i = 0; i < cantidadDeUnos; i++)
            {
                unosAdicionales += "1";
            }

            return valor[0] + unosAdicionales + valor.Remove(0, 1);
        }

        private string QuitarPrecedentesBSS(string numero)
        {
            int index = 0;

            string pattern = @"^[01]+$";
            Regex r = new Regex(pattern);

            Match m = r.Match(numero);

            if (!m.Success) { 
                return numero;
            }

            while (index < numero.Length && numero[index] == '0')
            {
                index++;
            }

            if (index == numero.Length)
                index--;

            return numero.Remove(0, index);
        }

        private string QuitarPrecedentesBCS(string numero)
        {
            int index = 1;

            while (index < numero.Length && numero[index] == '0')
            {
                index++;
            }

            return numero.Remove(1, index - 1);
        }

        private string QuitarPrecedentesCA1(string numero)
        {
            int index = 1;

            while (index < numero.Length
                && ((numero.StartsWith('0') && numero[index] == '0')
                    || (numero.StartsWith('1') && numero[index] == '1')))
            {
                index++;
            }
            return numero.Remove(1, index - 1);
        }

        private string QuitarPrecedentesCA2(string numero)
        {
            int index = 1;

            while (index < numero.Length
                && ((numero.StartsWith('0') && numero[index] == '0')
                    || (numero.StartsWith('1') && numero[index] == '1')))
            {
                index++;
            }
            return numero.Remove(1, index - 1);
        }

        private string QuitarPrecedentesEX2(string numero)
        {
            return numero;
        }

        private string QuitarUnosPrecedentes(string numero)
        {
            int index = 0;

            while (numero[index] == '1')
            {
                index++;
            }

            return numero.Remove(0, index-1);
        }

        private string FormatoConBitsAlFinal(string numero)
        {
            return numero + $" ({numero.Length} bit/s)";
        }

        public void MostrarResultados()
        {
            CalculosIniciales();
            CalcularEnteroBSS();
            CalcularEnteroBCS();
            CalcularEnteroCA1();
            CalcularEnteroCA2();
            CalcularEnteroEX2();

            string numBSS;
            if (!negativo)
                numBSS = FormatoConBitsAlFinal(QuitarPrecedentesBSS(BSS));
            else
                numBSS = BSS;

            string numBCS = FormatoConBitsAlFinal(QuitarPrecedentesBCS(BCS));
            string numCA1 = FormatoConBitsAlFinal(QuitarPrecedentesCA1(CA1));
            string numCA2 = FormatoConBitsAlFinal(QuitarPrecedentesCA2(CA2));
            string numEX2 = FormatoConBitsAlFinal(QuitarPrecedentesEX2(EX2));

            FormatearTexto.RenglonesPunteados("BSS", numBSS);
            FormatearTexto.RenglonesPunteados("BCS", numBCS);
            FormatearTexto.RenglonesPunteados("CA1", numCA1);
            FormatearTexto.RenglonesPunteados("CA2", numCA2);
            FormatearTexto.RenglonesPunteados("EX2", numEX2);
        }
    }
}
