using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//agrego para usar datos de SQL Server
using System.Data;
//agrego para poder conectar con el SQL Server
using System.Data.SqlClient;

namespace CapaDatos
{
    //Le agrego public para que sea una clase pública
    public class DProveedores
    {
        //declaro todas las variables que hacen referencia a un campo de la tabla Proveedores
        private int _ProveedorID;
        private string _ProCodigo;
        private string _ProNombr;
        private string _ProNomch;
        private string _ProDirec;
        private string _ProTelef;
        private string _ProFax;
        private string _ProLocal;
        private string _ProProvi;
        private string _ProCPost;
        private string _ProCIva;
        private string _ProCuit;
        private string _ProRamo;
        private string _ProServi;
        private string _ProIngbr;
        private string _ProGanan;
        private string _ProNIngb;
        private string _ProActiv;
        private string _ProAgper;
        private string _ProGrupo;
        private DateTime _ProFeins;
        private string _ProAciva;
        private string _ProCai;
        private DateTime _ProFecai;
        private string _ProAduan;
        private string _ProCBanc;
        private string _ProDespa;
        private string _ProOk;
        private string _ProMail;
        private string _ProActivDesc;
        private string _ProPais;

        private string _TextoBuscar;

        //Luego de definirlos debo encapsular las variables
        public int ProveedorID
        {
            get { return _ProveedorID; }
            set { _ProveedorID = value; }
        }
        public string ProCodigo { get => _ProCodigo; set => _ProCodigo = value; }
        public string ProNombr { get => _ProNombr; set => _ProNombr = value; }
        public string ProNomch { get => _ProNomch; set => _ProNomch = value; }
        public string ProDirec { get => _ProDirec; set => _ProDirec = value; }
        public string ProTelef { get => _ProTelef; set => _ProTelef = value; }
        public string ProFax { get => _ProFax; set => _ProFax = value; }
        public string ProLocal { get => _ProLocal; set => _ProLocal = value; }
        public string ProProvi { get => _ProProvi; set => _ProProvi = value; }
        public string ProCPost { get => _ProCPost; set => _ProCPost = value; }
        public string ProCIva { get => _ProCIva; set => _ProCIva = value; }
        public string ProCuit { get => _ProCuit; set => _ProCuit = value; }
        public string ProRamo { get => _ProRamo; set => _ProRamo = value; }
        public string ProServi { get => _ProServi; set => _ProServi = value; }
        public string ProIngbr { get => _ProIngbr; set => _ProIngbr = value; }
        public string ProGanan { get => _ProGanan; set => _ProGanan = value; }
        public string ProNIngb { get => _ProNIngb; set => _ProNIngb = value; }
        public string ProActiv { get => _ProActiv; set => _ProActiv = value; }
        public string ProAgper { get => _ProAgper; set => _ProAgper = value; }
        public string ProGrupo { get => _ProGrupo; set => _ProGrupo = value; }
        public DateTime ProFeins { get => _ProFeins; set => _ProFeins = value; }
        public string ProAciva { get => _ProAciva; set => _ProAciva = value; }
        public string ProCai { get => _ProCai; set => _ProCai = value; }
        public DateTime ProFecai { get => _ProFecai; set => _ProFecai = value; }
        public string ProAduan { get => _ProAduan; set => _ProAduan = value; }
        public string ProCBanc { get => _ProCBanc; set => _ProCBanc = value; }
        public string ProDespa { get => _ProDespa; set => _ProDespa = value; }
        public string ProOk { get => _ProOk; set => _ProOk = value; }
        public string ProMail { get => _ProMail; set => _ProMail = value; }
        public string ProActivDesc { get => _ProActivDesc; set => _ProActivDesc = value; }
        public string ProPais { get => _ProPais; set => _ProPais = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Creo los constructores
        public DProveedores()
        {

        }

        //constructor con parámetros - los que están con minúscula son los parámetros que está recibiendo
        public DProveedores(int proveedorid,string procodigo,string pronombr,string pronomch,string prodirec,
                            string protelef,string profax,string prolocal,string proprovi,string procpost,string prociva,
                            string procuit,string proramo,string proservi,string proingbr,string proganan,string proningb,
                            string proactiv,string proagper,string progrupo,DateTime profeins,string proaciva,string procai,
                            DateTime profecai,string proaduan,string procbanc,string prodespa,string prook,string promail,
                            string proactivdesc, string propais, string textobuscar)
        {
            this.ProveedorID = proveedorid;
            this.ProCodigo = procodigo;
            this.ProNombr = pronombr;
            this.ProNomch = pronomch;
            this.ProDirec = prodirec;
            this.ProTelef = protelef;
            this.ProFax = profax;
            this.ProLocal = prolocal;
            this.ProProvi = proprovi;
            this.ProCPost = procpost;
            this.ProCIva = prociva;
            this.ProCuit = procuit;
            this.ProRamo = proramo;
            this.ProServi = proservi;
            this.ProIngbr = proingbr;
            this.ProGanan = proganan;
            this.ProNIngb = proningb;
            this.ProActiv = proactiv;
            this.ProAgper = proagper;
            this.ProGrupo = progrupo;
            this.ProFeins = profeins;
            this.ProAciva = proaciva;
            this.ProCai = procai;
            this.ProFecai = profecai;
            this.ProAduan = proaduan;
            this.ProCBanc = procbanc;
            this.ProDespa = prodespa;
            this.ProOk = prook;
            this.ProMail = promail;
            this.ProActivDesc = proactivdesc;
            this.ProPais = propais;

            this.TextoBuscar = textobuscar;
        }
        //Método Insertar
        public string Insertar(DProveedores Proveedores)
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
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParProveedorID = new SqlParameter();
                ParProveedorID.ParameterName = "@ProveedorID";
                ParProveedorID.SqlDbType = SqlDbType.Int;
                //@ProveedorID es autonumerico, es parámetro de salida
                ParProveedorID.Direction = ParameterDirection.Output;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParProveedorID);

