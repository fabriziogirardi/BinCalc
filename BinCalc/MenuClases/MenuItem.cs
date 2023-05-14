namespace BinCalc.MenuClases
{
    /// <summary>
    /// Clase que define un elemento de un menú.
    /// Contiene 2 constructores. Uno para elementos que no
    /// tienen opción de volver atrás, y otro para los que sí.
    /// </summary>
    internal class MenuItem
    {
        /// <summary>
        /// Título de la opción del menú.
        /// </summary>
        public string Titulo { get; private set; }

        /// <summary>
        /// Acción a ejecutar cuando se selecciona la opción.
        /// </summary>
        public Action Accion { get; private set; }

        /// <summary>
        /// Acción a ejecutar si es necesario volver a un menú que no se padre de el actual.
        /// </summary>
        public Action? Volver { get; private set; }

        /// <summary>
        /// Constructor general de la clase MenuItem.
        /// Aplica a los elementos que no necesitan personalizar la acción de volver.
        /// </summary>
        /// <param name="nombre">Nombre que aparecerá al mostrar la opción.</param>
        /// <param name="accion">Acción a ejecutar cuando el usuario seleccione la opción.</param>
        public MenuItem(string nombre, Action accion)
        {
            Titulo = nombre;
            Accion = accion;
        }

        /// <summary>
        /// Constructor secundario de la clase MenuItem.
        /// Aplica a los elementos que necesitan personalizar la acción de volver.
        /// </summary>
        /// <param name="nombre">Nombre que aparecerá al mostrar la opción.</param>
        /// <param name="accion">Acción a ejecutar cuando el usuario seleccione la opción.</param>
        /// <param name="volver">Acción a ejecutar cuando el usuario desee volver atrás.</param>
        public MenuItem(string nombre, Action accion, Action volver) : this(nombre, accion)
        {
            Volver = volver;
        }
    }
}
