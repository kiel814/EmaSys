using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agrego para trabajar con tipos de datos de SQL Server
using System.Data;
//agrego para poder enviar comandos desde la aplicación a SQL Server
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        //Declaro como variables todos los campos de la tabla Clientes
        //Los defino como private para encapsularlos y protegerlos
        private int _ClienteID;
        private string _CliCodigo;
        private string _CliNombr;
        private string _CliDirec;
        private string _CliTelef;
        private string _CliFax;
        private string _CliLocal;
        private string _CliProvi;
        private string _CliCPost;
        private string _CliCIva;
        private string _CliAgper;
        private string _CliCuit;
        private string _CliIngbr;
        private string _CliProve;
        private int _CliPCobr;
        private string _CliCocom;
        private string _CliTecom;
        private string _CliCotec;
        private string _CliTetec;
        private string _CliCoadm;
        private string _CliTeadm;
        private string _CliOk;
        private string _CliMail;
        private string _CliPais;

        private string _TextoBuscar;

        public int ClienteID
        {
            //ClienteID es el método
            //método get es para obtener el valor y set para guardar (video 5-41)
            get { return _ClienteID; }
            set { _ClienteID = value; }
        }

        public string CliCodigo { get => _CliCodigo; set => _CliCodigo = value; }
        public string CliNombr { get => _CliNombr; set => _CliNombr = value; }
        public string CliDirec { get => _CliDirec; set => _CliDirec = value; }
        public string CliTelef { get => _CliTelef; set => _CliTelef = value; }
        public string CliFax { get => _CliFax; set => _CliFax = value; }
        public string CliLocal { get => _CliLocal; set => _CliLocal = value; }
        public string CliProvi { get => _CliProvi; set => _CliProvi = value; }
        public string CliCPost { get => _CliCPost; set => _CliCPost = value; }
        public string CliCIva { get => _CliCIva; set => _CliCIva = value; }
        public string CliAgper { get => _CliAgper; set => _CliAgper = value; }
        public string CliCuit { get => _CliCuit; set => _CliCuit = value; }
        public string CliIngbr { get => _CliIngbr; set => _CliIngbr = value; }
        public string CliProve { get => _CliProve; set => _CliProve = value; }
        public int CliPCobr { get => _CliPCobr; set => _CliPCobr = value; }
        public string CliCocom { get => _CliCocom; set => _CliCocom = value; }
        public string CliTecom { get => _CliTecom; set => _CliTecom = value; }
        public string CliCotec { get => _CliCotec; set => _CliCotec = value; }
        public string CliTetec { get => _CliTetec; set => _CliTetec = value; }
        public string CliCoadm { get => _CliCoadm; set => _CliCoadm = value; }
        public string CliTeadm { get => _CliTeadm; set => _CliTeadm = value; }
        public string CliOk { get => _CliOk; set => _CliOk = value; }
        public string CliMail { get => _CliMail; set => _CliMail = value; }
        public string CliPais { get => _CliPais; set => _CliPais = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
                
        //constructor vacío
        public DClientes()
        {

        }

        //constructor con parámetros
        public DClientes(int clienteid,string clicodigo,string clinombr,string clidirec,string clitelef,string clifax,string clilocal, string cliprovi,string clicpost,string cliciva,string cliagper,string clicuit,string cliingbr,string cliprove,string clipcobr,string clicocom,string clitecom,string clicotec,string clitetec,string clicoadm,string cliteadm,string cliok,string climail, string clipais,string textobuscar)
        {
            //clienteid es el parámetro que está recibiendo y ClienteID es el método set and get
            this.ClienteID = clienteid;
            this.CliCodigo = clicodigo;
            this.CliNombr = clinombr;
            //ver si es necesario definir el resto de las variables
            this.TextoBuscar = textobuscar;
        }

        //método Insertar
        public string Insertar(DClientes Clientes)
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
                SqlCmd.CommandText = "spinsertar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParClienteID = new SqlParameter();
                ParClienteID.ParameterName = "@ClienteID";
                ParClienteID.SqlDbType = SqlDbType.Int;
                //@ClienteID es autonumerico, es parámetro de salida
                ParClienteID.Direction = ParameterDirection.Output;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParClienteID);

                SqlParameter ParCliCodigo = new SqlParameter();
                ParCliCodigo.ParameterName = "@CliCodigo";
                ParCliCodigo.SqlDbType = SqlDbType.VarChar;
                ParCliCodigo.Size = 4;
                ParCliCodigo.Value = Clientes.CliCodigo;
                SqlCmd.Parameters.Add(ParCliCodigo);

                SqlParameter ParCliNombr = new SqlParameter();
                ParCliNombr.ParameterName = "@CliNombr";
                ParCliNombr.SqlDbType = SqlDbType.VarChar;
                ParCliNombr.Size = 50;
                ParCliNombr.Value = Clientes.CliNombr;
                SqlCmd.Parameters.Add(ParCliNombr);

                //agrego yo parámetro CliDirec y el resto de los campos de la Tabla Clientes
                SqlParameter ParCliDirec = new SqlParameter();
                ParCliDirec.ParameterName = "@CliDirec";
                ParCliDirec.SqlDbType = SqlDbType.VarChar;
                ParCliDirec.Size = 50;
                ParCliDirec.Value = Clientes.CliDirec;
                SqlCmd.Parameters.Add(ParCliDirec);

                SqlParameter ParCliTelef = new SqlParameter();
                ParCliTelef.ParameterName = "@CliTelef";
                ParCliTelef.SqlDbType = SqlDbType.VarChar;
                ParCliTelef.Size = 12;
                ParCliTelef.Value = Clientes.CliTelef;
                SqlCmd.Parameters.Add(ParCliTelef);

                SqlParameter ParCliFax = new SqlParameter();
                ParCliFax.ParameterName = "@CliFax";
                ParCliFax.SqlDbType = SqlDbType.VarChar;
                ParCliFax.Size = 12;
                ParCliFax.Value = Clientes.CliFax;
                SqlCmd.Parameters.Add(ParCliFax);

                SqlParameter ParCliLocal = new SqlParameter();
                ParCliLocal.ParameterName = "@CliLocal";
                ParCliLocal.SqlDbType = SqlDbType.VarChar;
                ParCliLocal.Size = 25;
                ParCliLocal.Value = Clientes.CliLocal;
                SqlCmd.Parameters.Add(ParCliLocal);

                SqlParameter ParCliProvi = new SqlParameter();
                ParCliProvi.ParameterName = "@CliProvi";
                ParCliProvi.SqlDbType = SqlDbType.VarChar;
                ParCliProvi.Size = 25;
                ParCliProvi.Value = Clientes.CliProvi;
                SqlCmd.Parameters.Add(ParCliProvi);

                SqlParameter ParCliCPost = new SqlParameter();
                ParCliCPost.ParameterName = "@CliCPost";
                ParCliCPost.SqlDbType = SqlDbType.VarChar;
                ParCliCPost.Size = 8;
                ParCliCPost.Value = Clientes.CliCPost;
                SqlCmd.Parameters.Add(ParCliCPost);

                SqlParameter ParCliCIva = new SqlParameter();
                ParCliCIva.ParameterName = "@CliCIva";
                ParCliCIva.SqlDbType = SqlDbType.VarChar;
                ParCliCIva.Size = 1;
                ParCliCIva.Value = Clientes.CliCIva;
                SqlCmd.Parameters.Add(ParCliCIva);

                SqlParameter ParCliAgper = new SqlParameter();
                ParCliAgper.ParameterName = "@CliAgper";
                ParCliAgper.SqlDbType = SqlDbType.VarChar;
                ParCliAgper.Size = 1;
                ParCliAgper.Value = Clientes.CliAgper;
                SqlCmd.Parameters.Add(ParCliAgper);

                SqlParameter ParCliCuit = new SqlParameter();
                ParCliCuit.ParameterName = "@CliCuit";
                ParCliCuit.SqlDbType = SqlDbType.VarChar;
                ParCliCuit.Size = 13;
                ParCliCuit.Value = Clientes.CliCuit;
                SqlCmd.Parameters.Add(ParCliCuit);

                SqlParameter ParCliIngbr = new SqlParameter();
                ParCliIngbr.ParameterName = "@CliIngbr";
                ParCliIngbr.SqlDbType = SqlDbType.VarChar;
                ParCliIngbr.Size = 15;
                ParCliIngbr.Value = Clientes.CliIngbr;
                SqlCmd.Parameters.Add(ParCliIngbr);

                SqlParameter ParCliProve = new SqlParameter();
                ParCliProve.ParameterName = "@CliProve";
                ParCliProve.SqlDbType = SqlDbType.VarChar;
                ParCliProve.Size = 5;
                ParCliProve.Value = Clientes.CliProve;
                SqlCmd.Parameters.Add(ParCliProve);

                SqlParameter ParCliPCobr = new SqlParameter();
                ParCliPCobr.ParameterName = "@CliPCobr";
                ParCliPCobr.SqlDbType = SqlDbType.Int;
                //ParCliPCobr.Size = 5;
                ParCliPCobr.Value = Clientes.CliPCobr;
                SqlCmd.Parameters.Add(ParCliPCobr);

                SqlParameter ParCliCocom = new SqlParameter();
                ParCliCocom.ParameterName = "@CliCocom";
                ParCliCocom.SqlDbType = SqlDbType.VarChar;
                ParCliCocom.Size = 30;
                ParCliCocom.Value = Clientes.CliCocom;
                SqlCmd.Parameters.Add(ParCliCocom);

                SqlParameter ParCliTecom = new SqlParameter();
                ParCliTecom.ParameterName = "@CliTecom";
                ParCliTecom.SqlDbType = SqlDbType.VarChar;
                ParCliTecom.Size = 12;
                ParCliTecom.Value = Clientes.CliTecom;
                SqlCmd.Parameters.Add(ParCliTecom);

                SqlParameter ParCliCotec = new SqlParameter();
                ParCliCotec.ParameterName = "@CliCotec";
                ParCliCotec.SqlDbType = SqlDbType.VarChar;
                ParCliCotec.Size = 30;
                ParCliCotec.Value = Clientes.CliCotec;
                SqlCmd.Parameters.Add(ParCliCotec);

                SqlParameter ParCliTetec = new SqlParameter();
                ParCliTetec.ParameterName = "@CliTetec";
                ParCliTetec.SqlDbType = SqlDbType.VarChar;
                ParCliTetec.Size = 12;
                ParCliTetec.Value = Clientes.CliTetec;
                SqlCmd.Parameters.Add(ParCliTetec);

                SqlParameter ParCliCoadm = new SqlParameter();
                ParCliCoadm.ParameterName = "@CliCoadm";
                ParCliCoadm.SqlDbType = SqlDbType.VarChar;
                ParCliCoadm.Size = 30;
                ParCliCoadm.Value = Clientes.CliCoadm;
                SqlCmd.Parameters.Add(ParCliCoadm);

                SqlParameter ParCliTeadm = new SqlParameter();
                ParCliTeadm.ParameterName = "@CliTeadm";
                ParCliTeadm.SqlDbType = SqlDbType.VarChar;
                ParCliTeadm.Size = 12;
                ParCliTeadm.Value = Clientes.CliTeadm;
                SqlCmd.Parameters.Add(ParCliTeadm);

                SqlParameter ParCliOk = new SqlParameter();
                ParCliOk.ParameterName = "@CliOk";
                ParCliOk.SqlDbType = SqlDbType.VarChar;
                ParCliOk.Size = 1;
                ParCliOk.Value = Clientes.CliOk;
                SqlCmd.Parameters.Add(ParCliOk);

                SqlParameter ParCliMail = new SqlParameter();
                ParCliMail.ParameterName = "@CliMail";
                ParCliMail.SqlDbType = SqlDbType.VarChar;
                ParCliMail.Size = 50;
                ParCliMail.Value = Clientes.CliMail;
                SqlCmd.Parameters.Add(ParCliMail);

                SqlParameter ParCliPais = new SqlParameter();
                ParCliPais.ParameterName = "@CliPais";
                ParCliPais.SqlDbType = SqlDbType.VarChar;
                ParCliPais.Size = 30;
                ParCliPais.Value = Clientes.CliPais;
                SqlCmd.Parameters.Add(ParCliPais);

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
                if(SqlCon.State==ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //método Editar
        public string Editar(DClientes Clientes)
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
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParClienteID = new SqlParameter();
                ParClienteID.ParameterName = "@ClienteID";
                ParClienteID.SqlDbType = SqlDbType.Int;                
                ParClienteID.Value = Clientes.ClienteID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParClienteID);

                SqlParameter ParCliCodigo = new SqlParameter();
                ParCliCodigo.ParameterName = "@CliCodigo";
                ParCliCodigo.SqlDbType = SqlDbType.VarChar;
                ParCliCodigo.Size = 4;
                ParCliCodigo.Value = Clientes.CliCodigo;
                SqlCmd.Parameters.Add(ParCliCodigo);

                SqlParameter ParCliNombr = new SqlParameter();
                ParCliNombr.ParameterName = "@CliNombr";
                ParCliNombr.SqlDbType = SqlDbType.VarChar;
                ParCliNombr.Size = 50;
                ParCliNombr.Value = Clientes.CliNombr;
                SqlCmd.Parameters.Add(ParCliNombr);

                //agrego yo parámetro CliDirec y el resto de los campos de la Tabla Clientes
                SqlParameter ParCliDirec = new SqlParameter();
                ParCliDirec.ParameterName = "@CliDirec";
                ParCliDirec.SqlDbType = SqlDbType.VarChar;
                ParCliDirec.Size = 50;
                ParCliDirec.Value = Clientes.CliDirec;
                SqlCmd.Parameters.Add(ParCliDirec);

                SqlParameter ParCliTelef = new SqlParameter();
                ParCliTelef.ParameterName = "@CliTelef";
                ParCliTelef.SqlDbType = SqlDbType.VarChar;
                ParCliTelef.Size = 12;
                ParCliTelef.Value = Clientes.CliTelef;
                SqlCmd.Parameters.Add(ParCliTelef);

                SqlParameter ParCliFax = new SqlParameter();
                ParCliFax.ParameterName = "@CliFax";
                ParCliFax.SqlDbType = SqlDbType.VarChar;
                ParCliFax.Size = 12;
                ParCliFax.Value = Clientes.CliFax;
                SqlCmd.Parameters.Add(ParCliFax);

                SqlParameter ParCliLocal = new SqlParameter();
                ParCliLocal.ParameterName = "@CliLocal";
                ParCliLocal.SqlDbType = SqlDbType.VarChar;
                ParCliLocal.Size = 25;
                ParCliLocal.Value = Clientes.CliLocal;
                SqlCmd.Parameters.Add(ParCliLocal);

                SqlParameter ParCliProvi = new SqlParameter();
                ParCliProvi.ParameterName = "@CliProvi";
                ParCliProvi.SqlDbType = SqlDbType.VarChar;
                ParCliProvi.Size = 25;
                ParCliProvi.Value = Clientes.CliProvi;
                SqlCmd.Parameters.Add(ParCliProvi);

                SqlParameter ParCliCPost = new SqlParameter();
                ParCliCPost.ParameterName = "@CliCPost";
                ParCliCPost.SqlDbType = SqlDbType.VarChar;
                ParCliCPost.Size = 8;
                ParCliCPost.Value = Clientes.CliCPost;
                SqlCmd.Parameters.Add(ParCliCPost);

                SqlParameter ParCliCIva = new SqlParameter();
                ParCliCIva.ParameterName = "@CliCIva";
                ParCliCIva.SqlDbType = SqlDbType.VarChar;
                ParCliCIva.Size = 1;
                ParCliCIva.Value = Clientes.CliCIva;
                SqlCmd.Parameters.Add(ParCliCIva);

                SqlParameter ParCliAgper = new SqlParameter();
                ParCliAgper.ParameterName = "@CliAgper";
                ParCliAgper.SqlDbType = SqlDbType.VarChar;
                ParCliAgper.Size = 1;
                ParCliAgper.Value = Clientes.CliAgper;
                SqlCmd.Parameters.Add(ParCliAgper);

                SqlParameter ParCliCuit = new SqlParameter();
                ParCliCuit.ParameterName = "@CliCuit";
                ParCliCuit.SqlDbType = SqlDbType.VarChar;
                ParCliCuit.Size = 13;
                ParCliCuit.Value = Clientes.CliCuit;
                SqlCmd.Parameters.Add(ParCliCuit);

                SqlParameter ParCliIngbr = new SqlParameter();
                ParCliIngbr.ParameterName = "@CliIngbr";
                ParCliIngbr.SqlDbType = SqlDbType.VarChar;
                ParCliIngbr.Size = 15;
                ParCliIngbr.Value = Clientes.CliIngbr;
                SqlCmd.Parameters.Add(ParCliIngbr);

                SqlParameter ParCliProve = new SqlParameter();
                ParCliProve.ParameterName = "@CliProve";
                ParCliProve.SqlDbType = SqlDbType.VarChar;
                ParCliProve.Size = 5;
                ParCliProve.Value = Clientes.CliProve;
                SqlCmd.Parameters.Add(ParCliProve);

                SqlParameter ParCliPCobr = new SqlParameter();
                ParCliPCobr.ParameterName = "@CliPCobr";
                ParCliPCobr.SqlDbType = SqlDbType.Int;
                //ParCliPCobr.Size = 5;
                ParCliPCobr.Value = Clientes.CliPCobr;
                SqlCmd.Parameters.Add(ParCliPCobr);

                SqlParameter ParCliCocom = new SqlParameter();
                ParCliCocom.ParameterName = "@CliCocom";
                ParCliCocom.SqlDbType = SqlDbType.VarChar;
                ParCliCocom.Size = 30;
                ParCliCocom.Value = Clientes.CliCocom;
                SqlCmd.Parameters.Add(ParCliCocom);

                SqlParameter ParCliTecom = new SqlParameter();
                ParCliTecom.ParameterName = "@CliTecom";
                ParCliTecom.SqlDbType = SqlDbType.VarChar;
                ParCliTecom.Size = 12;
                ParCliTecom.Value = Clientes.CliTecom;
                SqlCmd.Parameters.Add(ParCliTecom);

                SqlParameter ParCliCotec = new SqlParameter();
                ParCliCotec.ParameterName = "@CliCotec";
                ParCliCotec.SqlDbType = SqlDbType.VarChar;
                ParCliCotec.Size = 30;
                ParCliCotec.Value = Clientes.CliCotec;
                SqlCmd.Parameters.Add(ParCliCotec);

                SqlParameter ParCliTetec = new SqlParameter();
                ParCliTetec.ParameterName = "@CliTetec";
                ParCliTetec.SqlDbType = SqlDbType.VarChar;
                ParCliTetec.Size = 12;
                ParCliTetec.Value = Clientes.CliTetec;
                SqlCmd.Parameters.Add(ParCliTetec);

                SqlParameter ParCliCoadm = new SqlParameter();
                ParCliCoadm.ParameterName = "@CliCoadm";
                ParCliCoadm.SqlDbType = SqlDbType.VarChar;
                ParCliCoadm.Size = 30;
                ParCliCoadm.Value = Clientes.CliCoadm;
                SqlCmd.Parameters.Add(ParCliCoadm);

                SqlParameter ParCliTeadm = new SqlParameter();
                ParCliTeadm.ParameterName = "@CliTeadm";
                ParCliTeadm.SqlDbType = SqlDbType.VarChar;
                ParCliTeadm.Size = 12;
                ParCliTeadm.Value = Clientes.CliTeadm;
                SqlCmd.Parameters.Add(ParCliTeadm);

                SqlParameter ParCliOk = new SqlParameter();
                ParCliOk.ParameterName = "@CliOk";
                ParCliOk.SqlDbType = SqlDbType.VarChar;
                ParCliOk.Size = 1;
                ParCliOk.Value = Clientes.CliOk;
                SqlCmd.Parameters.Add(ParCliOk);

                SqlParameter ParCliMail = new SqlParameter();
                ParCliMail.ParameterName = "@CliMail";
                ParCliMail.SqlDbType = SqlDbType.VarChar;
                ParCliMail.Size = 50;
                ParCliMail.Value = Clientes.CliMail;
                SqlCmd.Parameters.Add(ParCliMail);

                SqlParameter ParCliPais = new SqlParameter();
                ParCliPais.ParameterName = "@CliPais";
                ParCliPais.SqlDbType = SqlDbType.VarChar;
                ParCliPais.Size = 30;
                ParCliPais.Value = Clientes.CliPais;
                SqlCmd.Parameters.Add(ParCliPais);

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
        public string Eliminar(DClientes Clientes)
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
                SqlCmd.CommandText = "speliminar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParClienteID = new SqlParameter();
                ParClienteID.ParameterName = "@ClienteID";
                ParClienteID.SqlDbType = SqlDbType.Int;
                //@ClienteID es autonumerico, es parámetro de salida
                ParClienteID.Value = Clientes.ClienteID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParClienteID);
                                
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
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //método BuscarNombre
        public DataTable BuscarNombre(DClientes Clientes)
        {
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clientes.TextoBuscar;
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

        //método BuscarCuit
        public DataTable BuscarCuit(DClientes Clientes)
        {
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_cuit";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 13;
                ParTextoBuscar.Value = Clientes.TextoBuscar;
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

        //método BuscarCliCodigo
        public DataTable BuscarCliCodigo(DClientes Clientes)
        {            
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_clicodigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 4;
                ParTextoBuscar.Value = Clientes.TextoBuscar;
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
    }
}
