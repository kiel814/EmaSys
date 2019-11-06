using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class NLibroDiario
    {
        public static String ObtenerProximoAsientoLibre()
        {
            return DLibroDiario.ObtenerAsientoLibre();
        }

        public static NegocioResult InsertarLinea(String Asiento, String Linea, String Cuenta,
			DateTime Fecha, String Tipo, Decimal Importe,
			String TipoMovimiento, String TipoDocumento,
			String Moneda, String ObsAsiento, int Empleado)
        {
			DLibroDiario linea = new DLibroDiario();
			linea._Asiento = Asiento;
			linea._Linea = Linea;
			linea._Cuenta = Cuenta;
			linea._Fecha = Fecha;
			linea._Tipo = Tipo;
			linea._Importe = Importe;
			linea._TipoMovimiento = TipoMovimiento;
			linea._TipoDocumento = TipoDocumento;
			linea._Moneda = Moneda;
			linea._Observaciones = ObsAsiento;
			linea._EmpleadoID = Empleado;
			linea._Estado = "Emitido";

			NegocioResult resultado = new NegocioResult();

			String r = linea.Insertar();
			if (r != "OK")
			{
				resultado.AddError(r);
			}

			return resultado;
        }
    }
}