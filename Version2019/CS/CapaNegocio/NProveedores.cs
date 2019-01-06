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
    public class NProveedores
    {
        //métodos para poder comunicarse con la capaDatos
        //Método Insertar que llama al método Insertar de la clase DProveedores
        //de la CapaDatos
        public static string Insertar(string procodigo, string pronombr, string pronomch, string prodirec,
                            string protelef, string profax, string prolocal, string proprovi, string procpost, string prociva,
                            string procuit, string proramo, string proservi, string proingbr, string proganan, string proningb,
                            string proactiv, string proagper, string progrupo, DateTime profeins, string proaciva, string procai,
                            DateTime profecai, string proaduan, string procbanc, string prodespa, string prook, string promail,
                            string proactivdesc, string propais)
        {
            DProveedores Obj = new DProveedores();
            //métodos ProCodigo de DProveedores
            Obj.ProCodigo = procodigo;
            Obj.ProNombr = pronombr;
            Obj.ProNomch = pronomch;
            Obj.ProDirec = prodirec;
            Obj.ProTelef = protelef;
            Obj.ProFax = profax;
            Obj.ProLocal = prolocal;
            Obj.ProProvi = proprovi;
            Obj.ProCPost = procpost;
            Obj.ProCIva = prociva;
            Obj.ProCuit = procuit;
            Obj.ProRamo = proramo;
            Obj.ProServi = proservi;
            Obj.ProIngbr = proingbr;
            Obj.ProGanan = proganan;
            Obj.ProNIngb = proningb;
            Obj.ProActiv = proactiv;
            Obj.ProAgper = proagper;
            Obj.ProGrupo = progrupo;
            Obj.ProFeins = profeins;
            Obj.ProAciva = proaciva;
            Obj.ProCai = procai;
            Obj.ProFecai = profecai;
            Obj.ProAduan = proaduan;
            Obj.ProCBanc = procbanc;
            Obj.ProDespa = prodespa;
            Obj.ProOk = prook;
            Obj.ProMail = promail;
            Obj.ProActivDesc = proactivdesc;
            Obj.ProPais = propais;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DProveedores
        //de la CapaDatos
        public static string Editar(int proveedorid, string procodigo, string pronombr, string pronomch, string prodirec,
                            string protelef, string profax, string prolocal, string proprovi, string procpost, string prociva,
                            string procuit, string proramo, string proservi, string proingbr, string proganan, string proningb,
                            string proactiv, string proagper, string progrupo, DateTime profeins, string proaciva, string procai,
                            DateTime profecai, string proaduan, string procbanc, string prodespa, string prook, string promail,
                            string proactivdesc, string propais)
        {
            DProveedores Obj = new DProveedores();
            //métodos ProCodigo de DProveedores
            Obj.ProveedorID = proveedorid;
            Obj.ProCodigo = procodigo;
            Obj.ProNombr = pronombr;
            Obj.ProNomch = pronomch;
            Obj.ProDirec = prodirec;
            Obj.ProTelef = protelef;
            Obj.ProFax = profax;
            Obj.ProLocal = prolocal;
            Obj.ProProvi = proprovi;
            Obj.ProCPost = procpost;
            Obj.ProCIva = prociva;
            Obj.ProCuit = procuit;
            Obj.ProRamo = proramo;
            Obj.ProServi = proservi;
            Obj.ProIngbr = proingbr;
            Obj.ProGanan = proganan;
            Obj.ProNIngb = proningb;
            Obj.ProActiv = proactiv;
            Obj.ProAgper = proagper;
            Obj.ProGrupo = progrupo;
            Obj.ProFeins = profeins;
            Obj.ProAciva = proaciva;
            Obj.ProCai = procai;
            Obj.ProFecai = profecai;
            Obj.ProAduan = proaduan;
            Obj.ProCBanc = procbanc;
            Obj.ProDespa = prodespa;
            Obj.ProOk = prook;            
            Obj.ProMail = promail;
            Obj.ProActivDesc = proactivdesc;
            Obj.ProPais = propais;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DProveedores
        //de la CapaDatos
        public static string Eliminar(int proveedorid)
        {
            DProveedores Obj = new DProveedores();
            //métodos ProCodigo de DProveedores
            Obj.ProveedorID = proveedorid;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DProveedores
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedores().Mostrar();
        }

        public static DataTable ListaCodigoNombre()
        {
            return new DProveedores().ListaCodigoNombre();
        }

        //Método BuscarNombre que llama al método BuscarNombre de la clase DProveedores
        //de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DProveedores Obj = new DProveedores();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

        //Método BuscarCuit que llama al método BuscarCuit de la clase DCLientes
        //de la CapaDatos
        public static DataTable BuscarCuit(string textobuscar)
        {
            DProveedores Obj = new DProveedores();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCuit(Obj);
        }

        //Método BuscarProCodigo que llama al método BuscarProCodigo de la clase DProveedores
        //de la CapaDatos
        public static DataTable BuscarProCodigo(string textobuscar)
        {
            DProveedores Obj = new DProveedores();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProCodigo(Obj);
        }
    }
}

