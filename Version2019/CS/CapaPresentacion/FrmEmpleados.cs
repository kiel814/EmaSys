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
    public partial class FrmEmpleados : Form
    {
        //creo 2 variables para saber si voy a registrar un empleado o lo voy a editar
        //bool es verdadera o falsa
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public FrmEmpleados()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese Nombre del Empleado");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese Apellido del Empleado");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese Usuario para Ingresar al Sistema EMA SA");
            this.ttMensaje.SetToolTip(this.txtPassword, "Ingrese Password para Ingresar al Sistema EMA SA");
            this.ttMensaje.SetToolTip(this.cboAcceso, "Seleccione el Nivel de Acceso del Empleado");
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema EMA SA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema EMA SA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            //Los combobox no los dejo en blanco, sólo las cajas de texto
            this.txtNombre.Text = string.Empty;
            this.txtEmpleadoID.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            //this.cboSexo.Text = string.Empty;
            //this.dtFecha_Nac.Text = string.Empty;
            this.txtNum_documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            //this.cboAcceso.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;            
        }

        //Habilitar los controles del formulario
        //recibe parametro valor que puede ser verd o falso
        //si recibo true entonces las cajas de textos van a estar habilitadas
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtEmpleadoID.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.cboSexo.Enabled = valor;
            //this.dtFecha_Nac.Text = string.Empty;
            this.txtNum_documento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cboAcceso.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;            
        }

        //Habilitar o deshabilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt+124  
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            //Columna 0 es Eliminar
            this.dataListado.Columns[0].Visible = false;
            //columna 1 es ClienteID que no necesito visualizar
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar todos los registros de la tabla Empleados
        private void Mostrar()
        {
            //muestra todos los registros de la tabla Empleados
            this.dataListado.DataSource = NEmpleados.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NEmpleados.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_documento
        private void BuscarNum_documento()
        {
            this.dataListado.DataSource = NEmpleados.BuscarNum_documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }              

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            //las cajas de textos no están habilitadas o son de sólo lectura
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBuscar.Text.Equals("Documento"))
            {
                //la búsqueda será por nro. de documento
                this.BuscarNum_documento();
            }
            else if(cboBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellidos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //declaro una variable opcion para que el usuario diga si está seguro o no de la eliminación
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema EMA SA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                //Evalúo si el usuario quiere eliminar , entonces dio OK
                if (Opcion == DialogResult.OK)
                {
                    //defino la variable, Codigo para enviar la clave primaria del codigo que quiero eliminar
                    string Codigo;
                    //defino variable rpta para recibir la respuesta de si elimino o no elimino
                    string Rpta = "";
                    //declaro un bucle que recorre todos los registros para ver si están marcados o no con checkbox
                    //y si están marcados los pasare al metodo eliminar de la capaNegocios y luego a eliminar de la 
                    //capaDatos
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        //Evaluo fila x fila si está marcado el checkbox
                        //si el valor de la columna 0 es true, entonces elimino esa fila
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //en Codigo tengo la clave primaria del registro que voy a eliminar
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            //Codigo es string pero NClientes.Eliminar espera un int, entonces convierto
                            Rpta = NEmpleados.Eliminar(Convert.ToInt32(Codigo));

                            //Si se pudo eliminar el registro
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("El Registro fue Eliminado Correctamente");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //si está seleccionado
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtEmpleadoID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["EmpleadoID"].Value);            
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellidos"].Value);
            this.cboSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sexo"].Value);
            //PONER VALUE no Text para poner el Convert.ToDateTime
            this.dtFecha_Nac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Nac"].Value);                                    
            this.txtNum_documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email"].Value);
            this.cboAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            
            //selecciono los valores y paso al tap page de mantenimiento para ver lo seleccionado
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtEmpleadoID.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                //Debo evaluar que el campo Nombre, y el resto no pueden ser null
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty ||
                    this.txtNum_documento.Text == string.Empty || this.txtDireccion.Text == string.Empty ||
                    this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese el Nombre del Empleado");
                    errorIcono.SetError(txtApellidos, "Ingrese el Apellido del Empleado");
                    errorIcono.SetError(txtNum_documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                }
                else
                {
                    //Veo si el usuario quiere ingresar un nuevo registro
                    if (this.IsNuevo)
                    {
                        //rpta va a verificar si se insertó o modificó un registro
                        //dtFecha_Nac NO LLEVA This!!!!
                        rpta = NEmpleados.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cboSexo.Text,
                            dtFecha_Nac.Value, this.txtNum_documento.Text, this.txtDireccion.Text,
                            this.txtTelefono.Text, this.txtEmail.Text, this.cboAcceso.Text, this.txtUsuario.Text,
                            this.txtPassword.Text);                            
                    }
                    else
                    {
                        rpta = NEmpleados.Editar(Convert.ToInt32(this.txtEmpleadoID.Text),
                            this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(), this.cboSexo.Text,
                            dtFecha_Nac.Value, this.txtNum_documento.Text, this.txtDireccion.Text,
                            this.txtTelefono.Text, this.txtEmail.Text, this.cboAcceso.Text, this.txtUsuario.Text,
                            this.txtPassword.Text);
                    }
                    if (rpta.Equals("OK"))
                    {
                        //si recibe OK, puede ser de insertar o editar, entonces, pregunto
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("El Registro Se Insertó de forma correcta");
                        }
                        else
                        {
                            this.MensajeOk("El Registro Se Actualizó de forma correcta");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //para editar pregunto si el txt EmpleadoID no está vacio
            if (!this.txtEmpleadoID.Text.Equals(""))
            {
                this.IsEditar = true;
                //llamo al método botones y habilitar para habilitar los botones
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Primero debe seleccionar el registro a modificar");
            }
        }
    }
}
