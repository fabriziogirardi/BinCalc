using BinCalc.Formateos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BinCalc.Calculadoras
{
    internal class CalcularEnterosBinarios
    {
        private int? entero;

        private string? BSS, BCS, CA1, CA2, EX2, EX2Menos1;

        private bool negativo = false;

        public CalcularEnterosBinarios()
        {
        }

        public CalcularEnterosBinarios(int entero)
        {
            this.entero = entero;
        }

        public void SetEntero(int entero)
        {
            this.entero = entero;
            if (entero < 0)
                negativo = true;
        }

        public int? GetEntero()
        {
            return entero;
        }

        public string CalcularEnteroBSS()
        {
            BSS = "";

            if (negativo)
                BSS = "No se pueden representar negativos";

            else if (entero == 0)
                BSS = "0";
            
            else
            {
                while (entero > 0)
                {
                    BSS = entero % 2 + BSS;
                    entero /= 2;
                }
            }

            return BSS;
        }

        public string CalcularEnteroBCS()
        {
            BCS = "";

            if (negativo)
                entero *= -1;

            while (entero != 0)
            {
                BCS = entero % 2 + BCS;
                entero /= 2;
            }

            BCS = (negativo ? "1" : "0") + BCS;

            return BCS;
        }

        public string CalcularEnteroCA1()
        {
            CA1 = "";

            if (!negativo)
                CA1 = BSS + "";
            else
            {
                for (int i = 0; i < BCS.Length; i++)
                {
                    if (BCS[i] == '0')
                        CA1 += '1';
                    else
                        CA1 += '0';
                }

                CA1 = "1" + CA1.Remove(0, 1);
            }

            return CA1;
        }

        public string CalcularEnteroCA2()
        {
            CA2 = "";

            if (!negativo)
                CA2 = BSS;
            else 
                CA2 = SumarBinarios(CA1, "1");

            return CA2;
        }

        public string CalcularEnteroEX2()
        {
            EX2 = "";

            if (!negativo)
                EX2 = "1" + BSS;
            else
                EX2 = "0" + CA2.Remove(0, 1);

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

        public void MostrarResultados()
        {
            FormatearTexto.RenglonesPunteados("BSS", CalcularEnteroBSS());
            FormatearTexto.RenglonesPunteados("BCS", CalcularEnteroBCS());
            FormatearTexto.RenglonesPunteados("CA1", CalcularEnteroCA1());
            FormatearTexto.RenglonesPunteados("CA2", CalcularEnteroCA2());
            FormatearTexto.RenglonesPunteados("EX2", CalcularEnteroEX2());
        }
    }
}
