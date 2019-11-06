using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace CapaPresentacion
{
	class Tools
	{
		public static void TwoDecimalsNumberInTextBox(decimal value, TextBox txt)
		{
			TwoDecimalsNumberInTextBox(value, txt, false);
		}

		public static void TwoDecimalsNumberInTextBox(decimal value, TextBox txt, bool porcentaje)
		{
			if (porcentaje)
			{
				value = value * 100;
			}
			string str = value.ToString("N2", CultureInfo.InvariantCulture);
			txt.Text = str;
		}

		public static void TextBoxSelectAll(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		public static decimal TextboxToDecimal(TextBox txt, bool porcentaje)
		{
			decimal value = 0;
			try
			{
				value = Convert.ToDecimal(txt.Text, CultureInfo.InvariantCulture);
				if (porcentaje)
				{
					value = value / 100;
				}
				txt.BackColor = SystemColors.Window;
			}
			catch (FormatException ex)
			{
				string a = ex.ToString();
				txt.BackColor = Color.LightPink;
			}
			return value;
		}

		public static decimal StringToDecimal(string str, bool porcentaje)
		{
			decimal value = 0;
			try
			{
				value = Convert.ToDecimal(str, CultureInfo.InvariantCulture);
				if (porcentaje)
				{
					value = value / 100;
				}
			}
			catch (FormatException ex)
			{
				string a = ex.ToString();
			}
			return value;
		}
	}
}