using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CapaPresentacion
{
	class LineaOrdenPago
	{
		Label LblTipo;
		Label LblDoc;
		Label LblContradoc;
		Label LblFecha;
		Label LblVencimiento;
		Label LblMonto;
		TextBox TxtPago;

		decimal maximo;
		public decimal pago;
		public int movimiento;

		FrmOrdenesPago parent;

		bool mutex;

		public LineaOrdenPago(FrmOrdenesPago _parent, int idx, int movimientoId, string tipo, string doc, string contradoc, string fecha, string vencimiento, string monto)
		{
			mutex = true;

			movimiento = movimientoId;

			parent = _parent;

			maximo = Tools.StringToDecimal(monto, false);

			pago = 0;

			LblTipo = CreateLabel(parent, idx, tipo, 11);
			LblDoc = CreateLabel(parent, idx, doc, 45);
			LblContradoc = CreateLabel(parent, idx, contradoc, 172);
			LblFecha = CreateLabel(parent, idx, fecha, 299);
			LblVencimiento = CreateLabel(parent, idx, vencimiento, 393);

			// LblMonto es diferente a todos los demás.
			LblMonto = CreateLabel(parent, idx, monto, 487);
			LblMonto.AutoSize = false;
			LblMonto.TextAlign = ContentAlignment.TopRight;
			LblMonto.Width = 105;
			LblMonto.Height = 15;

			TxtPago = new TextBox();
			Tools.TwoDecimalsNumberInTextBox(pago, TxtPago);
			TxtPago.Font = new Font("Consolas", 9.75f);
			TxtPago.TextAlign = HorizontalAlignment.Right;
			TxtPago.Left = 598;
			TxtPago.Top = 35 + 30 * idx;
			TxtPago.Width = 106;
			TxtPago.Height = 23;
			parent.Panel.Controls.Add(TxtPago);
			TxtPago.Parent = parent.Panel;
			TxtPago.Click += new EventHandler(Tools.TextBoxSelectAll);
			TxtPago.Enter += new EventHandler(Tools.TextBoxSelectAll);
			TxtPago.TextChanged += new EventHandler(this.TxtPago_TextChanged);
			TxtPago.Leave += new EventHandler(this.TxtPago_Leave);

			mutex = false;
		}

		private Label CreateLabel(FrmOrdenesPago parent, int idx, string text, int left)
		{
			Label l = new Label();
			l.Text = text;
			l.Font = new Font("Consolas", 9.75f);
			l.AutoSize = true;
			l.Left = left;
			l.Top = 38 + 30 * idx;

			parent.Panel.Controls.Add(l);
			l.Parent = parent.Panel;

			return l;
		}

		private void TxtPago_TextChanged(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				if (TxtPago.Text.ToUpper().Contains("T"))
				{
					Tools.TwoDecimalsNumberInTextBox(maximo, TxtPago);
				}
				pago = Tools.TextboxToDecimal(TxtPago, false);
				parent.ActualizarNeto();
				mutex = false;
			}
		}

		private void TxtPago_Leave(object sender, EventArgs e)
		{
			if (!mutex)
			{
				mutex = true;
				if (pago > maximo)
				{
					pago = maximo;
				}
				Tools.TwoDecimalsNumberInTextBox(pago, TxtPago);
				parent.ActualizarNeto();
				mutex = false;
			}
		}

		public decimal GetPago()
		{
			return pago;
		}

		public decimal GetNeto()
		{
			if (pago == maximo)
			{ }
		}

		public void RemoveFromContainer()
		{
			parent.Panel.Controls.Remove(LblTipo);
			parent.Panel.Controls.Remove(LblDoc);
			parent.Panel.Controls.Remove(LblContradoc);
			parent.Panel.Controls.Remove(LblFecha);
			parent.Panel.Controls.Remove(LblVencimiento);
			parent.Panel.Controls.Remove(LblMonto);
			parent.Panel.Controls.Remove(TxtPago);
		}
	}
}