                SqlParameter ParProCodigo = new SqlParameter();
                ParProCodigo.ParameterName = "@ProCodigo";
                ParProCodigo.SqlDbType = SqlDbType.VarChar;
                ParProCodigo.Size = 4;
                ParProCodigo.Value = Proveedores.ProCodigo;
                SqlCmd.Parameters.Add(ParProCodigo);

                SqlParameter ParProNombr = new SqlParameter();
                ParProNombr.ParameterName = "@ProNombr";
                ParProNombr.SqlDbType = SqlDbType.VarChar;
                ParProNombr.Size = 50;
                ParProNombr.Value = Proveedores.ProNombr;
                SqlCmd.Parameters.Add(ParProNombr);

                SqlParameter ParProNomch = new SqlParameter();
                ParProNomch.ParameterName = "@ProNomch";
                ParProNomch.SqlDbType = SqlDbType.VarChar;
                ParProNomch.Size = 44;
                ParProNomch.Value = Proveedores.ProNomch;
                SqlCmd.Parameters.Add(ParProNomch);

                //agrego yo parámetro ProDirec y el resto de los campos de la Tabla Proveedores
                SqlParameter ParProDirec = new SqlParameter();
                ParProDirec.ParameterName = "@ProDirec";
                ParProDirec.SqlDbType = SqlDbType.VarChar;
                ParProDirec.Size = 50;
                ParProDirec.Value = Proveedores.ProDirec;
                SqlCmd.Parameters.Add(ParProDirec);

                SqlParameter ParProTelef = new SqlParameter();
                ParProTelef.ParameterName = "@ProTelef";
                ParProTelef.SqlDbType = SqlDbType.VarChar;
                ParProTelef.Size = 25;
                ParProTelef.Value = Proveedores.ProTelef;
                SqlCmd.Parameters.Add(ParProTelef);

