using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCalc.MenuClases
{
    internal class MenuRun
    {
        private Menu Root;

        public MenuRun(Menu root)
        {
            Root = root;
        }

        public void Run()
        {
            Root.Run();
        }
    }
}
