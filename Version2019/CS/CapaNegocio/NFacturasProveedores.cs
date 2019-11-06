using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using CapaDatos;

namespace CapaNegocio
{
	public class NFacturasProveedores
	{
		public static DataTable Listado(string TipoMov, string Codigo)
		{
			if (TipoMov == "FA")
			{
				if (Codigo == "")
				{
					return DFacturasProveedores.ListadoFacturas();
				}
				else
				{
					return DFacturasProveedores.ListadoFacturasPorCodigo(Codigo);
				}
			}
			else
			{
				if (Codigo == "")
				{
					return DFacturasProveedores.ListadoMovimientos(TipoMov);
				}
				else
				{
					return DFacturasProveedores.ListadoMovimientosPorCodigo(TipoMov, Codigo);
				}
			}
		}

		public static DataTable FacturaPorID(int id)
		{
			return DFacturasProveedores.FacturaPorID(id);
		}

		public static NegocioResult ValidarFactura(bool PermitirExistente,
			string TipoMovimiento,
			string CodigoProveedor, string TipoFactura, string Sucursal, string Documento,
			DateTime FechaFactura, DateTime FechaCarga, DateTime Vencimiento,
			decimal MontoNeto, decimal MontoExento,
			decimal PorcentajeIVA, decimal MontoIVA,
			decimal PorcentajePercepIVA, decimal MontoPercepIVA,
			bool IIBB,
			decimal Total,
			bool Material, string Provincia, string Actividad, string Despacho, string Observaciones,
			string TipoFacturaOriginal, string SucursalOriginal, string DocumentoOriginal)
		{
			NegocioResult result = new NegocioResult();

			if (!PermitirExistente)
			{
				if (ExisteFactura(TipoMovimiento, CodigoProveedor, TipoFactura, Sucursal, Documento))
				{
					result.AddError("El documento que intenta crear ya existe.");
				}
			}

			if (MontoNeto == 0 && MontoExento == 0)
			{
				result.AddError("El monto neto y el monto exento no pueden ser cero simultaneamente.");
			}

			if (MontoNeto == 0)
			{
				if (PorcentajeIVA != 0 || MontoIVA != 0 ||
					PorcentajePercepIVA != 0 || MontoPercepIVA != 0 || IIBB)
				{
					result.AddError("No puede haber impuestos si no hay un monto neto.");
				}
			}

			/*DateTime fechaCierreIvaCompras = //////////// traer de BD
			if (FechaCarga < fechaCierreIvaCompras)
			{
				result.AddError("La fecha de carga corresponde a un período cerrado.");
			}*/

			if (FechaCarga != FechaFactura)
			{
				if (FechaCarga < FechaFactura)
				{
					result.AddError("La fecha de carga no puede ser anterior a la fecha de la factura.");
				}
				if (FechaCarga.Day != 1)
				{
					result.AddError("La fecha de carga debe ser un 1° de mes.");
				}
				if (FechaCarga.Year == FechaFactura.Year)
				{
					if (FechaCarga.Month < FechaFactura.Month)
					{
						result.AddError("El més de la fecha de carga debe ser posterior al de la fecha de la factura.");
					}
				}
			}

			if (Vencimiento < FechaFactura)
			{
				result.AddError("La fecha de carga corresponde a un período cerrado.");
			}

			try
			{
				int codProveedor = Convert.ToInt32(CodigoProveedor);
				if (codProveedor >= 8000 && codProveedor <= 8590)
				{
					if (Despacho == "")
					{
						result.AddError("Para este proveedor debe introducir un despacho de importación.");
					}
				}
				else
				{
					if (Despacho != "")
					{
						result.AddError("Para este proveedor no puede introducir un despacho de importación.");
					}
				}
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
				result.AddError("Código de proveedor erróneo.");
			}

			if (MontoNeto != 0)
			{
				bool validIVA =
					(PorcentajeIVA >= 0.02m && PorcentajeIVA <= 0.03m) ||
					(PorcentajeIVA >= 0.10m && PorcentajeIVA <= 0.11m) ||
					(PorcentajeIVA >= 0.20m && PorcentajeIVA <= 0.22m) ||
					(PorcentajeIVA >= 0.26m && PorcentajeIVA <= 0.28m);

				if (!validIVA)
				{
					result.AddError("El porcentaje de IVA debe estar en el rango de 2-3%, 10-11%, 20-22% o 26-28%.");
				}
			}

			if (TipoMovimiento == "FA")
			{
				// validar que vengan vacios
				if (TipoFacturaOriginal != "" || SucursalOriginal != "" || DocumentoOriginal != "")
				{
					result.AddError("Las facturas no pueden estar relacionadas con una factura original.");
				}
			}
			else
			{
				// validar que exista la original
				if (!NFacturasProveedores.ExisteFactura("FA", CodigoProveedor, TipoFacturaOriginal, SucursalOriginal, DocumentoOriginal))
				{
					result.AddError("No se encontró la factura original '"
						+ TipoFacturaOriginal + " " + SucursalOriginal + "-" + DocumentoOriginal
						+ "' para el proveedor " + CodigoProveedor + ".");
				}
			}

			return result;
		}

