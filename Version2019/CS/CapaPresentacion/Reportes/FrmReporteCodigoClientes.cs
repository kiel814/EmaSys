using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//fal agrego para Reporte por Cód Cliente
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FrmReporteCodClientes : Form
    {
        public FrmReporteCodClientes()
        {
            InitializeComponent();
        }

        private void FrmReporteCodCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReportParameter par1 = new ReportParameter("CliCodDde",txtDdeCodClien.Text);
            reportViewer1.LocalReport.SetParameters(par1);

            ReportParameter par2 = new ReportParameter("CliCodHta", txtHtaCodClien.Text);            
            reportViewer1.LocalReport.SetParameters(par2);
            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
            
            reportViewer1.RefreshReport();
        }
    }
}
