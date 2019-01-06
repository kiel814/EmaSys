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

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmFacturasProveedores : Form
    {
        decimal MontoNeto;
        decimal MontoExento;
        decimal PorcentajeIVA;
        decimal PorcentajePercepcionIVA;
        decimal PorcentajeIIBB;
        decimal MontoIVA;
        decimal MontoPercepcionIVA;
        decimal MontoIIBB;
        decimal MontoTotal;

        DataTable ListaProveedores;

        public FrmFacturasProveedores()
        {
            InitializeComponent();

            MontoNeto = 0;
            MontoExento = 0;
            PorcentajeIVA = 0;
            PorcentajePercepcionIVA = 0;
            PorcentajeIIBB = 0;
            MontoIVA = 0;
            MontoPercepcionIVA = 0;
            MontoIIBB = 0;
            MontoTotal = 0;

            ListaProveedores = NProveedores.ListaCodigoNombre();
            AutoCompleteStringCollection collectionCodigos = new AutoCompleteStringCollection();
            for (int i = 0; i < ListaProveedores.Rows.Count; i++)
            {
                collectionCodigos.Add(ListaProveedores.Rows[i][0].ToString());
            }
            txtCodigo.AutoCompleteCustomSource = collectionCodigos;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = "";

            for (int i = 0; i < ListaProveedores.Rows.Count; i++)
            {
                if (ListaProveedores.Rows[i][0].ToString() == txtCodigo.Text)
                {
                    txtNombre.Text = ListaProveedores.Rows[i][1].ToString();
                    break;
                }
            }
        }

        private void CalculateAll()
        {
            MontoNeto = TextboxToDecimal(txtNeto, false);
            MontoExento = TextboxToDecimal(txtExento, false);
            PorcentajeIVA = NumericToDecimal(nudPorcentajeIVA, true);
            PorcentajePercepcionIVA = NumericToDecimal(nudPorcentajePercepcionIVA, true);
            PorcentajeIIBB = NumericToDecimal(nudPorcentajeIIBB, true);
            MontoIVA = Math.Round(MontoNeto * PorcentajeIVA, 2);
            MontoPercepcionIVA = Math.Round(MontoNeto * PorcentajePercepcionIVA, 2);
            MontoIIBB = Math.Round(MontoNeto * PorcentajeIIBB, 2);
            MontoTotal = MontoNeto + MontoExento + MontoIVA + MontoPercepcionIVA + MontoIIBB;
            txtMontoIVA.Text = "$ " + MontoIVA.ToString("N2");
            txtMontoPercepcionIVA.Text = "$ " + MontoPercepcionIVA.ToString("N2");
            txtMontoIIBB.Text = "$ " + MontoIIBB.ToString("N2");
            txtTotal.Text = "$ " + MontoTotal.ToString("N2");
        }

        private decimal TextboxToDecimal(TextBox Txt, bool Percent)
        {
            decimal value = 0;
            try
            {
                value = Convert.ToDecimal(Txt.Text);
                if (Percent)
                {
                    value = value / 100;
                }
                Txt.BackColor = SystemColors.Window;
            }
            catch (FormatException ex)
            {
                Txt.BackColor = Color.LightPink;
            }
            return value;
        }

        private decimal NumericToDecimal(NumericUpDown Nud, bool Percent)
        {
            decimal value = 0;
            try
            {
                value = Convert.ToDecimal(Nud.Value);
                if (Percent)
                {
                    value = value / 100;
                }
                Nud.BackColor = SystemColors.Window;
            }
            catch (FormatException ex)
            {
                Nud.BackColor = Color.LightPink;
            }
            return value;
        }

        private void txtNeto_TextChanged(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void txtExento_TextChanged(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void nudPorcentajeIVA_ValueChanged(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void nudPorcentajePercepcionIVA_ValueChanged(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void nudPorcentajeIIBB_ValueChanged(object sender, EventArgs e)
        {
            CalculateAll();
        }

        private void txtSucursal_Enter(object sender, EventArgs e)
        {
            txtSucursal.SelectAll();
        }

        private void txtSucursal_Leave(object sender, EventArgs e)
        {
            txtSucursal.Text = txtSucursal.Text.PadLeft(4, '0');
        }

        private void txtDocumento_Enter(object sender, EventArgs e)
        {
            txtDocumento.SelectAll();
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            txtSucursal.Text = txtDocumento.Text.PadLeft(8, '0');
        }

        private void txtNeto_Enter(object sender, EventArgs e)
        {
            txtNeto.SelectAll();
        }

        private void txtExento_Enter(object sender, EventArgs e)
        {
            txtExento.SelectAll();
        }

        private void nudPorcentajeIVA_Enter(object sender, EventArgs e)
        {
            nudPorcentajeIVA.Select(0, nudPorcentajeIVA.Text.Length);
        }

        private void nudPorcentajePercepcionIVA_Enter(object sender, EventArgs e)
        {
            nudPorcentajePercepcionIVA.Select(0, nudPorcentajePercepcionIVA.Text.Length);
        }

        private void nudPorcentajeIIBB_Enter(object sender, EventArgs e)
        {
            nudPorcentajeIIBB.Select(0, nudPorcentajeIIBB.Text.Length);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CalculateAll();

            try
            {
                String Respuesta = NFacturasProveedores.InsertarFactura(
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

                if("OK" == Respuesta)
                {
                    MessageBox.Show("Factura guardada con éxito.", "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al insertar.\r\n" + ex.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            FrmLibroDiario frm = new FrmLibroDiario();
            frm.AgregarLinea("", true, MontoNeto + MontoExento);
            frm.AgregarLinea("120201", true, MontoIVA);
            frm.AgregarLinea("120228", true, MontoPercepcionIVA);
            frm.AgregarLinea("120229", true, MontoIIBB);

            frm.Show();
            frm.ActualizarPosiciones();
        }
    }
}