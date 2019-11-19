using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

using CapaNegocio;

namespace CapaPresentacion
{
	public partial class FrmOrdenesPago : Form, IIBBCaller
	{
		bool mutex;

		bool arbaCheck;
		bool cabaCheck;
		int proveedorId;
		bool exento;

		List<LineaIIBB> lineasIIBB;

		decimal neto;
		decimal iibb;
		decimal porcentajeGanancias;
		decimal ganancias;
		decimal total;

		AutoCompleteStringCollection collectionProvincias;

		DataTable ListaProveedores;

		List<LineaOrdenPago> lineasMovimientosPendientes;

		public FrmOrdenesPago()
		{
			InitializeComponent();

			DtpFechaIni.Value = DateTime.Now.AddYears(-1);
			DtpFechaFin.Value = DateTime.Now.AddYears(1);

			lineasIIBB = new List<LineaIIBB>();

			lineasMovimientosPendientes = new List<LineaOrdenPago>();
			/*for (int i = 0; i < 5; i++)
			{
				LineaOrdenPago l = new LineaOrdenPago(this, i, "FA", "000123-00000678", "", "05-10-1983", "25-12-2020", "124.99");
				lineasMovimientosPendientes.Add(l);
			}*/

			ListaProveedores = NProveedores.ListaCodigoNombre();
			AutoCompleteStringCollection collectionCodigos = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaProveedores.Rows.Count; i++)
			{
				collectionCodigos.Add(ListaProveedores.Rows[i][0].ToString());
			}
			TxtCodigo.AutoCompleteCustomSource = collectionCodigos;
			TxtCodigoLista.AutoCompleteCustomSource = collectionCodigos;

			AutoCompleteStringCollection collectionNombres = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaProveedores.Rows.Count; i++)
			{
				collectionNombres.Add(ListaProveedores.Rows[i][1].ToString() + " [" + ListaProveedores.Rows[i][0].ToString() + "]");
			}
			TxtNombre.AutoCompleteCustomSource = collectionNombres;

			DataTable provincias = NFacturasProveedores.ListaProvincias();
			collectionProvincias = new AutoCompleteStringCollection();
			for (int i = 0; i < provincias.Rows.Count; i++)
			{
				collectionProvincias.Add(provincias.Rows[i][1].ToString());
			}