                SqlParameter ParProFax = new SqlParameter();
                ParProFax.ParameterName = "@ProFax";
                ParProFax.SqlDbType = SqlDbType.VarChar;
                ParProFax.Size = 12;
                ParProFax.Value = Proveedores.ProFax;
                SqlCmd.Parameters.Add(ParProFax);

                SqlParameter ParProLocal = new SqlParameter();
                ParProLocal.ParameterName = "@ProLocal";
                ParProLocal.SqlDbType = SqlDbType.VarChar;
                ParProLocal.Size = 25;
                ParProLocal.Value = Proveedores.ProLocal;
                SqlCmd.Parameters.Add(ParProLocal);

                SqlParameter ParProProvi = new SqlParameter();
                ParProProvi.ParameterName = "@ProProvi";
                ParProProvi.SqlDbType = SqlDbType.VarChar;
                ParProProvi.Size = 25;
                ParProProvi.Value = Proveedores.ProProvi;
                SqlCmd.Parameters.Add(ParProProvi);

                SqlParameter ParProCPost = new SqlParameter();
                ParProCPost.ParameterName = "@ProCPost";
                ParProCPost.SqlDbType = SqlDbType.VarChar;
                ParProCPost.Size = 8;
                ParProCPost.Value = Proveedores.ProCPost;
                SqlCmd.Parameters.Add(ParProCPost);

                SqlParameter ParProCIva = new SqlParameter();
                ParProCIva.ParameterName = "@ProCIva";
                ParProCIva.SqlDbType = SqlDbType.VarChar;
                ParProCIva.Size = 1;
                ParProCIva.Value = Proveedores.ProCIva;
                SqlCmd.Parameters.Add(ParProCIva);

                SqlParameter ParProCuit = new SqlParameter();
                ParProCuit.ParameterName = "@ProCuit";
                ParProCuit.SqlDbType = SqlDbType.VarChar;
                ParProCuit.Size = 13;
                ParProCuit.Value = Proveedores.ProCuit;
                SqlCmd.Parameters.Add(ParProCuit);

                SqlParameter ParProRamo = new SqlParameter();
                ParProRamo.ParameterName = "@ProRamo";
                ParProRamo.SqlDbType = SqlDbType.VarChar;
                ParProRamo.Size = 1;
                ParProRamo.Value = Proveedores.ProRamo;
                SqlCmd.Parameters.Add(ParProRamo);

                SqlParameter ParProServi = new SqlParameter();
                ParProServi.ParameterName = "@ProServi";
                ParProServi.SqlDbType = SqlDbType.VarChar;
                ParProServi.Size = 1;
                ParProServi.Value = Proveedores.ProServi;
                SqlCmd.Parameters.Add(ParProServi);

                SqlParameter ParProIngbr = new SqlParameter();
                ParProIngbr.ParameterName = "@ProIngbr";
                ParProIngbr.SqlDbType = SqlDbType.VarChar;
                ParProIngbr.Size = 1;
                ParProIngbr.Value = Proveedores.ProIngbr;
                SqlCmd.Parameters.Add(ParProIngbr);

                SqlParameter ParProGanan = new SqlParameter();
                ParProGanan.ParameterName = "@ProGanan";
                ParProGanan.SqlDbType = SqlDbType.VarChar;
                ParProGanan.Size = 1;
                ParProGanan.Value = Proveedores.ProGanan;
                SqlCmd.Parameters.Add(ParProGanan);

                SqlParameter ParProNIngb = new SqlParameter();
                ParProNIngb.ParameterName = "@ProNIngb";
                ParProNIngb.SqlDbType = SqlDbType.VarChar;
                ParProNIngb.Size = 15;
                ParProNIngb.Value = Proveedores.ProNIngb;
                SqlCmd.Parameters.Add(ParProNIngb);

                SqlParameter ParProActiv = new SqlParameter();
                ParProActiv.ParameterName = "@ProActiv";
                ParProActiv.SqlDbType = SqlDbType.VarChar;
                ParProActiv.Size = 2;
                ParProActiv.Value = Proveedores.ProActiv;
                SqlCmd.Parameters.Add(ParProActiv);