		public static NegocioResult ValidarLineaLibroDiario(string cuenta, bool debe, decimal monto)
		{
			NegocioResult result = new NegocioResult();

			int len = cuenta.Length;
			if (len != 6)
			{
				result.AddError("La cuenta " + cuenta + " debe tener 6 dígitos.");
			}

			if (len >= 2 && cuenta[len - 1] == '0' && cuenta[len - 2] == '0')
			{
				result.AddError("La cuenta " + cuenta + " no es imputable (no puede terminar en 00).");
			}

			for (int i = 0; i < len; i++)
			{
				if (cuenta[i] < '0' || cuenta[i] > '9')
				{
					result.AddError("La cuenta " + cuenta + " es inválida, debe ser solo números.");
					break;
				}
			}

			if (monto <= 0)
			{
				result.AddError("El monto para la cuenta " + cuenta + " debe ser mayor a cero.");
			}

			return result;
		}

		public static NegocioResult ValidarAsiento(decimal totalFactura, decimal totalDebe, decimal totalHaber)
		{
			NegocioResult result = new NegocioResult();

			// Validar fecha? Moneda? Otra cosa?

			if (totalFactura != totalDebe || totalFactura != totalHaber)
			{
				result.AddError("Debe y Haber no están balanceados, o no coinciden con el total de la factura.");
			}

			return result;
		}

		public static NegocioResult InsertarFactura(string TipoMovimiento,
			string CodigoProveedor, string TipoDocumento, string Sucursal, string Documento,
			DateTime FechaFactura, DateTime FechaCarga, DateTime Vencimiento,
			decimal MontoNeto, decimal MontoExento,
			decimal PorcentajeIVA, decimal MontoIVA,
			decimal PorcentajePercepIVA, decimal MontoPercepIVA,
			bool IIBB,
			decimal Total,
			bool Material, string Provincia, string Actividad, string Despacho, string Observaciones,
			string TipoFacturaOrig, string SucursalOrig, string DocumentoOrig,
			string Asiento)
		{
			NegocioResult result = ValidarFactura(false, TipoMovimiento,
				CodigoProveedor, TipoDocumento, Sucursal, Documento,
				FechaFactura, FechaCarga, Vencimiento, MontoNeto, MontoExento,
				PorcentajeIVA, MontoIVA,
				PorcentajePercepIVA, MontoPercepIVA,
				IIBB,
				Total,
				Material, Provincia, Actividad, Despacho, Observaciones,
				TipoFacturaOrig, SucursalOrig, DocumentoOrig);

			if (result.IsOK)
			{
				DFacturasProveedores ObjFacturaProveedor = new DFacturasProveedores();
				ObjFacturaProveedor._TipoMovimiento = TipoMovimiento;
				ObjFacturaProveedor._CodigoProveedor = CodigoProveedor;
				ObjFacturaProveedor._TipoDocumento = TipoDocumento;
				ObjFacturaProveedor._Sucursal = Sucursal;
				ObjFacturaProveedor._Documento = Documento;
				ObjFacturaProveedor._FechaFactura = FechaFactura;
				ObjFacturaProveedor._FechaCarga = FechaCarga;
				ObjFacturaProveedor._Vencimiento = Vencimiento;
				ObjFacturaProveedor._MontoNeto = MontoNeto;
				ObjFacturaProveedor._MontoExento = MontoExento;
				ObjFacturaProveedor._PorcentajeIVA = PorcentajeIVA;
				ObjFacturaProveedor._MontoIVA = MontoIVA;
				ObjFacturaProveedor._PorcentajePercepcionIVA = PorcentajePercepIVA;
				ObjFacturaProveedor._MontoPercepcionIVA = MontoPercepIVA;
				ObjFacturaProveedor._Material = Material;
				ObjFacturaProveedor._Provincia = LetraDeProvincia(Provincia);
				ObjFacturaProveedor._Actividad = Actividad;
				ObjFacturaProveedor._Total = Total;
				ObjFacturaProveedor._Despacho = Despacho;
				ObjFacturaProveedor._Observaciones = Observaciones;
				ObjFacturaProveedor._TipoFacturaOrig = TipoFacturaOrig;
				ObjFacturaProveedor._SucursalOrig = SucursalOrig;
				ObjFacturaProveedor._DocumentoOrig = DocumentoOrig;
				ObjFacturaProveedor._Asiento = Asiento;
				ObjFacturaProveedor._Estado = "";

				String r = ObjFacturaProveedor.Insertar();
				if (r != "OK")
				{
					result.AddError(r);
				}
			}

			return result;
		}

