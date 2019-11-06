using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
	public class DLibroDiario
	{
		public String _Asiento;
		public String _Linea;
		public String _Cuenta;
		public DateTime _Fecha;
		public String _Tipo;
		public decimal _Importe;
		public String _TipoMovimiento;
		public String _TipoDocumento;
		public String _Moneda;
		public String _Observaciones;
		public int _EmpleadoID;
		public String _Estado;

		public DLibroDiario()
		{
		}

		public static String ObtenerAsientoLibre()
		{
			String numero = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ObtenerAsientoLibre";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParNumero = new SqlParameter();
				ParNumero.ParameterName = "@Numero";
				ParNumero.SqlDbType = SqlDbType.VarChar;
				ParNumero.Size = 6;
				ParNumero.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParNumero);

				SqlCmd.ExecuteScalar();

				if (ParNumero != null)
				{
					numero = (String)ParNumero.Value;
				}
			}
			catch (Exception ex)
			{
				String a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return numero;
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
				SqlCmd.CommandText = "sp_InsertarLineaAsiento";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Asiento", SqlDbType.VarChar, 6).Value = _Asiento;
				SqlCmd.Parameters.Add("@Linea", SqlDbType.VarChar, 2).Value = _Linea;
				SqlCmd.Parameters.Add("@Cuenta", SqlDbType.VarChar, 6).Value = _Cuenta;
				SqlCmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = _Fecha;
				SqlCmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 1).Value = _Tipo;
				SqlParameter ParImporte = SqlCmd.Parameters.Add("@Importe", SqlDbType.Decimal);
				ParImporte.Precision = 15;
				ParImporte.Scale = 2;
				ParImporte.Value = _Importe;
				SqlCmd.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 2).Value = _TipoMovimiento;
				SqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 1).Value = _TipoDocumento;
				SqlCmd.Parameters.Add("@Moneda", SqlDbType.VarChar, 3).Value = _Moneda;
				SqlCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = _Observaciones;
				SqlCmd.Parameters.Add("@EmpleadoID", SqlDbType.Int).Value = _EmpleadoID;
				SqlCmd.Parameters.Add("@Estado", SqlDbType.VarChar, 50).Value = _Estado;

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
