using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//fal- agrego para Reporte con Parámetros por Código de Cliente
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FrmCodProveed : Form
    {
        public FrmCodProveed()
        {
            InitializeComponent();
        }

        private void FrmCodProveed_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_proveedor' Puede moverla o quitarla según sea necesario.
            this.spmostrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmostrar_proveedor);

            this.reportViewer1.RefreshReport();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Valido si CodDde es Mayor que CodHta
            int codDde = Convert.ToInt32(txtProvCodDde.Text);
            int codHta = Convert.ToInt32(txtProvCodHta.Text);

            if (codDde > codHta)
            {
                MessageBox.Show("Código Proveedor DESDE NO debe ser MENOR a Código Proveedor HASTA", "Ingrese Código de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtProvCodDde.Focus();
            }
            //
            ReportParameter par1 = new ReportParameter("ProvCodDde", txtProvCodDde.Text);
            reportViewer1.LocalReport.SetParameters(par1);

            ReportParameter par2 = new ReportParameter("ProvCodHta", txtProvCodHta.Text);
            reportViewer1.LocalReport.SetParameters(par2);

            this.spmostrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmostrar_proveedor);
            reportViewer1.RefreshReport();
        }

        private void txtProvCodDde_Validating(object sender, CancelEventArgs e)
        {
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtProvCodDde.Text.Length);

            if (cadena == 1)
            {
                txtProvCodDde.Text = "0" + txtProvCodDde.Text;
            }
            else if (cadena == 2)
            {
                txtProvCodDde.Text = "00" + txtProvCodDde.Text;
            }
            else if (cadena == 3)
            {
                txtProvCodDde.Text = "000" + txtProvCodDde.Text;
            }

            if (this.txtProvCodDde.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar el Código de Cliente");
                this.txtProvCodDde.Focus();
            }
        }

        private void txtProvCodHta_Validating(object sender, CancelEventArgs e)
        {
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtProvCodHta.Text.Length);

            if (cadena == 1)
            {
                txtProvCodHta.Text = "0" + txtProvCodHta.Text;
            }
            else if (cadena == 2)
            {
                txtProvCodHta.Text = "00" + txtProvCodHta.Text;
            }
            else if (cadena == 3)
            {
                txtProvCodHta.Text = "000" + txtProvCodHta.Text;
            }

            if (this.txtProvCodHta.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar el Código de Proveedor");
                this.txtProvCodHta.Focus();
            }
        }
    }    
}
