using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NEmpleados.Login(this.txtUsuario.Text, this.txtPassword.Text);
            //Evalúo si existe el Usuario
            if (Datos == null || Datos.Rows == null || Datos.Rows.Count == 0)
            {
                //el usuario no existe en la tabla
                MessageBox.Show("NO tiene acceso al Sistema", "Sistema EMA SA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipal frm = new FrmPrincipal();
                //si accede al sistema, tengo que mandar los todos los datos del empleado y el frmPrincipal
                //debe poder recibirlos
                frm.EmpleadoID = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                //oculto el formulario FrmLogin
                this.Hide();
            }
		}

		private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				btnIngresar_Click(null, null);
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				btnIngresar_Click(null, null);
			}
		}
	}
}
