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
    public partial class FrmNombreClientes : Form
    {
        public FrmNombreClientes()
        {
            InitializeComponent();
        }

        private void FrmNombreClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);

            this.reportViewer1.RefreshReport();            
        }

        private void btnImprimirNombCli_Click(object sender, EventArgs e)
        {
            ReportParameter par1 = new ReportParameter("CliNombDde", txtCliNombDde.Text);
            reportViewer1.LocalReport.SetParameters(par1);

            ReportParameter par2 = new ReportParameter("CliNombHta", txtCliNombHta.Text);
            reportViewer1.LocalReport.SetParameters(par2);

            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
            reportViewer1.RefreshReport();
        }

        private void txtCliNombDde_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtCliNombHta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
