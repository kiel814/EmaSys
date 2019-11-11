using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
	public class DOrdenesPago
	{
		public int _ID;
		public DateTime _Fecha;
		public decimal _MontoIIBB;
		public decimal _PorcentajeGanancias;
		public decimal _MontoGanancias;
		public string _Estado;

		public List<Tuple<int, decimal>> _Pagos;

		public string Guardar()
		{
			string error = "";
			error = GenerarNuevoNumeroOrden();

			if (error == "")
			{
				error = InsertarOrden();
			}

			if (error == "")
			{
				error = InsertarPagos();
			}

			if (error == "")
			{
				error = ActualizarEstadoMovimientos();
			}

			return error;
		}

		private string GenerarNuevoNumeroOrden()
		{
			string result = "";
			_ID = 0;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ObtenerNuevoNumeroOrdenPago";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParNumero = new SqlParameter();
				ParNumero.ParameterName = "@Numero";
				ParNumero.SqlDbType = SqlDbType.Int;
				ParNumero.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParNumero);

				SqlCmd.ExecuteScalar();

				if (ParNumero != null)
				{
					_ID = Convert.ToInt32(ParNumero.Value);
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

			if (_ID == 0)
			{
				result = "No se pudo obtener nuevo número de orden.";
			}

			return result;
		}

		private string InsertarOrden()
		{
			string result = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_InsertarOrdenPago";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = _ID;
				SqlCmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = _Fecha;
				SqlParameter ParMontoIIBB = SqlCmd.Parameters.Add("@MontoIIBB", SqlDbType.Decimal);
				ParMontoIIBB.Precision = 15;
				ParMontoIIBB.Scale = 2;
				ParMontoIIBB.Value = _MontoIIBB;
				SqlParameter ParPorcentGan = SqlCmd.Parameters.Add("@PorcentajeGanancias", SqlDbType.Decimal);
				ParPorcentGan.Precision = 5;
				ParPorcentGan.Scale = 4;
				ParPorcentGan.Value = _PorcentajeGanancias;
				SqlParameter ParMontoGan = SqlCmd.Parameters.Add("@MontoGanancias", SqlDbType.Decimal);
				ParMontoGan.Precision = 5;
				ParMontoGan.Scale = 4;
				ParMontoGan.Value = _MontoGanancias;
				SqlCmd.Parameters.Add("@Estado", SqlDbType.VarChar, 7).Value = _Estado;

				result = SqlCmd.ExecuteNonQuery() == 1 ? "" : "Error al insertar";
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}

			return result;
		}

		private string InsertarPagos()
		{
			string result = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				for (int i = 0; i < _Pagos.Count; i++)
				{
					SqlCommand SqlCmd = new SqlCommand();
					SqlCmd.Connection = SqlCon;
					SqlCmd.CommandText = "sp_InsertarPago";
					SqlCmd.CommandType = CommandType.StoredProcedure;

					SqlCmd.Parameters.Add("@Orden", SqlDbType.Int).Value = _ID;
					SqlCmd.Parameters.Add("@Movimiento", SqlDbType.Int).Value = _Pagos[i].Item1;
					SqlParameter ParTotal = SqlCmd.Parameters.Add("@Pago", SqlDbType.Decimal);
					ParTotal.Precision = 15;
					ParTotal.Scale = 2;
					ParTotal.Value = _Pagos[i].Item2;
					result = SqlCmd.ExecuteNonQuery() == 1 ? "" : "Error al insertar pago (movID " + _Pagos[i].Item1 + ").";
					if (result != "")
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}

			return result;
		}

		private string ActualizarEstadoMovimientos()
		{
			string result = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();

				for (int i = 0; i < _Pagos.Count; i++)
				{
					string estado = "P";
					decimal pendiente = DFacturasProveedores.MontoPendiente(_Pagos[i].Item1);
					if (pendiente == 0m)
					{
						estado = "T";
					}

					SqlCommand SqlCmd = new SqlCommand();
					SqlCmd.Connection = SqlCon;
					SqlCmd.CommandText = "sp_ActualizarEstadoMovimiento";
					SqlCmd.CommandType = CommandType.StoredProcedure;

					SqlCmd.Parameters.Add("@Movimiento", SqlDbType.Int).Value = _Pagos[i].Item1;
					SqlCmd.Parameters.Add("@Estado", SqlDbType.VarChar, 7).Value = estado;

					int a = SqlCmd.ExecuteNonQuery();
					string b = _Pagos[i].Item1.ToString();
					result = a == 1 ? "" : ("Error al actualizar movimiento (movID " + b + ").");

					if (result != "")
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}

			return result;
		}
	}
}