		public static NegocioResult ActualizarFactura(
			int ID,
			string TipoMovimiento,
			string CodigoProveedor, string TipoDocumento, string Sucursal, string Documento,
			DateTime FechaFactura, DateTime FechaCarga, DateTime Vencimiento,
			decimal MontoNeto, decimal MontoExento,
			decimal PorcentajeIVA, decimal MontoIVA,
			decimal PorcentajePercepIVA, decimal MontoPercepIVA,
			bool IIBB,
			decimal Total,
			bool Material, string Provincia, string Actividad, string Despacho, string Observaciones,
			string TipoFacturaOrig, string SucursalOrig, string DocumentoOrig)
		{
			NegocioResult result = ValidarFactura(true,
				TipoFacturaOrig,
				CodigoProveedor, TipoDocumento, Sucursal, Documento,
				FechaFactura, FechaCarga, Vencimiento, MontoNeto, MontoExento,
				PorcentajeIVA, MontoIVA,
				PorcentajePercepIVA, MontoPercepIVA,
				IIBB,
				Total,
				Material, Provincia, Actividad, Despacho, Observaciones,
				TipoFacturaOrig, SucursalOrig, DocumentoOrig);

			if (result.IsOK)
			{
				DFacturasProveedores ObjFacturaProveedor = new DFacturasProveedores();
				ObjFacturaProveedor._ID = ID;
				ObjFacturaProveedor._TipoMovimiento = TipoMovimiento;
				ObjFacturaProveedor._CodigoProveedor = CodigoProveedor;
				ObjFacturaProveedor._TipoDocumento = TipoDocumento;
				ObjFacturaProveedor._Sucursal = Sucursal;
				ObjFacturaProveedor._Documento = Documento;
				ObjFacturaProveedor._FechaFactura = FechaFactura;
				ObjFacturaProveedor._FechaCarga = FechaCarga;
				ObjFacturaProveedor._Vencimiento = Vencimiento;
				ObjFacturaProveedor._MontoNeto = MontoNeto;
				ObjFacturaProveedor._MontoExento = MontoExento;
				ObjFacturaProveedor._PorcentajeIVA = PorcentajeIVA;
				ObjFacturaProveedor._MontoIVA = MontoIVA;
				ObjFacturaProveedor._PorcentajePercepcionIVA = PorcentajePercepIVA;
				ObjFacturaProveedor._MontoPercepcionIVA = MontoPercepIVA;
				ObjFacturaProveedor._Material = Material;
				ObjFacturaProveedor._Provincia = LetraDeProvincia(Provincia);
				ObjFacturaProveedor._Actividad = Actividad;
				ObjFacturaProveedor._Total = Total;
				ObjFacturaProveedor._Despacho = Despacho;
				ObjFacturaProveedor._Observaciones = Observaciones;
				ObjFacturaProveedor._TipoFacturaOrig = TipoFacturaOrig;
				ObjFacturaProveedor._SucursalOrig = SucursalOrig;
				ObjFacturaProveedor._DocumentoOrig = DocumentoOrig;

				String r = ObjFacturaProveedor.Actualizar();
				if (r != "OK")
				{
					result.AddError(r);
				}
			}

			return result;
		}

		public static bool ExisteFactura(string tipoMovimiento, string codigoProveedor, string tipoFactura, string sucursal, string documento)
		{
			return DFacturasProveedores.GetMovimientoID(tipoMovimiento, codigoProveedor, tipoFactura, sucursal, documento) >= 0;
		}

		public static int GetMovimientoID(string tipoMovimiento, string codigoProveedor, string tipoFactura, string sucursal, string documento)
		{
			return DFacturasProveedores.GetMovimientoID(tipoMovimiento, codigoProveedor, tipoFactura, sucursal, documento);
		}

		public static DataTable ListaProvincias()
		{
			return DFacturasProveedores.ListaProvincias();
		}

		public static string LetraDeProvincia(string nombre)
		{
			return DFacturasProveedores.LetraDeProvincia(nombre);
		}

		public static string ProvinciaPorLetra(string letra)
		{
			return DFacturasProveedores.ProvinciaPorLetra(letra);
		}

		public static DataTable ListaMonedas()
		{
			return DFacturasProveedores.ListaMonedas();
		}

		public static string GetCodigoMoneda(string nombre)
		{
			return DFacturasProveedores.GetCodigoMoneda(nombre);
		}

		public static string GetNombreMoneda(string codigo)
		{
			return DFacturasProveedores.GetNombreMoneda(codigo);
		}

		public static bool BorrarLineasAsiento(string asiento)
		{
			return DFacturasProveedores.BorrarLineasAsiento(asiento);
		}

		public static bool Eliminar(int id)
		{
			return DFacturasProveedores.Eliminar(id);
		}

		public static DataTable LineasAsiento(string asiento)
		{
			return DFacturasProveedores.LineasAsiento(asiento);
		}

		public static DataTable LineasIIBB(int movimientoID)
		{
			return DFacturasProveedores.LineasIIBB(movimientoID);
		}

		public static bool BorrarLineasIIBB(int movimientoID)
		{
			return DFacturasProveedores.BorrarLineasIIBB(movimientoID);
		}

		public static DataTable MovimientosAPagar(string proveedor, DateTime fechaIni, DateTime fechaFin)
		{
			return DFacturasProveedores.MovimientosAPagar(proveedor, fechaIni, fechaFin);
		}

		public static decimal MontoPendiente(int id)
		{
			return DFacturasProveedores.MontoPendiente(id);
		}
	}
}