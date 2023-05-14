namespace BinCalc.MenuClases
{
    /// <summary>
    /// Clase que administra un menú de opciones
    /// Permite poner un encabezado, una lista de opciones
    /// que permiten acceder a nuevos sub-menu, y una opción
    /// de contener un menu padre, para poder volver atrás.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// El separador es un string que se imprime antes y después
        /// del menu en su totalidad, para darle un aspecto más
        /// amigable para el usuario
        /// </summary>
        private readonly string Separador = " " + new string('#', 100);

        /// <summary>
        /// El encabezado es un string que se imprime en la parte
        /// superior del menu, debajo del separador superior.
        /// Funciona como título y/o breve descripción del menu.
        /// </summary>
        private string Encabezado;

        /// <summary>
        /// La lista de opciones es una lista de objetos <see cref="MenuItem"/>
        /// la cual será usada para loopear e imprimir cada una de las 
        /// opciones que el usuario puede seleccionar.
        /// </summary>
        private List<MenuItem> Opciones;

        /// <summary>
        /// El menu padre es un objeto <see cref="Menu"/> que se usa para poder
        /// regresar atrás en caso de que el menú actual sea un sub-menu.
        /// </summary>
        private Menu? Root;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="header">El encabezado/título del menú</param>
        /// <param name="opciones">Lista de opciones del menú</param>
        /// <param name="root">Menú padre en caso de haber uno. Por default es <i><b>null</b></i>.</param>
        public Menu(string header, List<MenuItem> opciones, Menu? root = null)
        {
            Encabezado = header;
            Opciones = opciones;
            Root = root;
        }

        /// <summary>
        /// Función que imprime los elementos del menú en la pantalla y les asigna
        /// un número de opción a cada uno.
        /// </summary>
        private void Print()
        {
            // Imprimir cada una de las opciones del menu
            for (int index = 0; index < Opciones.Count; index++)
            {
                Console.Write($" #    ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{index + 1}");
                Console.ResetColor();
                Console.WriteLine($". {Opciones[index].Titulo}");
                Console.ResetColor();
            }

            // Imprimir la opción para volver atrás
            Console.WriteLine(" #");
            Console.Write($" #  Presione la opción deseada, o ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{Opciones.Count + 1}");
            Console.ResetColor();
            Console.WriteLine($" para {(Root == null ? "salir" : "volver atrás")}");
        }

        /// <summary>
        /// Función que imprime el menú en su totalidad, 
        /// incluyendo el encabezado y llamando al método <see cref="Print"/>.
        /// A su vez, configura el cursor para que no sea visible, y limpia la pantalla.
        /// </summary>
        private void FullPrint()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Separador);
            Console.WriteLine(" #");
            Console.WriteLine(" #  " + Encabezado);
            Console.WriteLine(" #");
            Print();
            Console.WriteLine(" #");
            Console.WriteLine(Separador);
        }

        /// <summary>
        /// Sobrecarga del método <see cref="FullPrint"/> que permite imprimir un mensaje de error
        /// al final del menú.
        /// </summary>
        private void FullPrint(string error)
        {
            FullPrint();
            Console.WriteLine();
            Console.WriteLine($"    {error}");
        }

        /// <summary>
        /// Función que imprime un mensaje de despedida al usuario
        /// </summary>
        private void PrintExit()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Separador);
            Console.WriteLine(" #");
            Console.WriteLine($" #  Gracias por usar la aplicacion! Presione cualquier tecla para finalizar");
            Console.WriteLine(" #");
            Console.WriteLine(Separador);
        }

        /// <summary>
        /// Función que ejecuta el menú, imprimiendo el menú en su totalidad,
        /// y controlando la selección del usuario.
        /// </summary>
        public void Run()
        {

            FullPrint();
            byte opcion = SeleccionDelUsuario();

            // Si la opción seleccionada es 1 más que la cantidad de opciones,
            // significa que el usuario quiere salir del programa o volver atrás.
            if (opcion == Opciones.Count + 1)
            {
                // Si hay un menu padre, volver atrás
                // Si no, salir del programa
                if (Root == null)
                {
                    PrintExit();
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    return;
                }
                else
                {
                    Root.Run();
                }
            } 
            // Si no, significa que el usuario quiere acceder a una opción del menú
            else
            {
                // Ejecutar la acción de la opción seleccionada
                // Si la opción no existe, o la opción no contiene una acción,
                // imprimir un mensaje de error
                var action = Opciones[(byte)opcion - 1].Accion;
                if (action != null)
                    action();
                else
                {
                    Console.WriteLine("Opción no existente, por favor intente nuevamente");
                    Console.ReadKey();
                    Run();
                }
            }
        }

        /// <summary>
        /// Método para la lectura de la selección del usuario.
        /// </summary>
        /// <returns>Devuelve un <see cref="byte"/> con el número que seleccionó el usuario</returns>
        private byte SeleccionDelUsuario()
        {
            // Mientras la selección no sea válida, seguir pidiendo al usuario que ingrese una opción
            // usando la acción anónima definida anteriormente
            byte seleccion = ParsearSeleccion();
            while (seleccion < 1 || seleccion > Opciones.Count + 1)
            {
                FullPrint($"La opción {seleccion} no es válida, intente nuevamente");
                seleccion = ParsearSeleccion();
            }

            return seleccion;
        }

        /// <summary>
        /// Parsea la selección del usuario, y devuelve un <see cref="byte"/> con el número seleccionado.
        /// </summary>
        /// <returns><see cref="byte"/>, numero de opción seleccionada</returns>
        private byte ParsearSeleccion()
        {
            byte.TryParse(Console.ReadKey(true).KeyChar.ToString(), out byte seleccion);
            return seleccion;
        }
    }
}