                SqlParameter ParProAgper = new SqlParameter();
                ParProAgper.ParameterName = "@ProAgper";
                ParProAgper.SqlDbType = SqlDbType.VarChar;
                ParProAgper.Size = 1;
                ParProAgper.Value = Proveedores.ProAgper;
                SqlCmd.Parameters.Add(ParProAgper);

                SqlParameter ParProGrupo = new SqlParameter();
                ParProGrupo.ParameterName = "@ProGrupo";
                ParProGrupo.SqlDbType = SqlDbType.VarChar;
                ParProGrupo.Size = 2;
                ParProGrupo.Value = Proveedores.ProGrupo;
                SqlCmd.Parameters.Add(ParProGrupo);

                SqlParameter ParProFeins = new SqlParameter();
                ParProFeins.ParameterName = "@ProFeins";
                ParProFeins.SqlDbType = SqlDbType.DateTime;
                //ParProFeins.Size = 1;
                ParProFeins.Value = Proveedores.ProFeins;
                SqlCmd.Parameters.Add(ParProFeins);

                SqlParameter ParProAciva = new SqlParameter();
                ParProAciva.ParameterName = "@ProAciva";
                ParProAciva.SqlDbType = SqlDbType.VarChar;
                ParProAciva.Size = 1;
                ParProAciva.Value = Proveedores.ProAciva;
                SqlCmd.Parameters.Add(ParProAciva);

                SqlParameter ParProCai = new SqlParameter();
                ParProCai.ParameterName = "@ProCai";
                ParProCai.SqlDbType = SqlDbType.VarChar;
                ParProCai.Size = 14;
                ParProCai.Value = Proveedores.ProCai;
                SqlCmd.Parameters.Add(ParProCai);

                SqlParameter ParProFecai = new SqlParameter();
                ParProFecai.ParameterName = "@ProFecai";
                ParProFecai.SqlDbType = SqlDbType.DateTime;
                //ParProFecai.Size = 14;
                ParProFecai.Value = Proveedores.ProFecai;
                SqlCmd.Parameters.Add(ParProFecai);

                SqlParameter ParProAduan = new SqlParameter();
                ParProAduan.ParameterName = "@ProAduan";
                ParProAduan.SqlDbType = SqlDbType.VarChar;
                ParProAduan.Size = 1;
                ParProAduan.Value = Proveedores.ProAduan;
                SqlCmd.Parameters.Add(ParProAduan);

                SqlParameter ParProCBanc = new SqlParameter();
                ParProCBanc.ParameterName = "@ProCBanc";
                ParProCBanc.SqlDbType = SqlDbType.VarChar;
                ParProCBanc.Size = 11;
                ParProCBanc.Value = Proveedores.ProCBanc;
                SqlCmd.Parameters.Add(ParProCBanc);

                SqlParameter ParProDespa = new SqlParameter();
                ParProDespa.ParameterName = "@ProDespa";
                ParProDespa.SqlDbType = SqlDbType.VarChar;
                ParProDespa.Size = 1;
                ParProDespa.Value = Proveedores.ProDespa;
                SqlCmd.Parameters.Add(ParProDespa);

                SqlParameter ParProOk = new SqlParameter();
                ParProOk.ParameterName = "@ProOk";
                ParProOk.SqlDbType = SqlDbType.VarChar;
                ParProOk.Size = 1;
                ParProOk.Value = Proveedores.ProOk;
                SqlCmd.Parameters.Add(ParProOk);

                SqlParameter ParProMail = new SqlParameter();
                ParProMail.ParameterName = "@ProMail";
                ParProMail.SqlDbType = SqlDbType.VarChar;
                ParProMail.Size = 50;
                ParProMail.Value = Proveedores.ProMail;
                SqlCmd.Parameters.Add(ParProMail);

