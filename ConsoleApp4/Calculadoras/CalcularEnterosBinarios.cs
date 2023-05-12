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

        private string? ABS, INV, BSS, BCS, CA1, CA2, EX2, EX2Menos1;

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
            negativo = entero < 0;
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
                BSS = "0 (0 bits)";

            else
            {
                BSS = ABS;
            }

            return BSS + $" ({BSS.Length} bits)";
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

            return BCS + $" ({BCS.Length} bits)";
        }

        public string CalcularEnteroCA1()
        {
            CA1 = "";

            if (!negativo)
                CA1 = "0" + ABS;
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
            }

            return CA1 + $" ({CA1.Length} bits)";
        }

        public string CalcularEnteroCA2()
        {
            CA2 = "";

            if (!negativo)
                CA2 = "0" + BSS;
            else
            {
                CA2 = SumarBinarios(CA1, "1");
                CA2 = CA2.Remove(0, 1);
                
                if (CA2.Length > CA1.Length || Math.Pow(2, CA2.Length-1)*-1 == entero)
                {
                    CA2 = CA2.Remove(0, 1);
                }
                CA2 = "1" + CA2;
            }

            return CA2 + $" ({CA2.Length} bits)";
        }

        public string CalcularEnteroEX2()
        {
            EX2 = "";

            if (!negativo)
                EX2 = (CA2[0] == '0' ? '1' : '0') + CA2.Remove(0, 1);
            else
                EX2 = "0" + CA2.Remove(0, 1);

            return EX2 + $" ({EX2.Length} bits)";
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

        public void MostrarResultados()
        {
            CalculosIniciales();
            
            FormatearTexto.RenglonesPunteados("BSS", CalcularEnteroBSS());
            FormatearTexto.RenglonesPunteados("BCS", CalcularEnteroBCS());
            FormatearTexto.RenglonesPunteados("CA1", CalcularEnteroCA1());
            FormatearTexto.RenglonesPunteados("CA2", CalcularEnteroCA2());
            FormatearTexto.RenglonesPunteados("EX2", CalcularEnteroEX2());
        }
    }
}
