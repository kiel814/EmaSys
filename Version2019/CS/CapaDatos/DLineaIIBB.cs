using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
	public class DLineaIIBB
	{
		public int _Movimiento;
		public int _Linea;
		public String _Provincia;
		public decimal _Porcentaje;
		public decimal _Monto;

		public DLineaIIBB()
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
				SqlCmd.CommandText = "sp_InsertarLineaIIBB";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Movimiento", SqlDbType.Int).Value = _Movimiento;
				SqlCmd.Parameters.Add("@Linea", SqlDbType.Int).Value = _Linea;
				SqlCmd.Parameters.Add("@Provincia", SqlDbType.VarChar, 1).Value = _Provincia;
				SqlParameter ParPorcIVA = SqlCmd.Parameters.Add("@Porcentaje", SqlDbType.Decimal);
				ParPorcIVA.Precision = 5;
				ParPorcIVA.Scale = 4;
				ParPorcIVA.Value = _Porcentaje;
				SqlParameter ParMontoIVA = SqlCmd.Parameters.Add("@Monto", SqlDbType.Decimal);
				ParMontoIVA.Precision = 15;
				ParMontoIVA.Scale = 2;
				ParMontoIVA.Value = _Monto;

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