                SqlParameter ParProActivDesc = new SqlParameter();
                ParProActivDesc.ParameterName = "@ProActivDesc";
                ParProActivDesc.SqlDbType = SqlDbType.VarChar;
                ParProActivDesc.Size = 50;
                ParProActivDesc.Value = Proveedores.ProActivDesc;
                SqlCmd.Parameters.Add(ParProActivDesc);

                SqlParameter ParProPais = new SqlParameter();
                ParProPais.ParameterName = "@ProPais";
                ParProPais.SqlDbType = SqlDbType.VarChar;
                ParProPais.Size = 30;
                ParProPais.Value = Proveedores.ProPais;
                SqlCmd.Parameters.Add(ParProPais);

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
        public string Editar(DProveedores Proveedores)
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
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParProveedorID = new SqlParameter();
                ParProveedorID.ParameterName = "@ProveedorID";
                ParProveedorID.SqlDbType = SqlDbType.Int;
                ParProveedorID.Value = Proveedores.ProveedorID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParProveedorID);

                SqlParameter ParProCodigo = new SqlParameter();
                ParProCodigo.ParameterName = "@ProCodigo";
                ParProCodigo.SqlDbType = SqlDbType.VarChar;
                ParProCodigo.Size = 4;
                ParProCodigo.Value = Proveedores.ProCodigo;
                SqlCmd.Parameters.Add(ParProCodigo);

                SqlParameter ParProNombr = new SqlParameter();
                ParProNombr.ParameterName = "@ProNombr";
                ParProNombr.SqlDbType = SqlDbType.VarChar;
                ParProNombr.Size = 50;
                ParProNombr.Value = Proveedores.ProNombr;
                SqlCmd.Parameters.Add(ParProNombr);

                SqlParameter ParProNomch = new SqlParameter();
                ParProNomch.ParameterName = "@ProNomch";
                ParProNomch.SqlDbType = SqlDbType.VarChar;
                ParProNomch.Size = 44;
                ParProNomch.Value = Proveedores.ProNomch;
                SqlCmd.Parameters.Add(ParProNomch);

                //agrego yo parámetro ProDirec y el resto de los campos de la Tabla Proveedores
                SqlParameter ParProDirec = new SqlParameter();
                ParProDirec.ParameterName = "@ProDirec";
                ParProDirec.SqlDbType = SqlDbType.VarChar;
                ParProDirec.Size = 50;
                ParProDirec.Value = Proveedores.ProDirec;
                SqlCmd.Parameters.Add(ParProDirec);

                SqlParameter ParProTelef = new SqlParameter();
                ParProTelef.ParameterName = "@ProTelef";
                ParProTelef.SqlDbType = SqlDbType.VarChar;
                ParProTelef.Size = 25;
                ParProTelef.Value = Proveedores.ProTelef;
                SqlCmd.Parameters.Add(ParProTelef);

                SqlParameter ParProFax = new SqlParameter();
                ParProFax.ParameterName = "@ProFax";
                ParProFax.SqlDbType = SqlDbType.VarChar;
                ParProFax.Size = 12;
                ParProFax.Value = Proveedores.ProFax;
                SqlCmd.Parameters.Add(ParProFax);

                SqlParameter ParProLocal = new SqlParameter();
                ParProLocal.ParameterName = "@ProLocal";
                ParProLocal.SqlDbType = SqlDbType.VarChar;
                ParProLocal.Size = 25;
                ParProLocal.Value = Proveedores.ProLocal;
                SqlCmd.Parameters.Add(ParProLocal);

                SqlParameter ParProProvi = new SqlParameter();
                ParProProvi.ParameterName = "@ProProvi";
                ParProProvi.SqlDbType = SqlDbType.VarChar;
                ParProProvi.Size = 25;
                ParProProvi.Value = Proveedores.ProProvi;
                SqlCmd.Parameters.Add(ParProProvi);

                SqlParameter ParProCPost = new SqlParameter();
                ParProCPost.ParameterName = "@ProCPost";
                ParProCPost.SqlDbType = SqlDbType.VarChar;
                ParProCPost.Size = 8;
                ParProCPost.Value = Proveedores.ProCPost;
                SqlCmd.Parameters.Add(ParProCPost);

