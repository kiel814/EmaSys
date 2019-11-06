using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CapaPresentacion
{
	class LineaLibroDiario
	{
		FrmFacturasProveedores parent;

		TextBox TxtCuenta;
		TextBox TxtDescripcion;
		TextBox TxtDebe;
		TextBox TxtHaber;
		Button BtnEliminar;
		AutoCompleteStringCollection ListaCuentas;
		AutoCompleteStringCollection ListaDescripciones;
		bool Debe;
		decimal Monto;

		int index;

		bool changing;

		bool mutex;

		public LineaLibroDiario(String Cuenta, bool _Debe, decimal _Monto, FrmFacturasProveedores form, int idx, AutoCompleteStringCollection AutocompleteCuenta, AutoCompleteStringCollection AutocompleteDescripcion)
		{
			parent = form;

			index = idx;

			mutex = false;

			Debe = _Debe;
			Monto = _Monto;
			ListaCuentas = AutocompleteCuenta;
			ListaDescripciones = AutocompleteDescripcion;

			TxtCuenta = new TextBox();
			TxtCuenta.Left = 10;
			TxtCuenta.Top = 30 * (index + 1);
			TxtCuenta.Width = 65;
			TxtCuenta.TextAlign = HorizontalAlignment.Center;
			TxtCuenta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			TxtCuenta.AutoCompleteSource = AutoCompleteSource.CustomSource;
			TxtCuenta.AutoCompleteCustomSource = AutocompleteCuenta;
			TxtCuenta.TextChanged += new System.EventHandler(this.TxtCuenta_TextChanged);
			TxtCuenta.Click += new System.EventHandler(parent.TextBoxSelectAll);
			TxtCuenta.Enter += new System.EventHandler(parent.TextBoxSelectAll);

			TxtDescripcion = new TextBox();
			TxtDescripcion.Left = TxtCuenta.Left + TxtCuenta.Width + 10;
			TxtDescripcion.Top = TxtCuenta.Top;
			TxtDescripcion.Width = 80;
			TxtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			TxtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;
			TxtDescripcion.AutoCompleteCustomSource = AutocompleteDescripcion;
			TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
			TxtDescripcion.Click += new System.EventHandler(parent.TextBoxSelectAll);
			TxtDescripcion.Enter += new System.EventHandler(parent.TextBoxSelectAll);

			// Esto hay que hacerlo despues de crear TxtDescription.
			// Si no, no puede autocompletar (y explota porque es null).
			TxtCuenta.Text = Cuenta;

			changing = true;

			TxtDebe = new TextBox();
			TxtDebe.Text = Debe ? Monto.ToString("N2", CultureInfo.InvariantCulture) : "";
			TxtDebe.Left = TxtDescripcion.Left + TxtDescripcion.Width + 10;
			TxtDebe.Top = TxtCuenta.Top;
			TxtDebe.Width = 115;
			TxtDebe.TextAlign = HorizontalAlignment.Right;
			TxtDebe.TextChanged += new System.EventHandler(this.TxtDebe_TextChanged);
			TxtDebe.Leave += new System.EventHandler(this.TxtDebe_Leave);
			TxtDebe.Click += new System.EventHandler(parent.TextBoxSelectAll);
			TxtDebe.Enter += new System.EventHandler(parent.TextBoxSelectAll);

			TxtHaber = new TextBox();
			TxtHaber.Text = Debe ? "" : Monto.ToString("N2", CultureInfo.InvariantCulture);
			TxtHaber.Left = TxtDebe.Left + TxtDebe.Width + 10;
			TxtHaber.Top = TxtCuenta.Top;
			TxtHaber.Width = 115;
			TxtHaber.TextAlign = HorizontalAlignment.Right;
			TxtHaber.TextChanged += new System.EventHandler(this.TxtHaber_TextChanged);
			TxtHaber.Leave += new System.EventHandler(this.TxtHaber_Leave);
			TxtHaber.Click += new System.EventHandler(parent.TextBoxSelectAll);
			TxtHaber.Enter += new System.EventHandler(parent.TextBoxSelectAll);

			BtnEliminar = new Button();
			BtnEliminar.Text = "X";
			BtnEliminar.Width = 25;
			BtnEliminar.Left = TxtHaber.Left + TxtHaber.Width + 10;
			BtnEliminar.Top = TxtHaber.Top - 2;
			BtnEliminar.Click += new System.EventHandler(this.BtnX_Click);

			parent.PanelLibroDiario.Controls.Add(TxtCuenta);
			parent.PanelLibroDiario.Controls.Add(TxtDescripcion);
			parent.PanelLibroDiario.Controls.Add(TxtDebe);
			parent.PanelLibroDiario.Controls.Add(TxtHaber);
			parent.PanelLibroDiario.Controls.Add(BtnEliminar);

			changing = false;
		}

		public void RemoveFromContainer()
		{
			parent.PanelLibroDiario.Controls.Remove(TxtCuenta);
			parent.PanelLibroDiario.Controls.Remove(TxtDescripcion);
			parent.PanelLibroDiario.Controls.Remove(TxtDebe);
			parent.PanelLibroDiario.Controls.Remove(TxtHaber);
			parent.PanelLibroDiario.Controls.Remove(BtnEliminar);
		}

		private void TxtDescripcion_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				TxtCuenta.Text = "";
				for (int i = 0; i < ListaDescripciones.Count; i++)
				{
					if (ListaDescripciones[i].ToUpper() == TxtDescripcion.Text.ToUpper())
					{
						TxtCuenta.Text = ListaCuentas[i];
						break;
					}
				}
				mutex = false;
			}
		}

		private void TxtCuenta_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				TxtDescripcion.Text = "";
				for (int i = 0; i < ListaCuentas.Count; i++)
				{
					if (ListaCuentas[i] == TxtCuenta.Text)
					{
						TxtDescripcion.Text = ListaDescripciones[i];
						break;
					}
				}
				mutex = false;
			}
		}

		private void TxtDebe_TextChanged(object sender, EventArgs e)
		{
			if (!changing)
			{
				changing = true;
				try
				{
					decimal value = Convert.ToDecimal(TxtDebe.Text, CultureInfo.InvariantCulture);
					Debe = true;
					Monto = value;
					TxtHaber.Text = "";
				}
				catch (Exception ex)
				{
					string a = ex.ToString();
				}
				changing = false;
			}
			parent.ActualizarTotales();
			parent.ActualizarPosiciones();
		}

		private void TxtDebe_Leave(object sender, EventArgs e)
		{
			if (TxtDebe.Text != "")
			{
				TxtDebe.Text = Monto.ToString("N2", CultureInfo.InvariantCulture);
			}
		}

		private void TxtHaber_TextChanged(object sender, EventArgs e)
		{
			if (!changing)
			{
				changing = true;
				try
				{
					decimal value = Convert.ToDecimal(TxtHaber.Text, CultureInfo.InvariantCulture);
					Debe = false;
					Monto = value;
					TxtDebe.Text = "";
				}
				catch (Exception ex)
				{
					string a = ex.ToString();
				}
				changing = false;
			}
			parent.ActualizarTotales();
			parent.ActualizarPosiciones();
		}

		private void TxtHaber_Leave(object sender, EventArgs e)
		{
			if (TxtHaber.Text != "")
			{
				TxtHaber.Text = Monto.ToString("N2", CultureInfo.InvariantCulture);
			}
		}

		private void BtnX_Click(object sender, EventArgs e)
		{
			RemoveFromContainer();
			parent.EliminarLinea(index);
		}

		public bool EsDebe()
		{
			return Debe;
		}

		public Decimal GetMonto()
		{
			return Monto;
		}

		public void ActualizarPosiciones(int AnchoContenedor)
		{
			TxtCuenta.Top = 30 * (index + 1);
			TxtDescripcion.Width = AnchoContenedor - 380;
			TxtDescripcion.Top = TxtCuenta.Top;
			TxtDebe.Left = TxtDescripcion.Left + TxtDescripcion.Width + 10;
			TxtDebe.Top = TxtCuenta.Top;
			TxtHaber.Left = TxtDebe.Left + TxtDebe.Width + 10;
			TxtHaber.Top = TxtCuenta.Top;
			BtnEliminar.Left = TxtHaber.Left + TxtHaber.Width + 10;
			BtnEliminar.Top = TxtHaber.Top - 2;
		}

		public void SetIndex(int idx)
		{
			index = idx;
		}

		public String NroLinea
		{
			get
			{
				return (index + 1).ToString().PadLeft(2, '0');
			}
		}

		public String Cuenta
		{
			get
			{
				return TxtCuenta.Text;
			}
		}

		public void Focus()
		{
			TxtCuenta.Focus();
		}
	}
}