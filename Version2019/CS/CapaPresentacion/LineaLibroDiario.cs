using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class LineaLibroDiario
    {
        TextBox TxtCuenta;
        TextBox TxtDescripcion;
        TextBox TxtDebe;
        TextBox TxtHaber;
        AutoCompleteStringCollection ListaCuentas;
        AutoCompleteStringCollection ListaDescripciones;
        bool Debe;
        decimal Monto;

        bool changing;

        int AnchoDescripcion;

        public LineaLibroDiario(String Cuenta, bool _Debe, decimal _Monto, Panel Container, int Index, AutoCompleteStringCollection AutocompleteCuenta, AutoCompleteStringCollection AutocompleteDescripcion)
        {
            AnchoDescripcion = 250;

            Debe = _Debe;
            Monto = _Monto;
            ListaCuentas = AutocompleteCuenta;
            ListaDescripciones = AutocompleteDescripcion;

            TxtCuenta = new TextBox();
            TxtCuenta.Left = 10;
            TxtCuenta.Top = 30 * (Index + 1);
            TxtCuenta.Width = 50;
            TxtCuenta.TextAlign = HorizontalAlignment.Center;
            TxtCuenta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TxtCuenta.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtCuenta.AutoCompleteCustomSource = AutocompleteCuenta;
            TxtCuenta.TextChanged += new System.EventHandler(this.TxtCuenta_TextChanged);

            TxtDescripcion = new TextBox();
            TxtDescripcion.Left = TxtCuenta.Left + TxtCuenta.Width + 10;
            TxtDescripcion.Top = TxtCuenta.Top;
            TxtDescripcion.Width = AnchoDescripcion;
            TxtDescripcion.ReadOnly = true;

            // Esto hay que hacerlo despues de crear TxtDescription.
            // Si no, no puede autocompletar (y explota porque es null).
            TxtCuenta.Text = Cuenta;

            TxtDebe = new TextBox();
            TxtDebe.Text = Debe ? Monto.ToString("N2") : "";
            TxtDebe.Left = TxtDescripcion.Left + TxtDescripcion.Width + 10;
            TxtDebe.Top = TxtCuenta.Top;
            TxtDebe.Width = 80;
            TxtDebe.TextAlign = HorizontalAlignment.Right;
            TxtDebe.TextChanged += new System.EventHandler(this.TxtDebe_TextChanged);

            TxtHaber = new TextBox();
            TxtHaber.Text = Debe ? "" : Monto.ToString("N2");
            TxtHaber.Left = TxtDebe.Left + TxtDebe.Width + 10;
            TxtHaber.Top = TxtCuenta.Top;
            TxtHaber.Width = 80;
            TxtHaber.TextAlign = HorizontalAlignment.Right;
            TxtHaber.TextChanged += new System.EventHandler(this.TxtHaber_TextChanged);

            Container.Controls.Add(TxtCuenta);
            Container.Controls.Add(TxtDescripcion);
            Container.Controls.Add(TxtDebe);
            Container.Controls.Add(TxtHaber);

            changing = false;
        }

        private void TxtCuenta_TextChanged(object sender, EventArgs e)
        {
            TxtDescripcion.Text = "";
            for (int i = 0; i < ListaCuentas.Count; i++)
            {
                if (ListaCuentas[i] == TxtCuenta.Text)
                {
                    TxtDescripcion.Text = ListaDescripciones[i];
                    break;
                }
            }
        }

        private void TxtDebe_TextChanged(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                decimal value = 0;
                try
                {
                    value = Convert.ToDecimal(TxtDebe.Text);
                }
                catch (Exception ex)
                {
                }

                if (value != 0 && !Debe)
                {
                    Debe = true;
                    Monto = value;
                    TxtHaber.Text = "";
                }
                changing = false;
            }
        }

        private void TxtHaber_TextChanged(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                decimal value = 0;
                try
                {
                    value = Convert.ToDecimal(TxtDebe.Text);
                }
                catch (Exception ex)
                {
                }

                if (value != 0 && !Debe)
                {
                    Debe = false;
                    Monto = value;
                    TxtDebe.Text = "";
                }
                changing = false;
            }
        }

        public bool EsDebe()
        {
            return Debe;
        }

        public decimal GetMonto()
        {
            return Monto;
        }

        public void ActualizarPosiciones(int AnchoContenedor)
        {
            TxtDescripcion.Width = AnchoContenedor - 265;
            TxtDebe.Left = TxtDescripcion.Left + TxtDescripcion.Width + 10;
            TxtHaber.Left = TxtDebe.Left + TxtDebe.Width + 10;
        }
    }
}