                SqlParameter ParProCIva = new SqlParameter();
                ParProCIva.ParameterName = "@ProCIva";
                ParProCIva.SqlDbType = SqlDbType.VarChar;
                ParProCIva.Size = 1;
                ParProCIva.Value = Proveedores.ProCIva;
                SqlCmd.Parameters.Add(ParProCIva);

                SqlParameter ParProCuit = new SqlParameter();
                ParProCuit.ParameterName = "@ProCuit";
                ParProCuit.SqlDbType = SqlDbType.VarChar;
                ParProCuit.Size = 13;
                ParProCuit.Value = Proveedores.ProCuit;
                SqlCmd.Parameters.Add(ParProCuit);

                SqlParameter ParProRamo = new SqlParameter();
                ParProRamo.ParameterName = "@ProRamo";
                ParProRamo.SqlDbType = SqlDbType.VarChar;
                ParProRamo.Size = 1;
                ParProRamo.Value = Proveedores.ProRamo;
                SqlCmd.Parameters.Add(ParProRamo);

                SqlParameter ParProServi = new SqlParameter();
                ParProServi.ParameterName = "@ProServi";
                ParProServi.SqlDbType = SqlDbType.VarChar;
                ParProServi.Size = 1;
                ParProServi.Value = Proveedores.ProServi;
                SqlCmd.Parameters.Add(ParProServi);

                SqlParameter ParProIngbr = new SqlParameter();
                ParProIngbr.ParameterName = "@ProIngbr";
                ParProIngbr.SqlDbType = SqlDbType.VarChar;
                ParProIngbr.Size = 1;
                ParProIngbr.Value = Proveedores.ProIngbr;
                SqlCmd.Parameters.Add(ParProIngbr);

                SqlParameter ParProGanan = new SqlParameter();
                ParProGanan.ParameterName = "@ProGanan";
                ParProGanan.SqlDbType = SqlDbType.VarChar;
                ParProGanan.Size = 1;
                ParProGanan.Value = Proveedores.ProGanan;
                SqlCmd.Parameters.Add(ParProGanan);

                SqlParameter ParProNIngb = new SqlParameter();
                ParProNIngb.ParameterName = "@ProNIngb";
                ParProNIngb.SqlDbType = SqlDbType.VarChar;
                ParProNIngb.Size = 15;
                ParProNIngb.Value = Proveedores.ProNIngb;
                SqlCmd.Parameters.Add(ParProNIngb);

                SqlParameter ParProActiv = new SqlParameter();
                ParProActiv.ParameterName = "@ProActiv";
                ParProActiv.SqlDbType = SqlDbType.VarChar;
                ParProActiv.Size = 2;
                ParProActiv.Value = Proveedores.ProActiv;
                SqlCmd.Parameters.Add(ParProActiv);

                SqlParameter ParProAgper = new SqlParameter();
                ParProAgper.ParameterName = "@ProAgper";
                ParProAgper.SqlDbType = SqlDbType.VarChar;
                ParProAgper.Size = 1;
                ParProAgper.Value = Proveedores.ProAgper;
                SqlCmd.Parameters.Add(ParProAgper);

                SqlParameter ParProGrupo = new SqlParameter();
                ParProGrupo.ParameterName = "@ProGrupo";
                ParProGrupo.SqlDbType = SqlDbType.VarChar;
                ParProGrupo.Size = 2;
                ParProGrupo.Value = Proveedores.ProGrupo;
                SqlCmd.Parameters.Add(ParProGrupo);

                SqlParameter ParProFeins = new SqlParameter();
                ParProFeins.ParameterName = "@ProFeins";
                ParProFeins.SqlDbType = SqlDbType.DateTime;
                //ParProFeins.Size = 1;
                ParProFeins.Value = Proveedores.ProFeins;
                SqlCmd.Parameters.Add(ParProFeins);

