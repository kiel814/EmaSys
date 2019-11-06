using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agrego
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    //agrego public
    public class DEmpleados
    {
        //Declaro una variable por cada campo que tengo en la Tabla
        //Las defino private porque después las tengo que encapsular
        private int _EmpleadoID;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_nacimiento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        //Propiedades

        public int EmpleadoID { get => _EmpleadoID; set => _EmpleadoID = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_nacimiento { get => _Fecha_nacimiento; set => _Fecha_nacimiento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío
        public DEmpleados()
        {

        }

        //Constructor que recibe todos los parámetros para crear los objetos teniendo en cuenta las variables y las propiedades
        public DEmpleados(int empleadoid, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                            string num_documento, string direccion, string telefono, string email, string acceso,
                            string usuario, string password, string textobuscar)
        {
            //con mayúscula es la propiedad y con minúscula los parámetros que está recibiendo el constructor
            this.EmpleadoID = empleadoid;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;
        }
        
        //método Insertar
        public string Insertar(DEmpleados Empleados)
        {
            //variable rpta (respuesta)
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código para insertar registros
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParEmpleadoID = new SqlParameter();
                ParEmpleadoID.ParameterName = "@EmpleadoID";
                ParEmpleadoID.SqlDbType = SqlDbType.Int;
                //@EmpleadoID es autonumerico, es parámetro de salida
                ParEmpleadoID.Direction = ParameterDirection.Output;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParEmpleadoID);
                                
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Empleados.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleados.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_nacimiento = new SqlParameter();
                ParFecha_nacimiento.ParameterName = "@Fecha_nacimiento";
                //ParFecha_nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_nacimiento.Size = 50;
                ParFecha_nacimiento.Value = Empleados.Fecha_nacimiento;
                SqlCmd.Parameters.Add(ParFecha_nacimiento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@Num_documento";
                ParNum_documento.SqlDbType = SqlDbType.VarChar;
                ParNum_documento.Size = 8;
                ParNum_documento.Value = Empleados.Num_documento;
                SqlCmd.Parameters.Add(ParNum_documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleados.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleados.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleados.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleados.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleados.Password;
                SqlCmd.Parameters.Add(ParPassword);                               

                //Ejecuto mi comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingresó el Registro";
            }
            catch (Exception ex)
            {
                //me va a mostrar el error
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //método Editar
        //la clase DEmpleados crea el objeto Empleados
        public string Editar(DEmpleados Empleados)
        {
            //variable rpta (respuesta)
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código para editar registros
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParEmpleadoID = new SqlParameter();
                ParEmpleadoID.ParameterName = "@EmpleadoID";
                ParEmpleadoID.SqlDbType = SqlDbType.Int;
                ParEmpleadoID.Value = Empleados.EmpleadoID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParEmpleadoID);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Empleados.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleados.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_nacimiento = new SqlParameter();
                ParFecha_nacimiento.ParameterName = "@Fecha_nacimiento";
                ParFecha_nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_nacimiento.Size = 50;
                ParFecha_nacimiento.Value = Empleados.Fecha_nacimiento;
                SqlCmd.Parameters.Add(ParFecha_nacimiento);

                SqlParameter ParNum_documento = new SqlParameter();
                ParNum_documento.ParameterName = "@Num_documento";
                ParNum_documento.SqlDbType = SqlDbType.VarChar;
                ParNum_documento.Size = 8;
                ParNum_documento.Value = Empleados.Num_documento;
                SqlCmd.Parameters.Add(ParNum_documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleados.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleados.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleados.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleados.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleados.Password;
                SqlCmd.Parameters.Add(ParPassword);

                //Ejecuto mi comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el Registro";
            }
            catch (Exception ex)
            {
                //me va a mostrar el error
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //método Eliminar
        public string Eliminar(DEmpleados Empleados)
        {
            //variable rpta (respuesta)
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código para eliminar registros
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParEmpleadoID = new SqlParameter();
                ParEmpleadoID.ParameterName = "@EmpleadoID";
                ParEmpleadoID.SqlDbType = SqlDbType.Int;
                //@EmpleadoID es autonumerico, es parámetro de salida
                ParEmpleadoID.Value = Empleados.EmpleadoID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParEmpleadoID);

                //Ejecuto mi comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Eliminó el Registro";
            }
            catch (Exception ex)
            {
                //me va a mostrar el error
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
				string a = ex.ToString();
				DtResultado = null;
            }
            return DtResultado;
        }

        //método BuscarApellidos
        public DataTable BuscarApellidos(DEmpleados Empleados)
        {
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleado_apellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleados.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //método BuscarNum_Documento
        public DataTable BuscarNum_documento(DEmpleados Empleados)
        {
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleado_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleados.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //método Login
        public DataTable Login(DEmpleados Empleados)
        {
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleados.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@Password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Empleados.Password;
                SqlCmd.Parameters.Add(ParPassword);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
