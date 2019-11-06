using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
	public class NLineaIIBB
	{
		public static NegocioResult InsertarLinea(int Movimiento, int Linea, string Provincia, decimal Porcentaje, decimal Monto)
		{
			DLineaIIBB linea = new DLineaIIBB();
			linea._Movimiento = Movimiento;
			linea._Linea = Linea;
			linea._Provincia = Provincia;
			linea._Porcentaje = Porcentaje;
			linea._Monto = Monto;

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