                SqlParameter ParProAciva = new SqlParameter();
                ParProAciva.ParameterName = "@ProAciva";
                ParProAciva.SqlDbType = SqlDbType.VarChar;
                ParProAciva.Size = 1;
                ParProAciva.Value = Proveedores.ProAciva;
                SqlCmd.Parameters.Add(ParProAciva);

                SqlParameter ParProCai = new SqlParameter();
                ParProCai.ParameterName = "@ProCai";
                ParProCai.SqlDbType = SqlDbType.VarChar;
                ParProCai.Size = 14;
                ParProCai.Value = Proveedores.ProCai;
                SqlCmd.Parameters.Add(ParProCai);

                SqlParameter ParProFecai = new SqlParameter();
                ParProFecai.ParameterName = "@ProFecai";
                ParProFecai.SqlDbType = SqlDbType.DateTime;
                //ParProFecai.Size = 14;
                ParProFecai.Value = Proveedores.ProFecai;
                SqlCmd.Parameters.Add(ParProFecai);

                SqlParameter ParProAduan = new SqlParameter();
                ParProAduan.ParameterName = "@ProAduan";
                ParProAduan.SqlDbType = SqlDbType.VarChar;
                ParProAduan.Size = 1;
                ParProAduan.Value = Proveedores.ProAduan;
                SqlCmd.Parameters.Add(ParProAduan);

                SqlParameter ParProCBanc = new SqlParameter();
                ParProCBanc.ParameterName = "@ProCBanc";
                ParProCBanc.SqlDbType = SqlDbType.VarChar;
                ParProCBanc.Size = 11;
                ParProCBanc.Value = Proveedores.ProCBanc;
                SqlCmd.Parameters.Add(ParProCBanc);

                SqlParameter ParProDespa = new SqlParameter();
                ParProDespa.ParameterName = "@ProDespa";
                ParProDespa.SqlDbType = SqlDbType.VarChar;
                ParProDespa.Size = 1;
                ParProDespa.Value = Proveedores.ProDespa;
                SqlCmd.Parameters.Add(ParProDespa);

                SqlParameter ParProOk = new SqlParameter();
                ParProOk.ParameterName = "@ProOk";
                ParProOk.SqlDbType = SqlDbType.VarChar;
                ParProOk.Size = 1;
                ParProOk.Value = Proveedores.ProOk;
                SqlCmd.Parameters.Add(ParProOk);

                SqlParameter ParProMail = new SqlParameter();
                ParProMail.ParameterName = "@ProMail";
                ParProMail.SqlDbType = SqlDbType.VarChar;
                ParProMail.Size = 50;
                ParProMail.Value = Proveedores.ProMail;
                SqlCmd.Parameters.Add(ParProMail);

                SqlParameter ParProActivDesc = new SqlParameter();
                ParProActivDesc.ParameterName = "@ProActivDesc";
                ParProActivDesc.SqlDbType = SqlDbType.VarChar;
                ParProActivDesc.Size = 50;
                ParProActivDesc.Value = Proveedores.ProActivDesc;
                SqlCmd.Parameters.Add(ParProActivDesc);

