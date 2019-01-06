using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//Se debe comunicar con la CapaPresentacion
using CapaPresentacion;


namespace EmaSys
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FrmLogin());
            //Application.Run(new FrmClientes());
            //Application.Run(new FrmProveedores());

            //Es el menu
            //Application.Run(new FrmPrincipal());            
        }
    }
}
