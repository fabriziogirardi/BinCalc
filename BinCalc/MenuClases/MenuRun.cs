namespace BinCalc.MenuClases
{
    /// <summary>
    /// Clase que administra y muestra en pantalla el <see cref="Menu"/> principal.
    /// Luego de esta clase, cada menú se encarga de sí mismo, y se autoadministra
    /// con sus propios métodos <see cref="Menu.Run"/>.
    /// </summary>
    internal class MenuRun
    {
        /// <summary>
        /// <see cref="Menu"/> principal o de raíz de la aplicación.
        /// </summary>
        private Menu Root;

        /// <summary>
        /// Constructor que recibe un objeto <see cref="Menu"/> que se utilizará como menú principal o de raíz.
        /// </summary>
        /// <param name="root">El <see cref="Menu"/> que se considerará principal en el programa.</param>
        public MenuRun(Menu root)
        {
            Root = root;
        }

        /// <summary>
        /// Acción principal que ejecuta el menú llamando al método <see cref="Menu.Run"/> del objeto <see cref="Menu"/> almacenado en el parámetro.
        /// </summary>
        public void Run()
        {
            Root.Run();
        }
    }
}
