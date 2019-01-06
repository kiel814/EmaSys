using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEmpleados
    {
        //declaro los métodos para comunicarme con la capaDatos        
        //Método Insertar que llama al método Insertar de la clase DEmpleados
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidos, string sexo,DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso,
            string usuario, string password)
        {
            DEmpleados Obj = new DEmpleados();            
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DEmpleados
        //de la CapaDatos
        public static string Editar(int empleadoid, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso,
            string usuario, string password)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fecha_nacimiento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DEmpleados
        //de la CapaDatos
        public static string Eliminar(int empleadoid)
        {
            DEmpleados Obj = new DEmpleados();
            
            Obj.EmpleadoID = empleadoid;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DEmpleados
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DEmpleados().Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos de la clase DEmpleados
        //de la CapaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //Método BuscarNum_documento que llama al método BuscarNum_documento de la clase DEmpleados
        //de la CapaDatos
        public static DataTable BuscarNum_documento(string textobuscar)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_documento(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.Usuario = usuario;
            Obj.Password = password;
            //me devuelve un datatable
            //con click derecho e Ir a definición y veo que devuelve el DtResultado
            return Obj.Login(Obj);
        }
    }
}