			mutex = false;
			arbaCheck = false;
			cabaCheck = false;
			exento = false;
		}

		public Panel Panel
		{
			get
			{
				return PnlPendientes;
			}
		}

		private void TxtCodigo_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;

				LblPadronARBA.Text = "---";
				LblPadronCABA.Text = "---";

				TxtNombre.Text = "";
				for (int i = 0; i < ListaProveedores.Rows.Count; i++)
				{
					if (ListaProveedores.Rows[i][0].ToString() == TxtCodigo.Text)
					{
						TxtNombre.Text = ListaProveedores.Rows[i][1].ToString();
						break;
					}
				}
				mutex = false;
			}
		}

		private void TextBoxSelectAll(object sender, EventArgs e)
		{
			Tools.TextBoxSelectAll(sender, e);
		}

		private void TxtCodigo_Leave(object sender, EventArgs e)
		{
			TxtCodigo.Text = TxtCodigo.Text.PadLeft(4, '0');
			CheckProveedor();
		}

		private void TxtNombre_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;

				LblPadronARBA.Text = "---";
				LblPadronCABA.Text = "---";

				BtnGuardar.Enabled = false;

				TxtCodigo.Text = "";
				if (TxtNombre.Text.Length > 7)
				{
					String suffix = TxtNombre.Text.Substring(TxtNombre.Text.Length - 7);
					String pattern = @"^ \[\d{4}\]$";
					if (Regex.Match(suffix, pattern).Success)
					{
						String number = suffix.Substring(2, 4);
						TxtCodigo.Text = number;
					}
				}
				mutex = false;
			}
		}

		private void TxtNombre_Leave(object sender, EventArgs e)
		{
			CheckProveedor();
		}

		private void CheckProveedor()
		{
			proveedorId = NProveedores.ObtenerId(TxtCodigo.Text);

			NegocioResult arba = NProveedores.ValidarPadronARBA(TxtCodigo.Text);
			arbaCheck = arba.IsOK;
			LblPadronARBA.Text = arbaCheck ? "OK" : arba.GetMessage();


			NegocioResult caba = NProveedores.ValidarPadronCABA(TxtCodigo.Text);
			cabaCheck = caba.IsOK;
			LblPadronCABA.Text = cabaCheck ? "OK" : caba.GetMessage();

			exento = NProveedores.EsExento(TxtCodigo.Text);

			if (exento)
			{
				TxtMontoIIBB.Text = "0.00";
				TxtMontoIIBB.Enabled = false;
				TxtPorcentajeGanancias.Text = "0.00";
				TxtPorcentajeGanancias.Enabled = false;
				TxtMontoGanancias.Text = "0.00";
				TxtMontoGanancias.Enabled = false;
			}
			else
			{
				TxtMontoIIBB.Enabled = true;
				TxtPorcentajeGanancias.Enabled = true;
				TxtMontoGanancias.Enabled = true;
			}
		}

		private void CleanListaMovimientos()
		{
			for (int i = 0; i < lineasMovimientosPendientes.Count; i++)
			{
				lineasMovimientosPendientes[i].RemoveFromContainer();
			}
			lineasMovimientosPendientes.Clear();
		}

		private void BtnActualizar_Click(object sender, EventArgs e)
		{
			CleanListaMovimientos();

			DataTable pendientes = NFacturasProveedores.MovimientosAPagar(TxtCodigo.Text, DtpFechaIni.Value, DtpFechaFin.Value);

			for (int i = 0; i < pendientes.Rows.Count; i++)
			{
				decimal monto = Convert.ToDecimal(pendientes.Rows[i]["Total"]);
				if (pendientes.Rows[i]["Estado"].ToString() == "P")
				{
					monto = NFacturasProveedores.MontoPendiente(Convert.ToInt32(pendientes.Rows[i]["ID"]));
				}

				LineaOrdenPago l = new LineaOrdenPago(this, i,
					Convert.ToInt32(pendientes.Rows[i]["ID"]),
					pendientes.Rows[i]["Tipo"].ToString(),
					pendientes.Rows[i]["Documento"].ToString(),
					pendientes.Rows[i]["Contradocumento"].ToString(),
					((DateTime)pendientes.Rows[i]["Fecha"]).ToString("yyyy-MM-dd"),
					((DateTime)pendientes.Rows[i]["Vencimiento"]).ToString("yyyy-MM-dd"),
					monto.ToString("N2", CultureInfo.InvariantCulture),
					Convert.ToDecimal(pendientes.Rows[i]["NetoOriginal"]),
					pendientes.Rows[i]["Estado"].ToString() == "P");
				lineasMovimientosPendientes.Add(l);
			}

			lineasIIBB.Clear();
			if (!exento)
			{
				if (arbaCheck)
				{
					decimal arbaPorc = NProveedores.AlicuotaIIBB_ARBA(TxtCodigo.Text) / 100;
					decimal arbaMonto = neto * arbaPorc;
					lineasIIBB.Add(new LineaIIBB("Buenos Aires", arbaPorc, 0));
				}
				if (cabaCheck)
				{
					decimal cabaPorc = NProveedores.AlicuotaIIBB_CABA(TxtCodigo.Text) / 100;
					decimal cabaMonto = neto * cabaPorc;
					lineasIIBB.Add(new LineaIIBB("Capital Federal", cabaPorc, 0));
				}
			}
			ActualizarImpuestos();

			BtnGuardar.Enabled = true;
		}

		public void ActualizarNeto()
		{
			neto = 0;
			for (int i = 0; i < lineasMovimientosPendientes.Count; i++)
			{
				neto += lineasMovimientosPendientes[i].GetNeto();
			}

			ActualizarImpuestos();

			ActualizarTotal();
		}

		public void ActualizarImpuestos()
		{
			iibb = 0;
			for (int i = 0; i < lineasIIBB.Count; i++)
			{
				lineasIIBB[i].Monto = lineasIIBB[i].Porcentaje * neto;
				iibb += lineasIIBB[i].Monto;
			}
			Tools.TwoDecimalsNumberInTextBox(iibb, TxtMontoIIBB);

			ganancias = neto * porcentajeGanancias;
			Tools.TwoDecimalsNumberInTextBox(ganancias, TxtMontoGanancias);
		}

		public void ActualizarTotal()
		{
			total = neto - iibb - ganancias;
			string strTotal = total.ToString("N2", CultureInfo.InvariantCulture);
			int right = LblTotal.Left + LblTotal.Width;
			LblTotal.Text = "Total: $" + strTotal;
			LblTotal.Left = right - LblTotal.Width;
		}

		private void BtnGuardar_Click(object sender, EventArgs e)
		{
			DateTime fecha = DateTime.Today;
			List<Tuple<int, decimal>> pagos = new List<Tuple<int, decimal>>();

			for (int i = 0; i < lineasMovimientosPendientes.Count; i++)
			{
				if (lineasMovimientosPendientes[i].pago != 0m)
				{
					pagos.Add(new Tuple<int, decimal>(
						lineasMovimientosPendientes[i].movimiento,
						lineasMovimientosPendientes[i].pago));
				}
			}

			NegocioResult r = NOrdenesPago.Validar(fecha, pagos);

			if (exento && (iibb != 0 || ganancias != 0))
			{
				r.AddError("El proveedor es exento. Los impuestos deben ser cero.");
			}

			if (r.IsOK)
			{
				//r = NOrdenesPago.Guardar(fecha, porcentajeIibb, iibb, porcentajeGanancias, ganancias, pagos);
				r = NOrdenesPago.Guardar(proveedorId, fecha, 0, porcentajeGanancias, ganancias, pagos);
			}

			// Guardar IIBB
			if (r.IsOK)
			{
				//int opID = NOrdenesPago.GetOrdenPagoID(tipoMovimiento, txtCodigo.Text, cbbTipoFactura.SelectedItem.ToString(), txtSucursal.Text, txtDocumento.Text.ToUpper());
				for (int i = 0; i < lineasIIBB.Count; i++)
				{
					/*r.AddResult(NLineaIIBB.InsertarLinea(
						"OP", opID, lineasIIBB[i].Linea, NFacturasProveedores.LetraDeProvincia(lineasIIBB[i].Provincia),
						lineasIIBB[i].Porcentaje, lineasIIBB[i].Monto));*/

					if (!r.IsOK)
					{
						r.AddError("Error al intentar guardar la linea " + lineasIIBB[i].Linea + " de IIBB (" + lineasIIBB[i].Provincia + ").");
						break;
					}
				}
			}

			if (r.IsOK)
			{
				MessageBox.Show(r.GetMessage(), "Guardar");
			}
			else
			{
				MessageBox.Show(r.GetMessage(), "Error al guardar orden de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			BtnActualizar_Click(null, null);
		}

		private void BtnIIBB_Click(object sender, EventArgs e)
		{
			FrmIIBB frmiibb = new FrmIIBB(this, collectionProvincias);
			frmiibb.SetLineas(lineasIIBB);
			frmiibb.ShowDialog();
		}

		public decimal GetMontoNeto()
		{
			return neto;
		}

		public void SetLineasIIBB(List<LineaIIBB> lineas)
		{
			iibb = 0;
			lineasIIBB = lineas;
			for (int i = 0; i < lineasIIBB.Count; i++)
			{
				iibb += lineasIIBB[i].Monto;
			}
			Tools.TwoDecimalsNumberInTextBox(iibb, TxtMontoIIBB);
			ActualizarTotal();
		}

		private void btnTodo_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < lineasMovimientosPendientes.Count; i++)
			{
				lineasMovimientosPendientes[i].PagarTodo();
			}

			ActualizarNeto();

			ActualizarImpuestos();

			ActualizarTotal();
		}
	}
}
