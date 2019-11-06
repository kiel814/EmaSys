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

namespace CapaPresentacion
{
	public partial class FrmIIBB : Form
	{
		IIBBCaller parent;
		List<LineaIIBB> lineas;
		AutoCompleteStringCollection listaProvincias;

		decimal TotalIIBB;

		public FrmIIBB(IIBBCaller caller, AutoCompleteStringCollection provincias)
		{
			InitializeComponent();

			parent = caller;
			lineas = new List<LineaIIBB>();
			listaProvincias = provincias;

			LblNeto.Text = "Monto neto: $" + GetMontoNeto().ToString("N2", CultureInfo.InvariantCulture);
		}

		public decimal GetMontoNeto()
		{
			return parent.GetMontoNeto();
		}

		public void SetLineas(List<LineaIIBB> _lineas)
		{
			for(int i = 0; i < _lineas.Count; i++)
			{
				AgregarLinea(_lineas[i].Provincia, _lineas[i].Porcentaje);
			}
			ActualizarTotal();
		}

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			if (lineas.Count < 24)
			{
				AgregarLinea();
				ActualizarPosiciones();
				PnlIIBB.VerticalScroll.Value = PnlIIBB.VerticalScroll.Maximum;
				lineas[lineas.Count - 1].Focus();
			}
			else
			{
				MessageBox.Show("No se pueden agregar más de 24 líneas de IIBB.", "Agregar Línea", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void AgregarLinea()
		{
			LineaIIBB l = new LineaIIBB(this, lineas.Count, listaProvincias);
			lineas.Add(l);
			BtnAgregar.Top = lineas[lineas.Count - 1].GetHeight() + 30;
		}

		private void AgregarLinea(string provincia, decimal porcentaje)
		{
			LineaIIBB l = new LineaIIBB(this, lineas.Count, listaProvincias);
			l.SetValues(provincia, porcentaje);
			lineas.Add(l);
			BtnAgregar.Top = lineas[lineas.Count - 1].GetHeight() + 30;
		}

		public Panel Panel
		{
			get { return PnlIIBB; }
		}

		public void TextBoxSelectAll(object sender, EventArgs e)
		{
			//parent.TextBoxSelectAll(sender, e);
			Tools.TextBoxSelectAll(sender, e);
		}

		public decimal TextboxToDecimal(TextBox Txt, bool Percent)
		{
			return Tools.TextboxToDecimal(Txt, Percent);
			//return parent.TextboxToDecimal(Txt, Percent);
		}

		public void TwoDecimalsNumberInTextBox(decimal Value, TextBox Txt)
		{
			Tools.TwoDecimalsNumberInTextBox(Value, Txt);
			//parent.TwoDecimalsNumberInTextBox(Value, Txt);
		}

		/*public decimal GetMontoNeto()
		{
			parent.GetMontoNeto();
		}*/

		public void EliminarLinea(int idx)
		{
			lineas.RemoveAt(idx);
			for (int i = 0; i < lineas.Count; i++)
			{
				lineas[i].SetIndex(i);
			}
			ActualizarPosiciones();
			ActualizarTotal();
		}

		public void ActualizarTotal()
		{
			TotalIIBB = 0;
			for (int i = 0; i < lineas.Count; i++)
			{
				TotalIIBB += lineas[i].Monto;
			}
			LblTotal.Text = "Total IIBB: $" + TotalIIBB.ToString("N2", CultureInfo.InvariantCulture);
		}

		public void ActualizarPosiciones()
		{
			if (lineas.Count > 0)
			{
				BtnAgregar.Top = lineas[lineas.Count - 1].GetHeight() + 30;
			}
			else
			{
				BtnAgregar.Top = 30;
			}

			foreach (LineaIIBB l in lineas)
			{
				l.ActualizarPosiciones();
			}
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BtnGuardar_Click(object sender, EventArgs e)
		{
			if (Validar())
			{
				parent.SetLineasIIBB(lineas);
				this.Close();
			}
		}

		public bool Validar()
		{
			string message = "";
			for (int i = 0; i < lineas.Count; i++)
			{
				// Validar provincia
				if (!listaProvincias.Contains(lineas[i].Provincia))
				{
					message = "La provincia \"" + lineas[i].Provincia + "\" (" + (i + 1) + ") no es válida.";
					break;
				}

				// Validar porcentaje
				if (lineas[i].Porcentaje <= 0.0m)
				{
					message = "El porcentaje para la provincia \"" + lineas[i].Provincia + "\" (" + (i + 1) + ") debe ser mayor a cero.";
					break;
				}

				// Validar que las provincias sean diferentes entre si
				for (int j = i + 1; j < lineas.Count; j++)
				{
					if (lineas[i].Provincia == lineas[j].Provincia)
					{
						message = "Provincia \"" + lineas[i].Provincia + "\" duplicada (" + (i + 1) + " y " + (j + 1) + ").";
						break;
					}
				}
			}
			if (message != "")
			{
				MessageBox.Show(message, "Errores en IIBB", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return message == "";
		}
	}
}