using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//agrego fal
//using CapaNegocio;

//using System.Data.SqlClient;
//using Microsoft.Reporting.WinForms;

namespace CapaPresentacion
{
    public partial class FrmReporteClientes : Form
    {
        //SqlConnection conexionF = new SqlConnection(@"Data Source=DESKTOP-AKJEOB7\SQLEXPRESS;Initial Catalog=EmaSysDB;Integrated Security=True");
        public FrmReporteClientes()
        {
            InitializeComponent();
        }

        private void FrmReporteClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_cliente' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
            //this.spmostrar_clienteTableAdapter.Fill(this.dsPrincipal.spmostrar_cliente);
            //this.reportViewer1.RefreshReport();
        }
    }
}
