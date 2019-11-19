using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

using CapaNegocio;

namespace CapaPresentacion
{
	public partial class FrmFacturasProveedores : Form, IIBBCaller
	{
		decimal MontoNeto;
		decimal MontoExento;
		decimal PorcentajeIVA;
		decimal MontoIVA;
		decimal PorcentajePercepcionIVA;
		decimal MontoPercepcionIVA;
		decimal MontoIIBB;
		decimal MontoTotal;

		DataTable ListaProveedores;

		bool mutex;
		bool modified;
		bool editMode;
		int movimientoID;
		string editAsiento;

		string tipoMovimiento;

		// Libro Diario

		decimal Debe;
		decimal Haber;

		List<LineaLibroDiario> LineasAsiento;
		List<LineaIIBB> LineasIIBB;

		AutoCompleteStringCollection collectionCuenta;
		AutoCompleteStringCollection collectionDescripcion;
		AutoCompleteStringCollection collectionProvincias;

		DataTable ListaProvincias;

		public decimal GetMontoNeto()
		{
			return MontoNeto;
		}

		public FrmFacturasProveedores(string tipo)
		{
			InitializeComponent();

			tipoMovimiento = tipo;
			if (tipoMovimiento == "CR" || tipoMovimiento == "DB")
			{
				if (tipoMovimiento == "CR")
				{
					tabFactura.Text = "Nota Crédito";
					LblDocumento.Text = "Nota de Crédito";
					this.Text = "Notas de Crédito de Proveedores";
				}
				else
				{
					tabFactura.Text = "Nota Débito";
					LblDocumento.Text = "Nota de Débito";
					this.Text = "Notas de Débito de Proveedores";
				}
				LblTitle.Text = this.Text;
				LblFacturaOriginal.Visible = true;
				CbbTipoFacturaOriginal.Visible = true;
				TxtSucursalOriginal.Visible = true;
				TxtDocumentoOriginal.Visible = true;
			}
			else
			{
				tipoMovimiento = "FA";
				LblFacturaOriginal.Visible = false;
				CbbTipoFacturaOriginal.Visible = false;
				TxtSucursalOriginal.Visible = false;
				TxtDocumentoOriginal.Visible = false;
			}

			this.Left = 0;
			this.Top = 0;

			editMode = false;
			modified = false;

			LineasIIBB = new List<LineaIIBB>();

			ListaProveedores = NProveedores.ListaCodigoNombre();
			AutoCompleteStringCollection collectionCodigos = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaProveedores.Rows.Count; i++)
			{
				collectionCodigos.Add(ListaProveedores.Rows[i][0].ToString());
			}
			txtCodigo.AutoCompleteCustomSource = collectionCodigos;
			TxtCodigoLista.AutoCompleteCustomSource = collectionCodigos;

			AutoCompleteStringCollection collectionNombres = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaProveedores.Rows.Count; i++)
			{
				collectionNombres.Add(ListaProveedores.Rows[i][1].ToString() + " [" + ListaProveedores.Rows[i][0].ToString() + "]");
			}
			txtNombre.AutoCompleteCustomSource = collectionNombres;

