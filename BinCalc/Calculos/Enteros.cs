using BinCalc.Calculadoras;
using BinCalc.MenuClases;
using System.Text.RegularExpressions;

namespace BinCalc.Calculos
{
    /// <summary>
    /// Clase que engloba las acciones del menú de enteros. Desde acá se despachan los métodos
    /// a ejecutar dependiendo la opción seleccionada por el usuario, se parsea el número entero
    /// o la cadena binaria, se crea el objeto que contiene los métodos para calcular, se le
    /// pasan los datos a calcular y se muestran los resultados.
    /// </summary>
    internal class Enteros
    {
        /// <summary>
        /// <see cref="Menu"/> anterior. En caso de ingresar un valor vacío o nulo, se vuelve al menú anterior.
        /// </summary>
        public Menu menuAnterior { get; private set; }

        /// <summary>
        /// Banderas que identifican si hubo un error de lectura.
        /// </summary>
        private bool errorLectura = false;
            
        /// <summary>
        /// Bandera que identifica si se debe salir del loop principal para volver al menu anterior.
        /// </summary>
        private bool breakLoop = false;

        /// <summary>
        /// Última lectura realizada por el usuario.
        /// </summary>
        private string? ultimaLectura;

        /// <summary>
        /// Constructor de la clase. Recibe un único parámetro, el <see cref="Menu"/> anterior.
        /// Al crearse, borra la consola.
        /// </summary>
        /// <param name="root">El <see cref="Menu"/> anterior</param>
        public Enteros(Menu root)
        {
            menuAnterior = root;
            Console.Clear();
        }

        /// <summary>
        /// Lee un entero y lo procesa
        /// </summary>
        /// <param name="calc">Objeto de la clase que realiza los cálculos</param>
        /// <returns>El número entero leído, o 0 si no hubo lectura o fue nula.</returns>
        public int LeerEntero(CalcularEnterosBinarios calc)
        {
            Console.Clear();
            Console.WriteLine("ATENCION! Por limitaciones de la calculadora, el número entero debe estar entre -2147483648 y 2147483647 (inclusive).");
            Console.WriteLine("Ingrese el número entero (presione enter sin ingresar nada para volver atras): ");

            if (ultimaLectura != null && errorLectura)
            {
                Console.WriteLine($"{ultimaLectura} no es un número entero válido, intente nuevamente");
            }

            Console.WriteLine();

            int? ultimoEntero = calc.GetEntero();

            if (ultimoEntero != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Último entero procesado correctamente: {ultimoEntero}");
                calc.MostrarResultados();
            }

            if (ultimaLectura != null && errorLectura)
                Console.SetCursorPosition(0, 3);
            else
                Console.SetCursorPosition(0, 2);

            string? numeroString = Console.ReadLine();

            if (numeroString == null || numeroString == "")
            {
                breakLoop = true;
                return 0;
            }

            Console.Clear();

            if (!int.TryParse(numeroString, out int numero))
            {
                errorLectura = true;
                ultimaLectura = numeroString;
                numeroString = LeerEntero(calc).ToString();
            }

            errorLectura = false;
            ultimaLectura = null;
            return numero;
        }

        /// <summary>
        /// Lee una cadena binaria y la procesa.
        /// </summary>
        /// <param name="calc">Objeto de la clase que realiza los cálculos</param>
        /// <returns>Una cadena de 1 y 0</returns>
        public string LeerBinario(CalcularBinariosEnteros calc)
        {
            Console.WriteLine("Ingrese el número binario (presione enter sin ingresar nada para volver atras): ");

            if (ultimaLectura != null && errorLectura)
            {
                Console.WriteLine($"La cadena {ultimaLectura} no es una cadena binaria válida, intente nuevamente");
            }

            Console.WriteLine();

            string ultimoBinario = calc.GetBinario();

            if (ultimoBinario != "")
            {
                Console.WriteLine();
                Console.WriteLine($"Último binario procesado correctamente: {ultimoBinario} ({ultimoBinario.Length} bits)");
                calc.MostrarResultados();
            }

            if (ultimaLectura != null && errorLectura)
                Console.SetCursorPosition(0, 2);
            else
                Console.SetCursorPosition(0, 1);
            string? bits = Console.ReadLine();

            string pattern = @"^[01]{2,32}$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled);
            Match match = reg.Match(bits != null ? bits : "");

            if (bits == null || bits == "")
            {
                breakLoop = true;
                return "";
            }

            Console.Clear();

            while (!match.Success)
            {
                errorLectura = true;
                ultimaLectura = bits;
                bits = LeerBinario(calc);
                match = reg.Match(bits);
            }

            errorLectura = false;
            ultimaLectura = null;
            return bits;
        }

        /// <summary>
        /// Método que se ejecuta al seleccionar la opción "Entero a binario" del menú principal.
        /// </summary>
        public void EnteroBinario()
        {
            CalcularEnterosBinarios calc = new CalcularEnterosBinarios();
            PrepararLectura();

            while (!breakLoop)
            {
                int entero = LeerEntero(calc);
                if (!breakLoop)
                    calc.SetEntero(entero);
            }

            End();
        }

        /// <summary>
        /// Método que se ejecuta al seleccionar la opción "Binario a entero" del menú principal.
        /// </summary>
        public void BinarioEntero()
        {
            CalcularBinariosEnteros calc = new CalcularBinariosEnteros();
            PrepararLectura();

            while (!breakLoop)
            {
                string binario = LeerBinario(calc);
                if (!breakLoop)
                    calc.SetBinario(binario);
            }

            End();
        }

        /// <summary>
        /// Método que limpia los flags de error, lectura y breakLoop, y hace visible el cursor.
        /// </summary>
        private void PrepararLectura()
        {
            errorLectura = false;
            ultimaLectura = null;
            breakLoop = false;
            Console.CursorVisible = true;
            Console.Clear();
        }

        /// <summary>
        /// Método que finaliza la ejecución de este menú y vuelve al menú anterior.
        /// </summary>
        private void End()
        {
            Console.CursorVisible = false;
            menuAnterior.Run();
        }
    }
}
