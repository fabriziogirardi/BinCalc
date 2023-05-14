using BinCalc.Calculos;
using BinCalc.MenuClases;

namespace BinCalc
{
    /// <summary>
    /// Clase principal del programa.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método principal del programa. Desde acá se ejecuta el <see cref="Menu.Run"/>
        /// del primer <see cref="Menu"/> y luego todo va modularizado de ahí en más.
        /// </summary>
        static public void Main()
        {
            List<MenuItem> menuPrincipal = new List<MenuItem>();
            List<MenuItem> menuEnteros = new List<MenuItem>();
            List<MenuItem> menuFraccionariosFijos = new List<MenuItem>();
            List<MenuItem> menuFraccionariosFlotantes = new List<MenuItem>();

            Menu root = new Menu("Menú principal", menuPrincipal, null);
            Menu menuEnt = new Menu("Menú de enteros", menuEnteros, root);
            Menu menuFracFij = new Menu("Menú de fraccionarios fijos", menuFraccionariosFijos, root);
            Menu menuFracFlot = new Menu("Menú de fraccionarios flotantes", menuFraccionariosFlotantes, root);

            Enteros enteros = new Enteros(menuEnt);

            menuPrincipal.Add(new MenuItem("Convertir enteros a binario y viceversa", menuEnt.Run));
            menuPrincipal.Add(new MenuItem("Convertir fraccionarios fijos a binario y viceversa (proximamente)", menuFracFij.Run));
            menuPrincipal.Add(new MenuItem("Convertir fraccionarios flotantes a binario y viceversa (proximamente)", menuFracFlot.Run));

            menuEnteros.Add(new MenuItem("Convertir enteros a binario", enteros.EnteroBinario));
            menuEnteros.Add(new MenuItem("Convertir binarios a entero", enteros.BinarioEntero));

            new MenuRun(root).Run();
        }
    }
}