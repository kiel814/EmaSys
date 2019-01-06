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
    public partial class FrmCodClientes : Form
    {
        public FrmCodClientes()
        {
            InitializeComponent();
        }

        private void FrmCodClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtCliCodDde_Validating(object sender, CancelEventArgs e)
        {
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtCliCodDde.Text.Length);
            
            if (cadena == 1)
            {
                txtCliCodDde.Text = "0" + txtCliCodDde.Text;
            }
            else if (cadena == 2)
            {
                txtCliCodDde.Text = "00" + txtCliCodDde.Text;
            }
            else if (cadena == 3)
            {
                txtCliCodDde.Text = "000" + txtCliCodDde.Text;
            }           

            if (this.txtCliCodDde.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar el Código de Cliente");
                this.txtCliCodDde.Focus();
            }
        }

        private void txtCliCodHta_Validating(object sender, CancelEventArgs e)
        {
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtCliCodHta.Text.Length);

            if (cadena == 1) 
            {
                txtCliCodHta.Text = "0" + txtCliCodHta.Text;
            }
            else if (cadena == 2)
            {
                txtCliCodHta.Text = "00" + txtCliCodHta.Text;
            }
            else if (cadena == 3)
            {
                txtCliCodHta.Text = "000" + txtCliCodHta.Text;
            }

            if (this.txtCliCodHta.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar el Código de Cliente");
                this.txtCliCodHta.Focus();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Valido si CodDde es Mayor que CodHta
            int codDde = Convert.ToInt32(txtCliCodDde.Text);
            int codHta = Convert.ToInt32(txtCliCodHta.Text);

            if (codDde > codHta)
            {
                MessageBox.Show("Código Cliente DESDE NO debe ser MENOR a Código Cliente HASTA", "Ingrese Código de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCliCodDde.Focus();
            }
            //
            ReportParameter par1 = new ReportParameter("CliCodDde", txtCliCodDde.Text);
            reportViewer1.LocalReport.SetParameters(par1);

            ReportParameter par2 = new ReportParameter("CliCodHta", txtCliCodHta.Text);
            reportViewer1.LocalReport.SetParameters(par2);

            this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
            reportViewer1.RefreshReport();
        }
    }
}
