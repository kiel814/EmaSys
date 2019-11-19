using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
	public class NOrdenesPago
	{
		public static NegocioResult Validar(DateTime fecha, List<Tuple<int, decimal>> pagos)
		{
			NegocioResult result = new NegocioResult();

			// validar fecha???

			if (pagos.Count <= 0)
			{
				result.AddError("La orden debe tener al menos un pago.");
			}

			return result;
		}

		public static NegocioResult Guardar(int proveedor, DateTime fecha, decimal montoIIBB, decimal porcGan, decimal monGan, List<Tuple<int, decimal>> pagos)
		{
			NegocioResult result = new NegocioResult();

			DOrdenesPago orden = new DOrdenesPago();
			orden._Proveedor = proveedor;
			orden._Fecha = fecha;
			orden._MontoIIBB = montoIIBB;
			orden._PorcentajeGanancias = porcGan;
			orden._MontoGanancias = monGan;
			orden._Pagos = pagos;
			orden._Estado = "";

			string datosResult = orden.Guardar();
			if(datosResult != "")
			{
				result.AddError(datosResult);
			}
			else
			{
				result.successMsg = "Se ha generado la orden de pago " + orden._ID + ".";
			}

			return result;
		}
	}
}