			ListaProvincias = NFacturasProveedores.ListaProvincias();
			collectionProvincias = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaProvincias.Rows.Count; i++)
			{
				collectionProvincias.Add(ListaProvincias.Rows[i][1].ToString());
			}
			txtProvincia.AutoCompleteCustomSource = collectionProvincias;

			DataTable ListaMonedas = NFacturasProveedores.ListaMonedas();
			for (int i = 0; i < ListaMonedas.Rows.Count; i++)
			{
				CbbMoneda.Items.Add(ListaMonedas.Rows[i][0].ToString());
			}
			CbbMoneda.SelectedIndex = 0;

			// Libro Diario
			LineasAsiento = new List<LineaLibroDiario>();

			DataTable ListaCuentas = NCuentas.ListaCuentaDescripcion();
			collectionCuenta = new AutoCompleteStringCollection();
			collectionDescripcion = new AutoCompleteStringCollection();
			for (int i = 0; i < ListaCuentas.Rows.Count; i++)
			{
				collectionCuenta.Add(ListaCuentas.Rows[i][0].ToString());
				collectionDescripcion.Add(ListaCuentas.Rows[i][1].ToString());
			}

			Debe = 0;
			Haber = 0;

			CleanForm();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			txtCodigo.Enabled = true;
			txtNombre.Enabled = true;
			cbbTipoFactura.Enabled = true;
			txtSucursal.Enabled = true;
			txtDocumento.Enabled = true;

			dtpFechaFactura.Enabled = true;
			dtpVencimiento.Enabled = true;
			dtpCarga.Enabled = true;

			txtNeto.Enabled = true;
			txtExento.Enabled = true;
			txtPorcentajeIVA.Enabled = true;
			txtMontoIVA.Enabled = true;
			txtPorcentajePercepIVA.Enabled = true;
			txtMontoPercepIVA.Enabled = true;

			chkMaterial.Enabled = true;
			txtProvincia.Enabled = true;
			cbbActividad.Enabled = true;

			txtTotal.Enabled = true;
			txtObservaciones.Enabled = true;

			CbbTipoFacturaOriginal.Enabled = true;
			TxtSucursalOriginal.Enabled = true;
			TxtDocumentoOriginal.Enabled = true;

			BtnAsientos.Enabled = true;

			DtpAsiento.Enabled = true;
			TxtObservacionesLD.Enabled = true;
			CbbMoneda.Enabled = true;
			btnAgregarAsiento.Enabled = true;

			BtnGuardar.Enabled = true;

			editMode = false;
			modified = false;

			btnNuevo.Enabled = false;
			BtnEditar.Enabled = false;
			btnCancelar.Enabled = true;
			btnEliminar.Enabled = false;

			tabFacturaAsientos.SelectedIndex = 1;
		}

		private void BtnEditar_Click(object sender, EventArgs e)
		{
			int idx = DgvListado.CurrentCell.RowIndex;
			String estado = Convert.ToString(DgvListado.Rows[idx].Cells[5].Value);

			if (estado == "T" || estado == "P")
			{
				MessageBox.Show("No se puede editar una factura que ya tiene pagos asociados.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else if (estado == "Anulada")
			{
				MessageBox.Show("No se puede editar una factura anulada.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else
			{
				movimientoID = Convert.ToInt32(DgvListado.Rows[idx].Cells[0].Value);
				DataTable Factura = NFacturasProveedores.FacturaPorID(movimientoID);

				editAsiento = Factura.Rows[0]["Asiento"].ToString();
				
				// Cargar IIBB de la factura original.
				LineasIIBB.Clear();
				DataTable lineasIIBB = NFacturasProveedores.LineasIIBB(tipoMovimiento, movimientoID);
				for (int i = 0; i < lineasIIBB.Rows.Count; i++)
				{
					AgregarLineaIIBB(
						NFacturasProveedores.ProvinciaPorLetra(lineasIIBB.Rows[i]["Provincia"].ToString()),
						Convert.ToDecimal(lineasIIBB.Rows[i]["Porcentaje"]),
						Convert.ToDecimal(lineasIIBB.Rows[i]["Monto"]));
				}

				// Cargar lineas de libro diario.
				foreach (LineaLibroDiario l in this.LineasAsiento)
				{
					l.RemoveFromContainer();
				}
				LineasAsiento.Clear();

				DataTable lineasAsiento = NFacturasProveedores.LineasAsiento(editAsiento);
				for (int i = 0; i < lineasAsiento.Rows.Count; i++)
				{
					if (i == 0)
					{
						DtpAsiento.Text = lineasAsiento.Rows[i]["Fecha"].ToString();
						TxtObservacionesLD.Text = lineasAsiento.Rows[i]["Observaciones"].ToString();
						CbbMoneda.Text = NFacturasProveedores.GetNombreMoneda(lineasAsiento.Rows[i]["Moneda"].ToString());
					}

					AgregarLineaAsiento(
						lineasAsiento.Rows[i]["Cuenta"].ToString(),
						lineasAsiento.Rows[i]["Tipo"].ToString() == "D",
						Convert.ToDecimal(lineasAsiento.Rows[i]["Importe"]));
				}
				ActualizarPosiciones();

				txtCodigo.Enabled = true;
				txtCodigo.Text = Factura.Rows[0]["Proveedor"].ToString();
				txtNombre.Enabled = true;
				cbbTipoFactura.Enabled = true;
				cbbTipoFactura.Text = Factura.Rows[0]["TipoDocumento"].ToString();
				txtSucursal.Enabled = true;
				txtSucursal.Text = Factura.Rows[0]["Sucursal"].ToString();
				txtDocumento.Enabled = true;
				txtDocumento.Text = Factura.Rows[0]["Documento"].ToString();

				dtpFechaFactura.Enabled = true;
				dtpFechaFactura.Text = Factura.Rows[0]["Fecha"].ToString();
				dtpVencimiento.Enabled = true;
				dtpVencimiento.Text = Factura.Rows[0]["Vencimiento"].ToString();
				dtpCarga.Enabled = true;
				dtpCarga.Text = Factura.Rows[0]["FechaCarga"].ToString();

				txtNeto.Enabled = true;
				txtNeto.Text = Convert.ToString(Factura.Rows[0]["MontoNeto"], CultureInfo.InvariantCulture);
				txtExento.Enabled = true;
				txtExento.Text = Convert.ToString(Factura.Rows[0]["MontoExento"], CultureInfo.InvariantCulture);
				txtPorcentajeIVA.Enabled = true;
				txtPorcentajeIVA.Text = Convert.ToString(Factura.Rows[0]["PorcentajeIVA"], CultureInfo.InvariantCulture);
				txtMontoIVA.Enabled = true;
				txtMontoIVA.Text = Convert.ToString(Factura.Rows[0]["MontoIVA"], CultureInfo.InvariantCulture);
				txtPorcentajePercepIVA.Enabled = true;
				txtPorcentajePercepIVA.Text = Convert.ToString(Factura.Rows[0]["PorcentajePercepIVA"], CultureInfo.InvariantCulture);
				txtMontoPercepIVA.Enabled = true;
				txtMontoPercepIVA.Text = Convert.ToString(Factura.Rows[0]["MontoPercepIVA"], CultureInfo.InvariantCulture);

				chkMaterial.Enabled = true;
				chkMaterial.Checked = Convert.ToBoolean(Factura.Rows[0]["Material"]);
				txtProvincia.Enabled = true;
				txtProvincia.Text = NFacturasProveedores.ProvinciaPorLetra(Factura.Rows[0]["Provincia"].ToString());
				cbbActividad.Enabled = true;
				cbbActividad.Text = Factura.Rows[0]["Actividad"].ToString();

				txtTotal.Enabled = true;
				txtTotal.Text = Convert.ToString(Factura.Rows[0]["Total"], CultureInfo.InvariantCulture);
				txtObservaciones.Enabled = true;
				txtObservaciones.Text = Factura.Rows[0]["Observaciones"].ToString();

				CbbTipoFacturaOriginal.Enabled = true;
				CbbTipoFacturaOriginal.Text = Factura.Rows[0]["TipoFacturaOrig"].ToString();
				TxtSucursalOriginal.Enabled = true;
				TxtSucursalOriginal.Text = Factura.Rows[0]["SucursalOrig"].ToString();
				TxtDocumentoOriginal.Enabled = true;
				TxtDocumentoOriginal.Text = Factura.Rows[0]["DocumentoOrig"].ToString();

				txtDespacho.Text = Factura.Rows[0]["Despacho"].ToString();
				CheckProveedor();

				BtnAsientos.Enabled = true;

				DtpAsiento.Enabled = true;
				TxtObservacionesLD.Enabled = true;
				CbbMoneda.Enabled = true;
				btnAgregarAsiento.Enabled = true;

				BtnGuardar.Enabled = true;

				editMode = true;
				modified = false;

				btnNuevo.Enabled = false;
				BtnEditar.Enabled = false;
				btnCancelar.Enabled = true;
				btnEliminar.Enabled = false;

				tabFacturaAsientos.SelectedIndex = 1;
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			bool proceed = true;
			if (modified)
			{
				proceed = MessageBox.Show("Se perderán los cambios. ¿Desea continuar?", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
			}

			if (proceed)
			{
				CleanForm();
			}
		}

		private void CleanForm()
		{
			txtCodigo.Text = "";
			txtCodigo.Enabled = false;
			txtNombre.Text = "";
			txtNombre.Enabled = false;
			cbbTipoFactura.SelectedIndex = 0;
			cbbTipoFactura.Enabled = false;
			txtSucursal.Text = "";
			txtSucursal.Enabled = false;
			txtDocumento.Text = "";
			txtDocumento.Enabled = false;


			dtpFechaFactura.Value = DateTime.Today;
			dtpFechaFactura.Enabled = false;
			dtpCarga.Value = DateTime.Today;
			dtpVencimiento.Enabled = false;
			dtpVencimiento.Value = DateTime.Today.AddDays(45);
			dtpCarga.Enabled = false;

			MontoNeto = 0;
			MontoExento = 0;
			PorcentajeIVA = 0;
			PorcentajePercepcionIVA = 0;
			MontoIVA = 0;
			MontoPercepcionIVA = 0;
			MontoIIBB = 0;
			MontoTotal = 0;

			mutex = true;
			TwoDecimalsNumberInTextBox(MontoNeto, txtNeto);
			TwoDecimalsNumberInTextBox(MontoExento, txtExento);
			TwoDecimalsNumberInTextBox(PorcentajeIVA * 100, txtPorcentajeIVA);
			TwoDecimalsNumberInTextBox(MontoIVA, txtMontoIVA);
			TwoDecimalsNumberInTextBox(PorcentajePercepcionIVA * 100, txtPorcentajePercepIVA);
			TwoDecimalsNumberInTextBox(MontoPercepcionIVA, txtMontoPercepIVA);
			TwoDecimalsNumberInTextBox(MontoIIBB, txtMontoIIBB);
			TwoDecimalsNumberInTextBox(MontoTotal, txtTotal);
			mutex = false;

			txtNeto.Enabled = false;
			txtExento.Enabled = false;
			txtPorcentajeIVA.Enabled = false;
			txtMontoIVA.Enabled = false;
			txtPorcentajePercepIVA.Enabled = false;
			txtMontoPercepIVA.Enabled = false;
			txtMontoIIBB.Enabled = false;
			txtTotal.Enabled = false;

			chkMaterial.Checked = false;
			chkMaterial.Enabled = false;

			txtProvincia.Text = "";
			txtProvincia.Enabled = false;

			cbbActividad.SelectedIndex = 0;
			cbbActividad.Enabled = false;

			txtObservaciones.Enabled = false;

			CbbTipoFacturaOriginal.SelectedIndex = 0;
			cbbTipoFactura.Enabled = false;
			TxtSucursalOriginal.Text = "";
			TxtSucursalOriginal.Enabled = false;
			TxtDocumentoOriginal.Text = "";
			TxtDocumentoOriginal.Enabled = false;

			BtnAsientos.Enabled = false;

			LineasIIBB.Clear();

			// Limpiar libro diario
			DtpAsiento.Value = DateTime.Today;
			DtpAsiento.Enabled = false;
			TxtObservacionesLD.Text = "";
			TxtObservacionesLD.Enabled = false;
			CbbMoneda.SelectedIndex = 0;
			CbbMoneda.Enabled = false;
			btnAgregarAsiento.Enabled = false;

			foreach (LineaLibroDiario l in LineasAsiento)
			{
				l.RemoveFromContainer();
			}
			LineasAsiento.Clear();
			ActualizarPosiciones();
			ActualizarTotales();

			BtnGuardar.Enabled = false;

			// Tab Listado
			DgvListado.DataSource = NFacturasProveedores.Listado(tipoMovimiento, "");
			tabFacturaAsientos.SelectedIndex = 0;

			// Botonoes principales
			btnNuevo.Enabled = true;
			BtnEditar.Enabled = true;
			btnCancelar.Enabled = false;
			btnEliminar.Enabled = true;
		}

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				txtNombre.Text = "";

				for (int i = 0; i < ListaProveedores.Rows.Count; i++)
				{
					if (ListaProveedores.Rows[i][0].ToString() == txtCodigo.Text)
					{
						txtNombre.Text = ListaProveedores.Rows[i][1].ToString();
						//txtNombre.Text = ListaProveedores.Rows[i][1].ToString() + " [" + ListaProveedores.Rows[i][0].ToString() + "]";
						break;
					}
				}
				mutex = false;
			}
		}

		private void txtCodigo_Leave(object sender, EventArgs e)
		{
			txtCodigo.Text = txtCodigo.Text.PadLeft(4, '0');
			CheckProveedor();
		}

		private void txtNombre_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				txtCodigo.Text = "";

				if (txtNombre.Text.Length > 7)
				{
					String suffix = txtNombre.Text.Substring(txtNombre.Text.Length - 7);
					String pattern = @"^ \[\d{4}\]$";
					if (Regex.Match(suffix, pattern).Success)
					{
						String number = suffix.Substring(2, 4);
						txtCodigo.Text = number;
					}
				}
				mutex = false;
			}
		}

		private void txtNombre_Leave(object sender, EventArgs e)
		{
			CheckProveedor();
		}

		private void CheckProveedor()
		{
			// Despacho Importacion
			bool conDespacho = false;
			try
			{
				int cod = Convert.ToInt32(txtCodigo.Text);
				if (cod >= 8000 && cod <= 8590)
				{
					conDespacho = true;
				}
			}
			catch (Exception ex)
			{
				string a = ex.ToString();
			}
			if (conDespacho)
			{
				txtDespacho.Enabled = true;
			}
			else
			{
				txtDespacho.Text = "";
				txtDespacho.Enabled = false;
			}

			// Condición de IVA
			string CondicionIVA = NProveedores.CondicionIVA(txtCodigo.Text);
			switch (CondicionIVA)
			{
				case "I":
					cbbTipoFactura.SelectedIndex = 0;
					txtPorcentajeIVA.Text = "21";
					txtPorcentajeIVA_Leave(null, null);
					break;
				case "N":
				case "E":
				case "M":
					cbbTipoFactura.SelectedIndex = 2;
					txtPorcentajeIVA.Text = "0";
					txtPorcentajeIVA_Leave(null, null);
					break;
				case "X":
					cbbTipoFactura.SelectedIndex = 3;
					txtPorcentajeIVA.Text = "0";
					txtPorcentajeIVA_Leave(null, null);
					break;
				default:
					break;
			}
		}

		private void txtNeto_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				MontoNeto = TextboxToDecimal(txtNeto, false);
				MontoIVA = Math.Round(MontoNeto * PorcentajeIVA, 2);
				TwoDecimalsNumberInTextBox(MontoIVA, txtMontoIVA);
				MontoPercepcionIVA = Math.Round(MontoNeto * PorcentajePercepcionIVA, 2);
				TwoDecimalsNumberInTextBox(MontoPercepcionIVA, txtMontoPercepIVA);
				MontoIIBB = 0;
				for(int i = 0; i < LineasIIBB.Count; i++)
				{
					LineasIIBB[i].Recalculate(MontoNeto);
					MontoIIBB += LineasIIBB[i].Monto;
				}
				TwoDecimalsNumberInTextBox(MontoIIBB, txtMontoIIBB);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtNeto_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(MontoNeto, txtNeto);
		}

		private void txtExento_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				MontoExento = TextboxToDecimal(txtExento, false);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtExento_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(MontoExento, txtExento);
		}

		private void txtSucursal_Leave(object sender, EventArgs e)
		{
			txtSucursal.Text = txtSucursal.Text.PadLeft(5, '0');
		}

		private void txtDocumento_Leave(object sender, EventArgs e)
		{
			txtDocumento.Text = txtDocumento.Text.PadLeft(8, '0').ToUpper();
		}

		private void TxtSucursalOriginal_Leave(object sender, EventArgs e)
		{
			TxtSucursalOriginal.Text = TxtSucursalOriginal.Text.PadLeft(5, '0');
		}

		private void TxtDocumentoOriginal_Leave(object sender, EventArgs e)
		{
			TxtDocumentoOriginal.Text = TxtDocumentoOriginal.Text.PadLeft(8, '0').ToUpper();
		}

		private void BtnAsientos_Click(object sender, EventArgs e)
		{
			bool proceed = true;
			if (LineasAsiento.Count > 0)
			{
				DialogResult dr = MessageBox.Show("¿Desea eliminar los datos del asiento existente y volver a generarlos?", "Regenerar Asiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
				{
					proceed = false;
				}
			}

			if (proceed)
			{
				NegocioResult result = NFacturasProveedores.ValidarFactura(editMode,
						tipoMovimiento,
						txtCodigo.Text,
						cbbTipoFactura.SelectedItem.ToString(),
						txtSucursal.Text, txtDocumento.Text,
						dtpFechaFactura.Value, dtpCarga.Value, dtpVencimiento.Value,
						MontoNeto, MontoExento,
						PorcentajeIVA, MontoIVA,
						PorcentajePercepcionIVA, MontoPercepcionIVA,
						LineasIIBB.Count > 0,
						MontoTotal,
						chkMaterial.Checked,
						txtProvincia.Text,
						cbbActividad.Text,
						txtDespacho.Text,
						txtObservaciones.Text,
						tipoMovimiento != "FA" ? CbbTipoFacturaOriginal.SelectedItem.ToString() : "",
						TxtSucursalOriginal.Text, TxtDocumentoOriginal.Text);

				if (result.IsOK)
				{
					// Observaciones
					if (txtObservaciones.Text != "")
					{
						TxtObservacionesLD.Text = txtObservaciones.Text;
					}
					else
					{
						string description = "";
						if (txtNombre.Text.Length >= 7)
						{
							string suffix = txtNombre.Text.Substring(txtNombre.Text.Length - 7);
							string pattern = @"^ \[\d{4}\]$";
							if (Regex.Match(suffix, pattern).Success)
							{
								description = txtNombre.Text;
							}
						}

						if (description == "")
						{
							description = txtNombre.Text + " [" + txtCodigo.Text + "]";
						}

						description += " FA " + cbbTipoFactura.SelectedText + " " + txtSucursal.Text + "-" + txtDocumento.Text;

						// Recortar
						if (description.Length > 50)
						{
							description = description.Substring(0, 50);
						}

						TxtObservacionesLD.Text = description;
					}

					// Borrar lineas existentes si las hubiese
					foreach (LineaLibroDiario l in LineasAsiento)
					{
						l.RemoveFromContainer();
					}
					LineasAsiento.Clear();

					// Generar lineas con los datos de la factura
					AgregarLineaAsiento("", true, MontoNeto + MontoExento);
					if (MontoIVA > 0)
					{
						AgregarLineaAsiento("120201", true, MontoIVA);
					}
					if (MontoPercepcionIVA > 0)
					{
						AgregarLineaAsiento("120228", true, MontoPercepcionIVA);
					}
					for (int i = 0; i < LineasIIBB.Count; i++)
					{
						AgregarLineaAsiento(CuentaIIBB(LineasIIBB[i].Provincia), true, LineasIIBB[i].Monto);
					}
					AgregarLineaAsiento("310101", false, MontoNeto + MontoExento + MontoIVA + MontoPercepcionIVA + MontoIIBB);

					ActualizarPosiciones();
					tabFacturaAsientos.SelectedIndex = 2;
				}
				else
				{
					String mensaje = "Por favor corrija los siguientes errores antes de continuar:";
					for (int i = 0; i < result.errorMsgs.Count; i++)
					{
						mensaje += "\r\n - " + result.errorMsgs[i];
					}
					MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private String CuentaIIBB(String provincia)
		{
			String cuenta = "";
			foreach (DataRow r in ListaProvincias.Rows)
			{
				if (r[1].ToString().ToUpper() == provincia.ToUpper())
				{
					cuenta = r[2].ToString();
					break;
				}
			}
			return cuenta;
		}

		private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
		{
			dtpVencimiento.Value = dtpFechaFactura.Value.AddDays(45);
		}

		private void txtPorcentajeIVA_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				PorcentajeIVA = TextboxToDecimal(txtPorcentajeIVA, true);
				MontoIVA = Math.Round(MontoNeto * PorcentajeIVA, 2);
				TwoDecimalsNumberInTextBox(MontoIVA, txtMontoIVA);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtPorcentajeIVA_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(PorcentajeIVA * 100, txtPorcentajeIVA);
		}

		private void txtMontoIVA_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				MontoIVA = TextboxToDecimal(txtMontoIVA, false);
				if (MontoNeto != 0)
				{
					PorcentajeIVA = Math.Round(MontoIVA / MontoNeto, 4);
				}
				else
				{
					PorcentajeIVA = 0;
				}
				TwoDecimalsNumberInTextBox(PorcentajeIVA * 100, txtPorcentajeIVA);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtMontoIVA_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(MontoIVA, txtMontoIVA);
		}

		private void txtPorcentajePercepIVA_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				PorcentajePercepcionIVA = TextboxToDecimal(txtPorcentajePercepIVA, true);
				MontoPercepcionIVA = Math.Round(MontoNeto * PorcentajePercepcionIVA, 2);
				TwoDecimalsNumberInTextBox(MontoPercepcionIVA, txtMontoPercepIVA);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtPorcentajePercepIVA_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(PorcentajePercepcionIVA * 100, txtPorcentajePercepIVA);
		}

		private void txtMontoPercepIVA_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				MontoPercepcionIVA = TextboxToDecimal(txtMontoPercepIVA, false);
				if (MontoNeto != 0)
				{
					PorcentajePercepcionIVA = Math.Round(MontoPercepcionIVA / MontoNeto, 4);
				}
				else
				{
					PorcentajePercepcionIVA = 0;
				}
				TwoDecimalsNumberInTextBox(PorcentajePercepcionIVA * 100, txtPorcentajePercepIVA);
				UpdateTotal();
				mutex = false;
			}
		}

		private void txtMontoPercepIVA_Leave(object sender, EventArgs e)
		{
			TwoDecimalsNumberInTextBox(MontoPercepcionIVA, txtMontoPercepIVA);
		}

		public void SetLineasIIBB(List<LineaIIBB> lineasIIBB)
		{
			MontoIIBB = 0;
			LineasIIBB = lineasIIBB;
			for(int i = 0; i < LineasIIBB.Count; i++)
			{
				MontoIIBB += LineasIIBB[i].Monto;
			}
			TwoDecimalsNumberInTextBox(MontoIIBB, txtMontoIIBB);
			UpdateTotal();
		}

		private void txtProvincia_Leave(object sender, EventArgs e)
		{
			foreach (String str in txtProvincia.AutoCompleteCustomSource)
			{
				if (str.ToUpper() == txtProvincia.Text.ToUpper())
				{
					txtProvincia.Text = str;
					break;
				}
			}
		}

		private void UpdateTotal()
		{
			MontoTotal = MontoNeto + MontoExento + MontoIVA + MontoPercepcionIVA + MontoIIBB;
			TwoDecimalsNumberInTextBox(MontoTotal, txtTotal);
		}

		public decimal TextboxToDecimal(TextBox Txt, bool Percent)
		{
			decimal value = 0;
			try
			{
				value = Convert.ToDecimal(Txt.Text, CultureInfo.InvariantCulture);
				if (Percent)
				{
					value = value / 100;
				}
				Txt.BackColor = SystemColors.Window;
			}
			catch (FormatException ex)
			{
				string a = ex.ToString();
				Txt.BackColor = Color.LightPink;
			}
			return value;
		}

		public void TextBoxSelectAll(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void TextboxToUpper(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			txt.Text = txt.Text.ToUpper();
		}

		public void TwoDecimalsNumberInTextBox(decimal value, TextBox txt)
		{
			string str = value.ToString("N2", CultureInfo.InvariantCulture);
			txt.Text = str;
		}

		private void FindFacturaProveedor()
		{
			String codigo = txtCodigo.Text;
			String tipo = cbbTipoFactura.Text;
			String sucursal = txtSucursal.Text;
			String documento = txtDocumento.Text;

			if (codigo != "" && sucursal != "" && documento != "")
			{
				if (editMode)
				{

				}
				else
				{
					if (NFacturasProveedores.ExisteFactura(tipoMovimiento, codigo, tipo, sucursal, documento))
					{
						MessageBox.Show("El documento que intenta crear ya existe.");
					}
				}
			}
		}

		public Panel PanelLibroDiario
		{
			get { return PnlLineas; }
		}

		// Libro Diario

		public void AgregarLineaAsiento(String Cuenta, bool Debe, decimal Monto)
		{
			LineaLibroDiario l = new LineaLibroDiario(Cuenta, Debe, Monto, this, LineasAsiento.Count, collectionCuenta, collectionDescripcion);
			LineasAsiento.Add(l);
			ActualizarTotales();
		}

		public void ActualizarPosiciones()
		{
			PnlLineas.Width = tabFacturaAsientos.ClientSize.Width - 45;
			PnlLineas.Height = tabFacturaAsientos.ClientSize.Height - 175;

			LblTituloDebe.Left = PnlLineas.Width - 285;
			LblTituloHaber.Left = PnlLineas.Width - 160;

			//BtnAsientos.Left = tabFacturaAsientos.ClientSize.Width - 105;
			//BtnAsientos.Top = tabFacturaAsientos.ClientSize.Height - 75;

			LblTotalDebe.Left = PnlLineas.Left + PnlLineas.Width - 170 - LblTotalDebe.Width;
			LblTotalDebe.Top = PnlLineas.Top + PnlLineas.Height + 10;

			LblTotalHaber.Left = PnlLineas.Left + PnlLineas.Width - 45 - LblTotalHaber.Width;
			LblTotalHaber.Top = PnlLineas.Top + PnlLineas.Height + 10;

			btnAgregarAsiento.Top = (LineasAsiento.Count + 1) * 30 - 2;

			foreach (LineaLibroDiario l in LineasAsiento)
			{
				l.ActualizarPosiciones(PnlLineas.Width);
			}

			LblTituloDescripcion.Left = 85;
		}

		public void ActualizarTotales()
		{
			Debe = 0;
			Haber = 0;
			foreach (LineaLibroDiario l in LineasAsiento)
			{
				if (l.EsDebe())
				{
					Debe += l.GetMonto();
				}
				else
				{
					Haber += l.GetMonto();
				}

			}
			LblTotalDebe.Text = "$ " + Debe.ToString("N2");
			LblTotalHaber.Text = "$ " + Haber.ToString("N2");
		}

		private void btnAgregarAsiento_Click(object sender, EventArgs e)
		{
			AgregarLineaAsiento("", true, 0);
			ActualizarPosiciones();
			PnlLineas.VerticalScroll.Value = PnlLineas.VerticalScroll.Maximum;
			LineasAsiento[LineasAsiento.Count - 1].Focus();
		}

		public void EliminarLinea(int idx)
		{
			LineasAsiento.RemoveAt(idx);
			for (int i = 0; i < LineasAsiento.Count; i++)
			{
				LineasAsiento[i].SetIndex(i);
			}
			ActualizarPosiciones();
			ActualizarTotales();
		}

		public void AgregarLineaIIBB(String Provincia, decimal Porcentaje, decimal Monto)
		{
			LineaIIBB l = new LineaIIBB(Provincia, Porcentaje, Monto);
			LineasIIBB.Add(l);
		}

		private void BtnGuardar_Click(object sender, EventArgs e)
		{
			NegocioResult result = new NegocioResult();

			// Validar
			result.AddResult(NFacturasProveedores.ValidarFactura(editMode,
					tipoMovimiento,
					txtCodigo.Text,
					cbbTipoFactura.SelectedItem.ToString(),
					txtSucursal.Text, txtDocumento.Text.ToUpper(),
					dtpFechaFactura.Value, dtpCarga.Value, dtpVencimiento.Value,
					MontoNeto, MontoExento,
					PorcentajeIVA, MontoIVA,
					PorcentajePercepcionIVA, MontoPercepcionIVA,
					LineasIIBB.Count > 0,
					MontoTotal,
					chkMaterial.Checked,
					txtProvincia.Text,
					cbbActividad.Text,
					txtDespacho.Text.ToUpper(),
					txtObservaciones.Text.ToUpper(),
					tipoMovimiento != "FA" ? CbbTipoFacturaOriginal.SelectedItem.ToString() : "",
					TxtSucursalOriginal.Text,
					TxtDocumentoOriginal.Text));

			for (int i = 0; i < LineasAsiento.Count; i++)
			{
				result.AddResult(NFacturasProveedores.ValidarLineaLibroDiario(
					LineasAsiento[i].Cuenta, LineasAsiento[i].EsDebe(), LineasAsiento[i].GetMonto()));
			}

			result.AddResult(NFacturasProveedores.ValidarAsiento(MontoTotal, Debe, Haber));

			string Asiento = "";
			if (editMode)
			{
				// Se conserva nro de asiento de la factura original.
				Asiento = editAsiento;
			}
			else
			{
				Asiento = NLibroDiario.ObtenerProximoAsientoLibre();
				if (Asiento == "")
				{
					result.AddError("No se pudo obtener el próximo número de asiento.");
				}
			}

			string Moneda = "";
			Moneda = NFacturasProveedores.GetCodigoMoneda(CbbMoneda.Text);
			if (Moneda == "")
			{
				result.AddError("No se pudo obtener el código de la moneda \"" + CbbMoneda.Text + "\".");
			}

			if (editMode)
			{
				// Updatear factura existente

				// Borrar lineas de asiento actual.
				if (result.IsOK)
				{
					if (!NFacturasProveedores.BorrarLineasAsiento(Asiento))
					{
						result.AddError("Error al eliminar asiento anterior.");
					}
				}

				// Borrar lineas IIBB actuales.
				if (result.IsOK)
				{
					if (!NFacturasProveedores.BorrarLineasIIBB("FA", movimientoID))
					{
						result.AddError("Error al eliminar IIBB anteriores.");
					}
				}

				if (result.IsOK)
				{
					// Actualizar registro de factura
					result.AddResult(NFacturasProveedores.ActualizarFactura(
						movimientoID,
						tipoMovimiento,
						txtCodigo.Text,
						cbbTipoFactura.SelectedItem.ToString(),
						txtSucursal.Text, txtDocumento.Text.ToUpper(),
						dtpFechaFactura.Value, dtpCarga.Value, dtpVencimiento.Value,
						MontoNeto, MontoExento,
						PorcentajeIVA, MontoIVA,
						PorcentajePercepcionIVA, MontoPercepcionIVA,
						LineasIIBB.Count > 0,
						MontoTotal,
						chkMaterial.Checked,
						txtProvincia.Text,
						cbbActividad.Text,
						txtDespacho.Text.ToUpper(),
						txtObservaciones.Text.ToUpper(),
						tipoMovimiento != "FA" ? CbbTipoFacturaOriginal.SelectedItem.ToString() : "",
						TxtSucursalOriginal.Text,
						TxtDocumentoOriginal.Text));
				}
			}
			else
			{
				// Guardar factura nueva

				if (result.IsOK)
				{
					result.AddResult(NFacturasProveedores.InsertarFactura(
						tipoMovimiento,
						txtCodigo.Text,
						cbbTipoFactura.SelectedItem.ToString(),
						txtSucursal.Text, txtDocumento.Text.ToUpper(),
						dtpFechaFactura.Value, dtpCarga.Value, dtpVencimiento.Value,
						MontoNeto, MontoExento,
						PorcentajeIVA, MontoIVA,
						PorcentajePercepcionIVA, MontoPercepcionIVA,
						LineasIIBB.Count > 0,
						MontoTotal,
						chkMaterial.Checked,
						txtProvincia.Text,
						cbbActividad.Text,
						txtDespacho.Text.ToUpper(),
						txtObservaciones.Text.ToUpper(),
						tipoMovimiento != "FA" ? CbbTipoFacturaOriginal.SelectedItem.ToString() : "",
						TxtSucursalOriginal.Text, TxtDocumentoOriginal.Text,
						Asiento));
				}

				movimientoID = NFacturasProveedores.GetMovimientoID(tipoMovimiento, txtCodigo.Text, cbbTipoFactura.SelectedItem.ToString(), txtSucursal.Text, txtDocumento.Text.ToUpper());
			}

			// Guardar IIBB
			if (result.IsOK)
			{
				for (int i = 0; i < LineasIIBB.Count; i++)
				{
					result.AddResult(NLineaIIBB.InsertarLinea(
						"FA", movimientoID, LineasIIBB[i].Linea, NFacturasProveedores.LetraDeProvincia(LineasIIBB[i].Provincia),
						LineasIIBB[i].Porcentaje, LineasIIBB[i].Monto));

					if (!result.IsOK)
					{
						result.AddError("Error al intentar guardar la linea " + LineasIIBB[i].Linea + " de IIBB (" + LineasIIBB[i].Provincia + ").");
						break;
					}
				}
			}

			// Guardar asiento
			if (result.IsOK)
			{
				for (int i = 0; i < LineasAsiento.Count; i++)
				{
					result.AddResult(NLibroDiario.InsertarLinea(
						Asiento, LineasAsiento[i].NroLinea, LineasAsiento[i].Cuenta, DtpAsiento.Value, LineasAsiento[i].EsDebe() ? "D" : "H",
						LineasAsiento[i].GetMonto(), tipoMovimiento, cbbTipoFactura.Text, Moneda, TxtObservacionesLD.Text.ToUpper(), 3));

					if (!result.IsOK)
					{
						result.AddError("Error al intentar guardar la linea " + i + " del asiento (" + LineasAsiento[i].Cuenta + ").");
						break;
					}
				}
			}

			// Mostrar resultado
			if (result.IsOK)
			{
				CleanForm();
				if (editMode)
				{
					MessageBox.Show("El asiento " + Asiento + " y la factura han sido actualizados.", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.None);
				}
				else
				{
					MessageBox.Show("Se ha generado el asiento " + Asiento + ".", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.None);
				}
			}
			else
			{
				MessageBox.Show(result.GetMessage(), "Error al Guardar la Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Eliminar
		private void btnEliminar_Click(object sender, EventArgs e)
		{
			int idx = DgvListado.CurrentCell.RowIndex;
			string estado = Convert.ToString(DgvListado.Rows[idx].Cells[5].Value);

			if (estado == "T" || estado == "P")
			{
				MessageBox.Show("No se puede eliminar una factura que ya tiene pagos asociados.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else if (estado == "Anulada")
			{
				MessageBox.Show("No se puede eliminar una factura anulada.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			else
			{
				DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					int id = Convert.ToInt32(DgvListado.Rows[idx].Cells[0].Value);
					bool exito = NFacturasProveedores.Eliminar(id);
					if (exito)
					{
						MessageBox.Show("La factura ha sido anulada.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						DgvListado.DataSource = NFacturasProveedores.Listado(tipoMovimiento, TxtCodigoLista.Text);
					}
					else
					{
						MessageBox.Show("Error al intentar eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					}
				}
			}
		}

		private void TxtCodigoLista_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnRefresh_Click(null, null);
			}
		}

		private void BtnRefresh_Click(object sender, EventArgs e)
		{
			DgvListado.DataSource = NFacturasProveedores.Listado(tipoMovimiento, TxtCodigoLista.Text);
		}

		private void BtnIIBB_Click(object sender, EventArgs e)
		{
			FrmIIBB iibb = new FrmIIBB(this, collectionProvincias);
			iibb.SetLineas(LineasIIBB);
			iibb.ShowDialog();
		}
	}
}