using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agrego
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NClientes
    {
        //métodos para poder comunicarse con la capaDatos
        //Método Insertar que llama al método Insertar de la clase DCLientes
        //de la CapaDatos
        public static string Insertar(string clicodigo, string clinombr, string clidirec, string clitelef,
            string clifax, string clilocal, string cliprovi, string clicpost, string cliciva, string cliagper,
            string clicuit, string cliingbr, string cliprove, int clipcobr, string clicocom, string clitecom,
            string clicotec, string clitetec, string clicoadm, string cliteadm, string cliok,string climail,string clipais)
        {
            DClientes Obj = new DClientes();
            //métodos CliCodigo de DClientes
            Obj.CliCodigo = clicodigo;
            Obj.CliNombr = clinombr;
            Obj.CliDirec = clidirec;
            Obj.CliTelef = clitelef;
            Obj.CliFax = clifax;
            Obj.CliLocal = clilocal;
            Obj.CliProvi = cliprovi;
            Obj.CliCPost = clicpost;
            Obj.CliCIva = cliciva;
            Obj.CliAgper = cliagper;
            Obj.CliCuit = clicuit;
            Obj.CliIngbr = cliingbr;
            Obj.CliProve = cliprove;
            Obj.CliPCobr = clipcobr;
            Obj.CliCocom = clicocom;
            Obj.CliTecom = clitecom;
            Obj.CliCotec = clicotec;
            Obj.CliTetec = clitetec;
            Obj.CliCoadm = clicoadm;
            Obj.CliTeadm = cliteadm;
            Obj.CliOk = cliok;
            Obj.CliMail = climail;
            Obj.CliPais = clipais;
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCLientes
        //de la CapaDatos
        public static string Editar(int clienteid,string clicodigo, string clinombr, string clidirec, string clitelef,
            string clifax, string clilocal, string cliprovi, string clicpost, string cliciva, string cliagper,
            string clicuit, string cliingbr, string cliprove, int clipcobr, string clicocom, string clitecom,
            string clicotec, string clitetec, string clicoadm, string cliteadm, string cliok,string climail,string clipais)
        {
            DClientes Obj = new DClientes();
            //métodos CliCodigo de DClientes
            Obj.ClienteID = clienteid;
            Obj.CliCodigo = clicodigo;
            Obj.CliNombr = clinombr;
            Obj.CliDirec = clidirec;
            Obj.CliTelef = clitelef;
            Obj.CliFax = clifax;
            Obj.CliLocal = clilocal;
            Obj.CliProvi = cliprovi;
            Obj.CliCPost = clicpost;
            Obj.CliCIva = cliciva;
            Obj.CliAgper = cliagper;
            Obj.CliCuit = clicuit;
            Obj.CliIngbr = cliingbr;
            Obj.CliProve = cliprove;
            Obj.CliPCobr = clipcobr;
            Obj.CliCocom = clicocom;
            Obj.CliTecom = clitecom;
            Obj.CliCotec = clicotec;
            Obj.CliTetec = clitetec;
            Obj.CliCoadm = clicoadm;
            Obj.CliTeadm = cliteadm;
            Obj.CliOk = cliok;
            Obj.CliMail = climail;
            Obj.CliPais = clipais;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCLientes
        //de la CapaDatos
        public static string Eliminar(int clienteid)
        {
            DClientes Obj = new DClientes();
            //métodos CliCodigo de DClientes
            Obj.ClienteID = clienteid;            
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCLientes
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DClientes().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre de la clase DCLientes
        //de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método BuscarCuit que llama al método BuscarCuit de la clase DCLientes
        //de la CapaDatos
        public static DataTable BuscarCuit(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCuit(Obj);
        }

        //Método BuscarCliCodigo que llama al método BuscarCliCodigo de la clase DCLientes
        //de la CapaDatos
        public static DataTable BuscarCliCodigo(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliCodigo(Obj);
        }
    }
}
