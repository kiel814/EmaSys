using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        //es la que use segun ejemplo
        //public static string Cn = (@"Data Source=DESKTOP-AKJEOB7\SQLEXPRESS; Initial Catalog=EmaSysDB; Integrated Security=true");
        //no es la que use segun el ejemplo
        //public static string Cn= "Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\EMASA\EmaSys\EmaSysDB.mdf;; Integrated Security = True";

        //indico que la cadena de conexión está guardada en la variable cn del archivo de configuración (app.config)
        public static string Cn = Properties.Settings.Default.cn;
    }
}
