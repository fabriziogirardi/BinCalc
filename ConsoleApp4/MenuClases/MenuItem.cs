using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCalc.MenuClases
{
    public class MenuItem
    {
        public string Titulo { get; private set; }
        public Action Accion { get; private set; }
        public Action? Volver { get; private set; }

        public MenuItem(string nombre, Action accion)
        {
            Titulo = nombre;
            Accion = accion;
        }

        public MenuItem(string nombre, Action accion, Action volver) : this(nombre, accion)
        {
            Volver = volver;
        }
    }
}
