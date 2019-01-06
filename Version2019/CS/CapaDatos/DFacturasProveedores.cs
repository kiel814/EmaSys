using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DFacturasProveedores
    {
        public String _CodigoProveedor;
        public String _TipoFactura;
        public String _Sucursal;
        public String _Documento;
        public DateTime _FechaFactura;
        public DateTime _FechaCarga;
        public DateTime _Vencimiento;
        public decimal _MontoNeto;
        public decimal _MontoExento;
        public decimal _PorcentajeIVA;
        public decimal _MontoIVA;
        public decimal _PorcentajePercepcionIVA;
        public decimal _MontoPercepcionIVA;
        public decimal _PorcentajeIIBB;
        public decimal _MontoIIBB;
        public String _Material;
        public String _Provincia;
        public bool _BienDeUso;
        public bool _Activo;
        public decimal _Total;
        public String _Observaciones;

        public DFacturasProveedores()
        {
        }

        public string Insertar()
        {
            String Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_InsertarFacturaProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParID = new SqlParameter();
                ParID.ParameterName = "@ID";
                ParID.SqlDbType = SqlDbType.Int;
                ParID.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParID);

                SqlCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar, 4).Value = _CodigoProveedor;
                SqlCmd.Parameters.Add("@TipoFactura", SqlDbType.VarChar, 1).Value = _TipoFactura;
                SqlCmd.Parameters.Add("@Sucursal", SqlDbType.VarChar, 4).Value = _Sucursal;
                SqlCmd.Parameters.Add("@Documento", SqlDbType.VarChar, 8).Value = _Documento;
                SqlCmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = _FechaFactura;
                SqlCmd.Parameters.Add("@FechaCarga", SqlDbType.Date).Value = _FechaCarga;
                SqlCmd.Parameters.Add("@Vencimiento", SqlDbType.Date).Value = _Vencimiento;
                SqlParameter ParMontoNeto = SqlCmd.Parameters.Add("@MontoNeto", SqlDbType.Decimal);
                ParMontoNeto.Precision = 15;
                ParMontoNeto.Scale = 2;
                ParMontoNeto.Value = _MontoNeto;
                SqlParameter ParMontoExento = SqlCmd.Parameters.Add("@MontoExento", SqlDbType.Decimal);
                ParMontoExento.Precision = 15;
                ParMontoExento.Scale = 2;
                ParMontoExento.Value = _MontoExento;
                SqlParameter ParPorcIVA = SqlCmd.Parameters.Add("@PorcentajeIVA", SqlDbType.Decimal);
                ParPorcIVA.Precision = 5;
                ParPorcIVA.Scale = 2;
                ParPorcIVA.Value = _PorcentajeIVA;
                SqlParameter ParMontoIVA = SqlCmd.Parameters.Add("@MontoIVA", SqlDbType.Decimal);
                ParMontoIVA.Precision = 15;
                ParMontoIVA.Scale = 2;
                ParMontoIVA.Value = _MontoIVA;
                SqlParameter ParPorcPercepcion = SqlCmd.Parameters.Add("@PorcentajePercepcionIVA", SqlDbType.Decimal);
                ParPorcPercepcion.Precision = 5;
                ParPorcPercepcion.Scale = 2;
                ParPorcPercepcion.Value = _PorcentajePercepcionIVA;
                SqlParameter ParMontoPercepcion = SqlCmd.Parameters.Add("@MontoPercepcionIVA", SqlDbType.Decimal);
                ParMontoPercepcion.Precision = 15;
                ParMontoPercepcion.Scale = 2;
                ParMontoPercepcion.Value = _MontoPercepcionIVA;
                SqlParameter ParPorcIIBB = SqlCmd.Parameters.Add("@PorcentajeIIBB", SqlDbType.Decimal);
                ParPorcIIBB.Precision = 5;
                ParPorcIIBB.Scale = 2;
                ParPorcIIBB.Value = _PorcentajeIIBB;
                SqlParameter ParMontoIIBB = SqlCmd.Parameters.Add("@MontoIIBB", SqlDbType.Decimal);
                ParMontoIIBB.Precision = 15;
                ParMontoIIBB.Scale = 2;
                ParMontoIIBB.Value = _MontoIIBB;
                SqlCmd.Parameters.Add("@Material", SqlDbType.VarChar, 1).Value = _Material;
                SqlCmd.Parameters.Add("@Provincia", SqlDbType.VarChar, 1).Value = _Provincia;
                SqlCmd.Parameters.Add("@BienDeUso", SqlDbType.Bit).Value = _BienDeUso;
                SqlCmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = _Activo;
                SqlParameter ParTotal = SqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                ParTotal.Precision = 15;
                ParTotal.Scale = 2;
                ParTotal.Value = _Total;
                SqlCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = _Observaciones;

                /*SqlParameter ParProCodigo = new SqlParameter();
                ParProCodigo.ParameterName = "@Proveedor";
                ParProCodigo.SqlDbType = SqlDbType.VarChar;
                ParProCodigo.Size = 4;
                ParProCodigo.Value = _CodigoProveedor;
                SqlCmd.Parameters.Add(ParProCodigo);

                SqlParameter ParProNombr = new SqlParameter();
                ParProNombr.ParameterName = "@TipoFactura";
                ParProNombr.SqlDbType = SqlDbType.VarChar;
                ParProNombr.Size = 1;
                ParProNombr.Value = _TipoFactura;
                SqlCmd.Parameters.Add(ParProNombr);

                SqlParameter ParProNomch = new SqlParameter();
                ParProNomch.ParameterName = "@Sucursal";
                ParProNomch.SqlDbType = SqlDbType.VarChar;
                ParProNomch.Size = 4;
                ParProNomch.Value = _Sucursal;
                SqlCmd.Parameters.Add(ParProNomch);

                SqlParameter ParProDirec = new SqlParameter();
                ParProDirec.ParameterName = "@Documento";
                ParProDirec.SqlDbType = SqlDbType.VarChar;
                ParProDirec.Size = 8;
                ParProDirec.Value = _Documento;
                SqlCmd.Parameters.Add(ParProDirec);

                SqlParameter ParProTelef = new SqlParameter();
                ParProTelef.ParameterName = "@Fecha";
                ParProTelef.SqlDbType = SqlDbType.Date;
                ParProTelef.Value = _FechaFactura;
                SqlCmd.Parameters.Add(ParProTelef);

                SqlParameter ParProFax = new SqlParameter();
                ParProFax.ParameterName = "@FechaCarga";
                ParProFax.SqlDbType = SqlDbType.Date;
                ParProFax.Value = _FechaCarga;
                SqlCmd.Parameters.Add(ParProFax);*/

                //SqlCmd.Parameters.Add("@Vencimiento", SqlDbType.Date).Value = _Vencimiento;
                /*SqlParameter ParVencimiento = new SqlParameter();
                ParVencimiento.ParameterName = "@Vencimiento";
                ParVencimiento.SqlDbType = SqlDbType.Date;
                ParVencimiento.Value = _Vencimiento;
                SqlCmd.Parameters.Add(ParVencimiento);*/

                /*SqlParameter ParProProvi = new SqlParameter();
                ParProProvi.ParameterName = "@MontoNeto";
                ParProProvi.SqlDbType = SqlDbType.Decimal;
                ParProProvi.Size = 25;

                ParProProvi.Value = Proveedores.ProProvi;
                SqlCmd.Parameters.Add(ParProProvi);

                SqlParameter ParProCPost = new SqlParameter();
                ParProCPost.ParameterName = "@MontoExento";
                ParProCPost.SqlDbType = SqlDbType.VarChar;
                ParProCPost.Size = 8;
                ParProCPost.Value = Proveedores.ProCPost;
                SqlCmd.Parameters.Add(ParProCPost);

                SqlParameter ParProCIva = new SqlParameter();
                ParProCIva.ParameterName = "@PorcentajeIVA";
                ParProCIva.SqlDbType = SqlDbType.VarChar;
                ParProCIva.Size = 1;
                ParProCIva.Value = Proveedores.ProCIva;
                SqlCmd.Parameters.Add(ParProCIva);

                SqlParameter ParProCuit = new SqlParameter();
                ParProCuit.ParameterName = "@MontoIVA";
                ParProCuit.SqlDbType = SqlDbType.VarChar;
                ParProCuit.Size = 13;
                ParProCuit.Value = Proveedores.ProCuit;
                SqlCmd.Parameters.Add(ParProCuit);

                SqlParameter ParProRamo = new SqlParameter();
                ParProRamo.ParameterName = "@PorcentajePercepcionIVA";
                ParProRamo.SqlDbType = SqlDbType.VarChar;
                ParProRamo.Size = 1;
                ParProRamo.Value = Proveedores.ProRamo;
                SqlCmd.Parameters.Add(ParProRamo);

                SqlParameter ParProServi = new SqlParameter();
                ParProServi.ParameterName = "@MontoPercepcionIVA";
                ParProServi.SqlDbType = SqlDbType.VarChar;
                ParProServi.Size = 1;
                ParProServi.Value = Proveedores.ProServi;
                SqlCmd.Parameters.Add(ParProServi);

                SqlParameter ParProIngbr = new SqlParameter();
                ParProIngbr.ParameterName = "@PorcentajeIIBB";
                ParProIngbr.SqlDbType = SqlDbType.VarChar;
                ParProIngbr.Size = 1;
                ParProIngbr.Value = Proveedores.ProIngbr;
                SqlCmd.Parameters.Add(ParProIngbr);

                SqlParameter ParProGanan = new SqlParameter();
                ParProGanan.ParameterName = "@MontoIIBB";
                ParProGanan.SqlDbType = SqlDbType.VarChar;
                ParProGanan.Size = 1;
                ParProGanan.Value = Proveedores.ProGanan;
                SqlCmd.Parameters.Add(ParProGanan);

                SqlParameter ParProNIngb = new SqlParameter();
                ParProNIngb.ParameterName = "@Material";
                ParProNIngb.SqlDbType = SqlDbType.VarChar;
                ParProNIngb.Size = 15;
                ParProNIngb.Value = Proveedores.ProNIngb;
                SqlCmd.Parameters.Add(ParProNIngb);

                SqlParameter ParProActiv = new SqlParameter();
                ParProActiv.ParameterName = "@Provincia";
                ParProActiv.SqlDbType = SqlDbType.VarChar;
                ParProActiv.Size = 2;
                ParProActiv.Value = Proveedores.ProActiv;
                SqlCmd.Parameters.Add(ParProActiv);

                SqlParameter ParProAgper = new SqlParameter();
                ParProAgper.ParameterName = "@BienDeUso";
                ParProAgper.SqlDbType = SqlDbType.VarChar;
                ParProAgper.Size = 1;
                ParProAgper.Value = Proveedores.ProAgper;
                SqlCmd.Parameters.Add(ParProAgper);

                SqlParameter ParProGrupo = new SqlParameter();
                ParProGrupo.ParameterName = "@Activo";
                ParProGrupo.SqlDbType = SqlDbType.VarChar;
                ParProGrupo.Size = 2;
                ParProGrupo.Value = Proveedores.ProGrupo;
                SqlCmd.Parameters.Add(ParProGrupo);

                SqlParameter ParProFeins = new SqlParameter();
                ParProFeins.ParameterName = "@Total";
                ParProFeins.SqlDbType = SqlDbType.DateTime;
                //ParProFeins.Size = 1;
                ParProFeins.Value = Proveedores.ProFeins;
                SqlCmd.Parameters.Add(ParProFeins);

                SqlParameter ParProAciva = new SqlParameter();
                ParProAciva.ParameterName = "@Observaciones";
                ParProAciva.SqlDbType = SqlDbType.VarChar;
                ParProAciva.Size = 1;
                ParProAciva.Value = Proveedores.ProAciva;
                SqlCmd.Parameters.Add(ParProAciva);*/

                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar";
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Respuesta;
        }
    }
}