                SqlParameter ParProPais = new SqlParameter();
                ParProPais.ParameterName = "@ProPais";
                ParProPais.SqlDbType = SqlDbType.VarChar;
                ParProPais.Size = 30;
                ParProPais.Value = Proveedores.ProPais;
                SqlCmd.Parameters.Add(ParProPais);

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
        public string Eliminar(DProveedores Proveedores)
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
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //defino los parámetros q va a recibir
                SqlParameter ParProveedorID = new SqlParameter();
                ParProveedorID.ParameterName = "@ProveedorID";
                ParProveedorID.SqlDbType = SqlDbType.Int;
                //@ProveedorID es autonumerico, es parámetro de salida
                ParProveedorID.Value = Proveedores.ProveedorID;
                //agrego el parámetro al comando sql
                SqlCmd.Parameters.Add(ParProveedorID);

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
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public static DataTable ListaCodigoNombre()
        {
            DataTable DtResultado = new DataTable("ListaCodigoNombre");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_ProveedorCodigoNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //método BuscarNombre
        public DataTable BuscarNombre(DProveedores Proveedores)
        {
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_nombr";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedores.TextoBuscar;
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
        public DataTable BuscarCuit(DProveedores Proveedores)
        {
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_cuit";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 13;
                ParTextoBuscar.Value = Proveedores.TextoBuscar;
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

        //método BuscarProCodigo
        public DataTable BuscarProCodigo(DProveedores Proveedores)
        {
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_procodigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedores.TextoBuscar;
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

		public static string CondicionIVA(string codigo)
		{
			string condicion = "";
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_CondicionIVA";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParCondicion = new SqlParameter();
				ParCondicion.ParameterName = "@CondicionIVA";
				ParCondicion.SqlDbType = SqlDbType.VarChar;
				ParCondicion.Size = 1;
				ParCondicion.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParCondicion);

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlCmd.ExecuteScalar();
				condicion = (string)ParCondicion.Value;
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open)
				{
					SqlCon.Close();
				}
			}
			return condicion;
		}

		public static string ValidarPadronARBA(string codigo)
		{
			string resultado = "";
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ValidarPadronARBA";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlParameter ParResultado = new SqlParameter();
				ParResultado.ParameterName = "@Resultado";
				ParResultado.SqlDbType = SqlDbType.VarChar;
				ParResultado.Size = 255;
				ParResultado.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParResultado);

				SqlCmd.ExecuteScalar();
				resultado = (string)ParResultado.Value;
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open)
				{
					SqlCon.Close();
				}
			}
			return resultado;
		}

		public static string ValidarPadronCABA(string codigo)
		{
			string resultado = "";
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ValidarPadronCABA";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlParameter ParResultado = new SqlParameter();
				ParResultado.ParameterName = "@Resultado";
				ParResultado.SqlDbType = SqlDbType.VarChar;
				ParResultado.Size = 255;
				ParResultado.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParResultado);

				SqlCmd.ExecuteScalar();
				resultado = (string)ParResultado.Value;
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open)
				{
					SqlCon.Close();
				}
			}
			return resultado;
		}

		public static bool EsExento(string codigo)
		{
			bool exento = false;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_EsExento";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParExento = new SqlParameter();
				ParExento.ParameterName = "@Exento";
				ParExento.SqlDbType = SqlDbType.Bit;
				ParExento.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParExento);

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlCmd.ExecuteScalar();

				if (ParExento != null)
				{
					exento = (bool)ParExento.Value;
				}
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return exento;
		}

		public static decimal AlicuotaIIBB_ARBA(string codigo)
		{
			decimal alicuota = 0;
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_AlicuotaIIBB_ARBA";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlParameter ParAlicuota = new SqlParameter("@Alicuota", SqlDbType.Decimal);
				ParAlicuota.Direction = ParameterDirection.Output;
				ParAlicuota.Precision = 4;
				ParAlicuota.Scale = 2;
				SqlCmd.Parameters.Add(ParAlicuota);

				SqlCmd.ExecuteScalar();
				alicuota = Convert.ToDecimal(ParAlicuota.Value);
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open)
				{
					SqlCon.Close();
				}
			}
			return alicuota;
		}

		public static decimal AlicuotaIIBB_CABA(string codigo)
		{
			decimal alicuota = 0;
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_AlicuotaIIBB_CABA";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = codigo;

				SqlParameter ParAlicuota = new SqlParameter("@Alicuota", SqlDbType.Decimal);
				ParAlicuota.Direction = ParameterDirection.Output;
				ParAlicuota.Precision = 4;
				ParAlicuota.Scale = 2;
				SqlCmd.Parameters.Add(ParAlicuota);

				SqlCmd.ExecuteScalar();
				alicuota = Convert.ToDecimal(ParAlicuota.Value);
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open)
				{
					SqlCon.Close();
				}
			}
			return alicuota;
		}
	}
}
