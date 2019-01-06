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
    public partial class FrmNombreProveed : Form
    {
        public FrmNombreProveed()
        {
            InitializeComponent();
        }

        private void FrmNombreProveed_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_proveedor' Puede moverla o quitarla según sea necesario.
            this.spmostrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmostrar_proveedor);

            this.reportViewer1.RefreshReport();
        }

        private void btnImprimirNombCli_Click(object sender, EventArgs e)
        {
            ReportParameter par1 = new ReportParameter("ProvNombDde", txtProvNombDde.Text);
            reportViewer1.LocalReport.SetParameters(par1);

            ReportParameter par2 = new ReportParameter("ProvNombHta", txtProvNombHta.Text);
            reportViewer1.LocalReport.SetParameters(par2);

            this.spmostrar_proveedorTableAdapter.Fill(this.dsPrincipal.spmostrar_proveedor);
            reportViewer1.RefreshReport();
        }
    }
}
