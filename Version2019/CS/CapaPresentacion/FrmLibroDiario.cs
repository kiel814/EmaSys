using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmLibroDiario : Form
    {
        decimal Debe;
        decimal Haber;

        List<LineaLibroDiario> Lineas;

        DataTable ListaCuentas;
        AutoCompleteStringCollection collectionCuenta;
        AutoCompleteStringCollection collectionDescripcion;

        public FrmLibroDiario()
        {
            InitializeComponent();

            Lineas = new List<LineaLibroDiario>();

            ListaCuentas = NCuentas.ListaCuentaDescripcion();
            collectionCuenta = new AutoCompleteStringCollection();
            collectionDescripcion = new AutoCompleteStringCollection();
            for (int i = 0; i < ListaCuentas.Rows.Count; i++)
            {
                collectionCuenta.Add(ListaCuentas.Rows[i][0].ToString());
                collectionDescripcion.Add(ListaCuentas.Rows[i][1].ToString());
            }

            Debe = 0;
            Haber = 0;
        }

        public void AgregarLinea(String Cuenta, bool Debe, decimal Monto)
        {
            LineaLibroDiario l = new LineaLibroDiario(Cuenta, Debe, Monto, this.PnlLineas, Lineas.Count, collectionCuenta, collectionDescripcion);
            Lineas.Add(l);
            ActualizarTotales();
        }

        private void FrmLibroDiario_Resize(object sender, EventArgs e)
        {
            ActualizarPosiciones();
        }

        public void ActualizarPosiciones()
        {
            PnlLineas.Width = this.Width - 45;
            PnlLineas.Height = this.Height - 175;

            LblTituloDebe.Left = PnlLineas.Width - 185;
            LblTituloHaber.Left = PnlLineas.Width - 95;

            BtnGuardar.Left = this.Width - 105;
            BtnGuardar.Top = this.Height - 75;

            LblTotalDebe.Left = PnlLineas.Left + LblTituloDebe.Left + 80 - LblTotalDebe.Width;
            LblTotalDebe.Top = PnlLineas.Top + PnlLineas.Height + 10;

            LblTotalHaber.Left = PnlLineas.Left + LblTituloHaber.Left + 80 - LblTotalHaber.Width;
            LblTotalHaber.Top = PnlLineas.Top + PnlLineas.Height + 10;

            foreach (LineaLibroDiario l in Lineas)
            {
                l.ActualizarPosiciones(PnlLineas.Width);
            }
        }

        private void ActualizarTotales()
        {
            Debe = 0;
            Haber = 0;
            foreach(LineaLibroDiario l in Lineas)
            {
                if(l.EsDebe())
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {/*
            try
            {
                String Respuesta = NLibroDiario.InsertarFactura(
                    txtCodigo.Text,
                    cbbTipoFactura.SelectedItem.ToString(),
                    txtSucursal.Text, txtDocumento.Text,
                    dtpFechaFactura.Value, dtpCarga.Value, dtpVencimiento.Value,
                    MontoNeto, MontoExento,
                    PorcentajeIVA, MontoIVA,
                    PorcentajePercepcionIVA, MontoPercepcionIVA,
                    PorcentajeIIBB, MontoIIBB,
                    txtMaterial.Text,
                    txtProvincia.Text,
                    chkBienDeUso.Checked, chkActivo.Checked,
                    MontoTotal,
                    txtObservaciones.Text);

                if ("OK" == Respuesta)
                {
                    MessageBox.Show("Factura guardada con éxito.", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar.\r\n" + ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}