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
		public int _ID;
		public string _TipoMovimiento;
		public string _CodigoProveedor;
		public string _TipoDocumento;
		public string _Sucursal;
		public string _Documento;
		public DateTime _FechaFactura;
		public DateTime _FechaCarga;
		public DateTime _Vencimiento;
		public decimal _MontoNeto;
		public decimal _MontoExento;
		public decimal _PorcentajeIVA;
		public decimal _MontoIVA;
		public decimal _PorcentajePercepcionIVA;
		public decimal _MontoPercepcionIVA;
		public decimal _Total;
		public bool _Material;
		public string _Provincia;
		public string _Actividad;
		public string _Despacho;
		public string _Observaciones;
		public string _TipoFacturaOrig;
		public string _SucursalOrig;
		public string _DocumentoOrig;
		public string _Asiento;
		public string _Estado;

		public DFacturasProveedores()
		{
		}

		public static DataTable ListadoFacturas()
		{
			DataTable DtResultado = new DataTable("FacturasProveedores");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListadoFacturasProveedores";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
		}

		public static DataTable ListadoFacturasPorCodigo(string Codigo)
		{
			DataTable DtResultado = new DataTable("FacturasProveedores");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListadoFacturasProveedoresPorCodigo";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = Codigo;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
		}

		public static DataTable ListadoMovimientos(string TipoMov)
		{
			DataTable DtResultado = new DataTable("MovimientosProveedores");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListadoMovimientosProveedores";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@TipoMov", SqlDbType.VarChar, 2).Value = TipoMov;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
		}

		public static DataTable ListadoMovimientosPorCodigo(string TipoMov, string Codigo)
		{
			DataTable DtResultado = new DataTable("MovimientosProveedores");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListadoMovimientosProveedoresPorCodigo";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@TipoMov", SqlDbType.VarChar, 2).Value = TipoMov;
				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 4).Value = Codigo;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
		}

		public static DataTable FacturaPorID(int id)
		{
			DataTable DtResultado = new DataTable("FacturaPorID");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_FacturaProveedorPorID";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
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
				SqlCmd.CommandText = "sp_InsertarMovimientoProveedor";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParID = new SqlParameter();
				ParID.ParameterName = "@ID";
				ParID.SqlDbType = SqlDbType.Int;
				ParID.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParID);

				SqlCmd.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 2).Value = _TipoMovimiento;
				SqlCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar, 4).Value = _CodigoProveedor;
				SqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 1).Value = _TipoDocumento;
				SqlCmd.Parameters.Add("@Sucursal", SqlDbType.VarChar, 5).Value = _Sucursal;
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
				ParPorcIVA.Scale = 4;
				ParPorcIVA.Value = _PorcentajeIVA;
				SqlParameter ParMontoIVA = SqlCmd.Parameters.Add("@MontoIVA", SqlDbType.Decimal);
				ParMontoIVA.Precision = 15;
				ParMontoIVA.Scale = 2;
				ParMontoIVA.Value = _MontoIVA;
				SqlParameter ParPorcPercepcion = SqlCmd.Parameters.Add("@PorcentajePercepIVA", SqlDbType.Decimal);
				ParPorcPercepcion.Precision = 5;
				ParPorcPercepcion.Scale = 4;
				ParPorcPercepcion.Value = _PorcentajePercepcionIVA;
				SqlParameter ParMontoPercepcion = SqlCmd.Parameters.Add("@MontoPercepIVA", SqlDbType.Decimal);
				ParMontoPercepcion.Precision = 15;
				ParMontoPercepcion.Scale = 2;
				ParMontoPercepcion.Value = _MontoPercepcionIVA;
				SqlCmd.Parameters.Add("@Material", SqlDbType.Bit).Value = _Material;
				SqlCmd.Parameters.Add("@Provincia", SqlDbType.VarChar, 1).Value = _Provincia;
				SqlCmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 1).Value = _Actividad;
				SqlParameter ParTotal = SqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
				ParTotal.Precision = 15;
				ParTotal.Scale = 2;
				ParTotal.Value = _Total;
				SqlCmd.Parameters.Add("@Despacho", SqlDbType.VarChar, 50).Value = _Despacho;
				SqlCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = _Observaciones;
				SqlCmd.Parameters.Add("@TipoFacturaOrig", SqlDbType.VarChar, 1).Value = _TipoFacturaOrig;
				SqlCmd.Parameters.Add("@SucursalOrig", SqlDbType.VarChar, 5).Value = _SucursalOrig;
				SqlCmd.Parameters.Add("@DocumentoOrig", SqlDbType.VarChar, 8).Value = _DocumentoOrig;
				SqlCmd.Parameters.Add("@Asiento", SqlDbType.VarChar, 6).Value = _Asiento;
				SqlCmd.Parameters.Add("@Estado", SqlDbType.VarChar, 7).Value = _Estado;

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

		public string Actualizar()
		{
			String Respuesta = "";
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ActualizarMovimientoProveedor";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = _ID;
				SqlCmd.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 2).Value = _TipoMovimiento;
				SqlCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar, 4).Value = _CodigoProveedor;
				SqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 1).Value = _TipoDocumento;
				SqlCmd.Parameters.Add("@Sucursal", SqlDbType.VarChar, 5).Value = _Sucursal;
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
				ParPorcIVA.Scale = 4;
				ParPorcIVA.Value = _PorcentajeIVA;
				SqlParameter ParMontoIVA = SqlCmd.Parameters.Add("@MontoIVA", SqlDbType.Decimal);
				ParMontoIVA.Precision = 15;
				ParMontoIVA.Scale = 2;
				ParMontoIVA.Value = _MontoIVA;
				SqlParameter ParPorcPercepcion = SqlCmd.Parameters.Add("@PorcentajePercepIVA", SqlDbType.Decimal);
				ParPorcPercepcion.Precision = 5;
				ParPorcPercepcion.Scale = 4;
				ParPorcPercepcion.Value = _PorcentajePercepcionIVA;
				SqlParameter ParMontoPercepcion = SqlCmd.Parameters.Add("@MontoPercepIVA", SqlDbType.Decimal);
				ParMontoPercepcion.Precision = 15;
				ParMontoPercepcion.Scale = 2;
				ParMontoPercepcion.Value = _MontoPercepcionIVA;
				SqlCmd.Parameters.Add("@Material", SqlDbType.Bit).Value = _Material;
				SqlCmd.Parameters.Add("@Provincia", SqlDbType.VarChar, 1).Value = _Provincia;
				SqlCmd.Parameters.Add("@Actividad", SqlDbType.VarChar, 1).Value = _Actividad;
				SqlParameter ParTotal = SqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
				ParTotal.Precision = 15;
				ParTotal.Scale = 2;
				ParTotal.Value = _Total;
				SqlCmd.Parameters.Add("@Despacho", SqlDbType.VarChar, 50).Value = _Despacho;
				SqlCmd.Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = _Observaciones;
				SqlCmd.Parameters.Add("@TipoFacturaOrig", SqlDbType.VarChar, 1).Value = _TipoFacturaOrig;
				SqlCmd.Parameters.Add("@SucursalOrig", SqlDbType.VarChar, 5).Value = _SucursalOrig;
				SqlCmd.Parameters.Add("@DocumentoOrig", SqlDbType.VarChar, 8).Value = _DocumentoOrig;

				Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Error al actualizar";
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

		public static int GetMovimientoID(string tipoMovimiento, string codigoProveedor, string tipoDocumento, string sucursal, string documento)
		{
			int id = -1;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_GetMovimientoID";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParExiste = new SqlParameter();
				ParExiste.ParameterName = "@ID";
				ParExiste.SqlDbType = SqlDbType.Int;
				ParExiste.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParExiste);

				SqlCmd.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 2).Value = tipoMovimiento;
				SqlCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar, 4).Value = codigoProveedor;
				SqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 1).Value = tipoDocumento;
				SqlCmd.Parameters.Add("@Sucursal", SqlDbType.VarChar, 5).Value = sucursal;
				SqlCmd.Parameters.Add("@Documento", SqlDbType.VarChar, 8).Value = documento;

				// Ejecutar SP y convertir respuesta en bool
				SqlCmd.ExecuteScalar();
				id = Convert.ToInt32(ParExiste.Value);
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return id;
		}

		public static DataTable ListaProvincias()
		{
			DataTable DtResultado = new DataTable("ListaProvincias");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListaProvincias";
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

		public static string LetraDeProvincia(string nombre)
		{
			string letra = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_LetraDeProvincia";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParLetra = new SqlParameter();
				ParLetra.ParameterName = "@Letra";
				ParLetra.SqlDbType = SqlDbType.VarChar;
				ParLetra.Size = 1;
				ParLetra.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParLetra);

				SqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 25).Value = nombre;

				SqlCmd.ExecuteScalar();

				if (ParLetra != null)
				{
					letra = (string)ParLetra.Value;
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
			return letra;
		}

		public static string ProvinciaPorLetra(string letra)
		{
			string provincia = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ProvinciaPorLetra";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParProvincia = new SqlParameter();
				ParProvincia.ParameterName = "@Provincia";
				ParProvincia.SqlDbType = SqlDbType.VarChar;
				ParProvincia.Size = 25;
				ParProvincia.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParProvincia);

				SqlCmd.Parameters.Add("@Letra", SqlDbType.VarChar, 1).Value = letra;

				SqlCmd.ExecuteScalar();

				if (ParProvincia != null)
				{
					provincia = (string)ParProvincia.Value;
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
			return provincia;
		}

		public static DataTable ListaMonedas()
		{
			DataTable DtResultado = new DataTable("ListaMonedas");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListaMonedas";
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

		public static string GetCodigoMoneda(string nombre)
		{
			string codigo = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_CodigoMoneda";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParCodigo = new SqlParameter();
				ParCodigo.ParameterName = "@Codigo";
				ParCodigo.SqlDbType = SqlDbType.VarChar;
				ParCodigo.Size = 3;
				ParCodigo.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParCodigo);

				SqlCmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 25).Value = nombre;

				SqlCmd.ExecuteScalar();

				if (ParCodigo != null)
				{
					codigo = (string)ParCodigo.Value;
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
			return codigo;
		}

		public static string GetNombreMoneda(string codigo)
		{
			string nombre = "";

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_NombreMoneda";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlParameter ParNombre = new SqlParameter();
				ParNombre.ParameterName = "@Nombre";
				ParNombre.SqlDbType = SqlDbType.VarChar;
				ParNombre.Size = 25;
				ParNombre.Direction = ParameterDirection.Output;
				SqlCmd.Parameters.Add(ParNombre);

				SqlCmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 3).Value = codigo;

				SqlCmd.ExecuteScalar();

				if (ParNombre != null)
				{
					nombre = (string)ParNombre.Value;
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
			return nombre;
		}

		public static bool BorrarLineasAsiento(string asiento)
		{
			bool exito = false;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_BorrarLineasAsiento";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Asiento", SqlDbType.VarChar, 6).Value = asiento;

				int result = SqlCmd.ExecuteNonQuery();
				exito = true;
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return exito;
		}

		public static bool BorrarLineasIIBB(string docType, int docId)
		{
			bool exito = false;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_BorrarLineasIIBB";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@DocType", SqlDbType.VarChar, 2).Value = docType;
				SqlCmd.Parameters.Add("@DocId", SqlDbType.Int).Value = docId;

				int result = SqlCmd.ExecuteNonQuery();
				exito = true;
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return exito;
		}

		public static bool Eliminar(int id)
		{
			bool exito = false;

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_EliminarFacturaProveedor";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

				int result = SqlCmd.ExecuteNonQuery();
				exito = true;
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return exito;
		}

		public static DataTable LineasAsiento(string asiento)
		{
			DataTable DtResultado = new DataTable("LineasAsiento");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListaLineasAsiento";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Asiento", SqlDbType.VarChar, 6).Value = asiento;

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

		public static DataTable LineasIIBB(int movimientoID)
		{
			DataTable DtResultado = new DataTable("LineasIIBB");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_ListaLineasIIBB";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Movimiento", SqlDbType.Int).Value = movimientoID;

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

		public static DataTable MovimientosAPagar(string proveedor, DateTime fechaIni, DateTime fechaFin)
		{
			DataTable DtResultado = new DataTable("APagar");
			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_FacturasPendientesDePago";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@Proveedor", SqlDbType.VarChar, 4).Value = proveedor;
				SqlCmd.Parameters.Add("@FechaIni", SqlDbType.DateTime).Value = fechaIni;
				SqlCmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = fechaFin;

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);
			}
			catch (Exception ex)
			{
				String a = ex.ToString();
				DtResultado = null;
			}
			return DtResultado;
		}

		public static decimal MontoPendiente(int id)
		{
			decimal pendiente = 0;
			DataTable DtResultado = new DataTable("resultado");

			SqlConnection SqlCon = new SqlConnection();
			try
			{
				SqlCon.ConnectionString = Conexion.Cn;
				SqlCon.Open();
				SqlCommand SqlCmd = new SqlCommand();
				SqlCmd.Connection = SqlCon;
				SqlCmd.CommandText = "sp_MontoPendiente";
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

				SqlParameter ParPendiente = new SqlParameter("@Pendiente", SqlDbType.Decimal, 15);
				ParPendiente.Direction = ParameterDirection.Output;
				ParPendiente.Precision = 15;
				ParPendiente.Scale = 2;
				SqlCmd.Parameters.Add(ParPendiente);

				SqlCmd.ExecuteNonQuery();

				SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
				SqlDat.Fill(DtResultado);

				pendiente = Convert.ToDecimal(DtResultado.Rows[0][0]);
			}
			catch (Exception ex)
			{
				string a = ex.Message;
			}
			finally
			{
				if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
			}
			return pendiente;
		}
	}
}