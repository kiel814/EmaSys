using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
	public class LineaIIBB
	{
		FrmIIBB parent;

		TextBox TxtProvincia;
		TextBox TxtPorcentaje;
		TextBox TxtMonto;
		Button BtnX;
		AutoCompleteStringCollection ListaProvincias;

		public int Linea
		{
			get
			{
				return index + 1;
			}
		}
		public string Provincia;
		public decimal Porcentaje;
		public decimal Monto;

		int index;

		bool mutex;

		public LineaIIBB(FrmIIBB form, int idx, AutoCompleteStringCollection AutocompleteProvincias)
		{
			mutex = true;

			parent = form;

			index = idx;

			ListaProvincias = AutocompleteProvincias;

			TxtProvincia = new TextBox();
			TxtProvincia.Left = 10;
			int value = parent.Panel.VerticalScroll.Visible ? parent.Panel.VerticalScroll.Value : 0;
			TxtProvincia.Top = 30 * (index + 1) - value;
			TxtProvincia.Width = 97;
			TxtProvincia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			TxtProvincia.AutoCompleteSource = AutoCompleteSource.CustomSource;
			TxtProvincia.AutoCompleteCustomSource = AutocompleteProvincias;
			TxtProvincia.Click += new EventHandler(parent.TextBoxSelectAll);
			TxtProvincia.Enter += new EventHandler(parent.TextBoxSelectAll);
			TxtProvincia.TextChanged += new EventHandler(TxtProvincia_TextChanged);
			TxtProvincia.Leave += new EventHandler(TxtProvincia_Leave);

			TxtPorcentaje = new TextBox();
			TxtPorcentaje.Left = TxtProvincia.Left + TxtProvincia.Width + 10;
			TxtPorcentaje.Top = TxtProvincia.Top;
			TxtPorcentaje.Width = 59;
			TxtPorcentaje.TextAlign = HorizontalAlignment.Right;
			TxtPorcentaje.Click += new EventHandler(parent.TextBoxSelectAll);
			TxtPorcentaje.Enter += new EventHandler(parent.TextBoxSelectAll);
			TxtPorcentaje.TextChanged += new EventHandler(TxtPorcentaje_TextChanged);
			TxtPorcentaje.Leave += new EventHandler(TxtPorcentaje_Leave);

			TxtMonto = new TextBox();
			TxtMonto.Left = TxtPorcentaje.Left + TxtPorcentaje.Width + 10;
			TxtMonto.Top = TxtProvincia.Top;
			TxtMonto.Width = 115;
			TxtMonto.TextAlign = HorizontalAlignment.Right;
			TxtMonto.Click += new EventHandler(parent.TextBoxSelectAll);
			TxtMonto.Enter += new EventHandler(parent.TextBoxSelectAll);
			TxtMonto.TextChanged += new EventHandler(this.TxtMonto_TextChanged);
			TxtMonto.Leave += new EventHandler(this.TxtMonto_Leave);

			BtnX = new Button();
			BtnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			BtnX.Text = "X";
			BtnX.Width = 25;
			BtnX.Height = 23;
			BtnX.Left = TxtMonto.Left + TxtMonto.Width + 10;
			BtnX.Top = TxtProvincia.Top - 2;
			BtnX.Click += new EventHandler(this.BtnX_Click);

			parent.Panel.Controls.Add(TxtProvincia);
			parent.Panel.Controls.Add(TxtPorcentaje);
			parent.Panel.Controls.Add(TxtMonto);
			parent.Panel.Controls.Add(BtnX);

			TxtProvincia.Parent = parent.Panel;
			TxtPorcentaje.Parent = parent.Panel;
			TxtMonto.Parent = parent.Panel;
			BtnX.Parent = parent.Panel;

			mutex = false;
		}

		public LineaIIBB(string _provincia, decimal _porcentaje, decimal _monto)
		{
			Provincia = _provincia;
			Porcentaje = _porcentaje;
			Monto = _monto;
		}

		public void SetValues(string _provincia, decimal _porcentaje)
		{
			TxtProvincia.Text = _provincia;
			parent.TwoDecimalsNumberInTextBox(_porcentaje * 100, TxtPorcentaje);
		}

		public void RemoveFromContainer()
		{
			parent.Panel.Controls.Remove(TxtProvincia);
			parent.Panel.Controls.Remove(TxtPorcentaje);
			parent.Panel.Controls.Remove(TxtMonto);
			parent.Panel.Controls.Remove(BtnX);
		}

		private void TxtProvincia_TextChanged(object sender, EventArgs e)
		{
			Provincia = TxtProvincia.Text;
		}

		private void TxtProvincia_Leave(object sender, EventArgs e)
		{
			foreach (string p in ListaProvincias)
			{
				if (TxtProvincia.Text.ToUpper() == p.ToUpper())
				{
					TxtProvincia.Text = p;
					break;
				}
			}
		}

		private void TxtPorcentaje_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				Porcentaje = parent.TextboxToDecimal(TxtPorcentaje, true);
				Monto = Math.Round(parent.GetMontoNeto() * Porcentaje, 2);
				parent.TwoDecimalsNumberInTextBox(Monto, TxtMonto);
				
				mutex = false;
			}
			parent.ActualizarTotal();
		}

		private void TxtPorcentaje_Leave(object sender, EventArgs e)
		{
			parent.TwoDecimalsNumberInTextBox(Porcentaje * 100, TxtPorcentaje);
		}

		private void TxtMonto_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				Monto = parent.TextboxToDecimal(TxtMonto, false);
				if (parent.GetMontoNeto() != 0)
				{
					Porcentaje = Math.Round(Monto / parent.GetMontoNeto(), 4);
				}
				else
				{
					Porcentaje = 0;
				}
				parent.TwoDecimalsNumberInTextBox(Porcentaje * 100, TxtPorcentaje);
				mutex = false;
			}
			parent.ActualizarTotal();
		}

		private void TxtMonto_Leave(object sender, EventArgs e)
		{
			parent.TwoDecimalsNumberInTextBox(Monto, TxtMonto);
		}

		public void Recalculate(decimal neto)
		{
			Monto = Math.Round(neto * Porcentaje, 2);
		}

		private void BtnX_Click(object sender, EventArgs e)
		{
			RemoveFromContainer();
			parent.EliminarLinea(index);
		}

		public void ActualizarPosiciones()
		{
			int value = parent.Panel.VerticalScroll.Visible ? parent.Panel.VerticalScroll.Value : 0;
			TxtProvincia.Top = 30 * (index + 1) - value;
			TxtPorcentaje.Top = TxtProvincia.Top;
			TxtMonto.Top = TxtProvincia.Top;
			BtnX.Top = TxtProvincia.Top - 2;
		}

		public void SetIndex(int idx)
		{
			index = idx;
			ActualizarPosiciones();
		}

		public int NroLinea
		{
			get
			{
				return (index + 1);
				//return (index + 1).ToString().PadLeft(2, '0');
			}
		}

		public void Focus()
		{
			TxtProvincia.Focus();
		}

		public int GetHeight()
		{
			return TxtProvincia.Top;
		}

	}
}