using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//agrego
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        ValidacionF vf = new ValidacionF();

        //creo 2 variables para saber si voy a registrar un cliente o lo voy a editar
        //bool es verdadera o falsa
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmClientes()
        {
            InitializeComponent();
            //muestra mensaje de ayuda en el txt
            //this.ttMensaje.SetToolTip(this.txtCliCodigo, "Ingrese el Código de Cliente");
            this.ttMensaje.SetToolTip(this.txtCliNombr, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtCliDirec, "Ingrese la Dirección del Cliente");
            this.ttMensaje.SetToolTip(this.txtCliCuit, "Ingrese el N° de CUIT del Cliente");
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
            this.txtCliCodigo.Text = string.Empty;
            this.txtCliNombr.Text = string.Empty;
            this.txtClienteID.Text = string.Empty;
            this.txtCliDirec.Text = string.Empty;
            this.txtCliTelef.Text = string.Empty;
            this.txtCliFax.Text = string.Empty;
            this.txtCliLocal.Text = string.Empty;
            this.txtCliProvi.Text = string.Empty;
            this.txtCliCPost.Text = string.Empty;
            this.txtCliCIva.Text = string.Empty;
            this.txtCliAgper.Text = string.Empty;
            this.txtCliCuit.Text = string.Empty;
            this.txtCliIngbr.Text = string.Empty;
            this.txtCliProve.Text = string.Empty;
            this.txtCliPCobr.Text = string.Empty;
            this.txtCliCocom.Text = string.Empty;
            this.txtCliTecom.Text = string.Empty;
            this.txtCliCotec.Text = string.Empty;
            this.txtCliTetec.Text = string.Empty;
            this.txtCliCoadm.Text = string.Empty;
            this.txtCliTeadm.Text = string.Empty;
            this.txtCliOk.Text = string.Empty;
            this.txtCliMail.Text = string.Empty;
            this.txtCliPais.Text = string.Empty;
           // this.cboCliPais.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        //recibe parametro valor que puede ser verd o falso
        //si recibo true entonces las cajas de textos van a estar habilitadas
        private void Habilitar(bool valor)
        {
            this.txtCliCodigo.ReadOnly = !valor;
            this.txtCliNombr.ReadOnly = !valor;
            this.txtClienteID.ReadOnly = !valor;
            this.txtCliDirec.ReadOnly = !valor;
            this.txtCliTelef.ReadOnly = !valor;
            this.txtCliFax.ReadOnly = !valor;
            this.txtCliLocal.ReadOnly = !valor;
            this.txtCliProvi.ReadOnly = !valor;
            //this.txtCliProvi.Enabled = false;
            this.txtCliCPost.ReadOnly = !valor;
            //saco estos 2 textbox porque lo cambio a combobox pero con el mismo nombre
            //this.txtCliCIva.ReadOnly = !valor;
            //this.txtCliAgper.ReadOnly = !valor;
            this.txtCliCIva.Enabled = false;
            this.txtCliAgper.Enabled = false;
            this.txtCliCuit.ReadOnly = !valor;
            this.txtCliIngbr.ReadOnly = !valor;
            this.txtCliProve.ReadOnly = !valor;
            this.txtCliPCobr.ReadOnly = !valor;
            this.txtCliCocom.ReadOnly = !valor;
            this.txtCliTecom.ReadOnly = !valor;
            this.txtCliCotec.ReadOnly = !valor;
            this.txtCliTetec.ReadOnly = !valor;
            this.txtCliCoadm.ReadOnly = !valor;
            this.txtCliTeadm.ReadOnly = !valor;
            this.txtCliOk.ReadOnly = !valor;
            this.txtCliMail.ReadOnly = !valor;
            this.txtCliPais.ReadOnly = !valor;

        }

        //Habilitar o deshabilita los botones
        private void Botones()
        {
            if(this.IsNuevo || this.IsEditar) //Alt+124  
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

            //fal
            //columna 22 es CliOk que no necesito visualizar
            this.dataListado.Columns[22].Visible = false;

            dataListado.Columns[2].HeaderText = "CódigoFox";
            dataListado.Columns[3].HeaderText = "Nombre";
            dataListado.Columns[4].HeaderText = "Domicilio";
            dataListado.Columns[5].HeaderText = "Teléfono";            
            dataListado.Columns[6].HeaderText = "Fax";
            dataListado.Columns[7].HeaderText = "Localidad";
            dataListado.Columns[8].HeaderText = "Provincia";            
            dataListado.Columns[9].HeaderText = "Cód.Postal";
            dataListado.Columns[10].HeaderText = "Cond.IVA";
            dataListado.Columns[11].HeaderText = "Ag.Perc";
            dataListado.Columns[12].HeaderText = "CUIT";
            dataListado.Columns[13].HeaderText = "Ing.Brutos";
            dataListado.Columns[14].HeaderText = "N°Proveedor";
            dataListado.Columns[15].HeaderText = "Plazo de Cobro";            
            dataListado.Columns[16].HeaderText = "Contacto Compras";
            dataListado.Columns[17].HeaderText = "Tel.";
            dataListado.Columns[18].HeaderText = "Contacto Técnico";
            dataListado.Columns[19].HeaderText = "Tel.";
            dataListado.Columns[20].HeaderText = "Contacto Admin.";
            dataListado.Columns[21].HeaderText = "Tel.";
            dataListado.Columns[23].HeaderText = "Mail";
            dataListado.Columns[24].HeaderText = "País";
        }

        //Fal - Método Ordenar las columnas dentro del dataListado
        private void OrdenarColumnas()
        {
            dataListado.Columns["CliCodigo"].DisplayIndex = 2;
            dataListado.Columns["CliNombr"].DisplayIndex = 3;
            dataListado.Columns["CliDirec"].DisplayIndex = 4;
            dataListado.Columns["CliTelef"].DisplayIndex = 5;
            dataListado.Columns["CliMail"].DisplayIndex = 6;
            dataListado.Columns["CliFax"].DisplayIndex = 7;
            dataListado.Columns["CliLocal"].DisplayIndex = 8;
            dataListado.Columns["CliProvi"].DisplayIndex = 9;
            dataListado.Columns["CliPais"].DisplayIndex = 10;
            dataListado.Columns["CliCPost"].DisplayIndex = 11;
            dataListado.Columns["CliCIva"].DisplayIndex = 12;
            dataListado.Columns["CliAgper"].DisplayIndex = 13;
            dataListado.Columns["CliCuit"].DisplayIndex = 14;
            dataListado.Columns["CliIngbr"].DisplayIndex = 15;
            dataListado.Columns["CliProve"].DisplayIndex = 16;
            dataListado.Columns["CliPCobr"].DisplayIndex = 17;
            dataListado.Columns["CliCocom"].DisplayIndex = 18;
            dataListado.Columns["CliTecom"].DisplayIndex = 19;
            dataListado.Columns["CliCotec"].DisplayIndex = 20;
            dataListado.Columns["CliTetec"].DisplayIndex = 21;
            dataListado.Columns["CliCoadm"].DisplayIndex = 23;
            dataListado.Columns["CliTeadm"].DisplayIndex = 24;
            // dataListado.Columns["ClienteID"].Visible = false;
        }
                
        //Método Mostrar todos los registros de la tabla Clientes
        private void Mostrar()
        {
            //muestra todos los registros de la tabla Clientes
            this.dataListado.DataSource = NClientes.Mostrar();

            //Fal - Para ajustar tamaño de columnas y celdas           
            //dataListado.AutoResizeColumns();
            //dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.OcultarColumnas();
            //Fal
            this.OrdenarColumnas();
        
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NClientes.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCuit
        private void BuscarCuit()
        {
            this.dataListado.DataSource = NClientes.BuscarCuit(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCliCodigo
        private void BuscarCliCodigo()
        {
            //Completo con Ceros -fal- 
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtBuscar.Text.Length);

            if (cadena == 1)
            {
                txtBuscar.Text = "0" + txtBuscar.Text;
            }
            else if (cadena == 2)
            {
                txtBuscar.Text = "00" + txtBuscar.Text;
            }
            else if (cadena == 3)
            {
                txtBuscar.Text = "000" + txtBuscar.Text;
            }

            if (this.txtBuscar.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar el Código de Cliente");
                this.txtBuscar.Focus();
            }
            //
            this.dataListado.DataSource = NClientes.BuscarCliCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmClientes_Load(object sender, EventArgs e)
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
            if (cboBuscar.Text.Equals("Nombre"))
            {
                this.BuscarNombre();
            }
            else if (cboBuscar.Text.Equals("CUIT"))
            {
                this.BuscarCuit();
            }
            else if (cboBuscar.Text.Equals("Código"))
            {
                this.BuscarCliCodigo();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {            
            this.IsNuevo = true;
            this.IsEditar = false;
            //llamo al método Botones
            this.Botones();
            this.Limpiar();
            //para habilitar las cajas de textos donde el usuario carga datos
            this.Habilitar(true);
            //this.txtCliNombr.Focus();            
            this.txtCliCodigo.Focus();
            //Fal
            this.txtCliCIva.Enabled = true;
            this.txtCliAgper.Enabled = true;
            //this.txtCliProvi.Enabled = true;
           // this.cboCliPais.Enabled = true;            
           // this.txtCliPais.Enabled = false;
           // this.txtCliPais.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                //Debo evaluar que el campo CliNombr y CliCodigo no pueden ser null
                if (this.txtCliNombr.Text == string.Empty || this.txtCliCodigo.Text == string.Empty || this.txtCliCuit.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCliNombr, "Ingrese el Nombre del Cliente");
                    errorIcono.SetError(txtCliCodigo, "Ingrese el Código de Cliente");
                    errorIcono.SetError(txtCliCuit, "Ingrese el CUIT del Cliente");
                }
                else
                {
                    //Veo si el usuario quiere ingresar un nuevo registro
                    if (this.IsNuevo)
                    {
                        //fal - agrego este if, sino da error 'Input was not in a correct format...'
                        //si el pcobr es blanco o null, no puede convertirlo a Int32
                        if (this.txtCliPCobr.Text == null || this.txtCliPCobr.Text == "")
                        {
                            this.txtCliPCobr.Text = "0";
                        }
                        //rpta va a verificar si se insertó o modificó un registro
                        rpta = NClientes.Insertar(this.txtCliCodigo.Text.Trim().ToString(),
                            this.txtCliNombr.Text.Trim().ToUpper(), this.txtCliDirec.Text.Trim().ToUpper(), this.txtCliTelef.Text.Trim(),
                            this.txtCliFax.Text.Trim(), this.txtCliLocal.Text.Trim().ToUpper(), this.txtCliProvi.Text.Trim(),
                            this.txtCliCPost.Text.Trim(), this.txtCliCIva.Text.Trim(), this.txtCliAgper.Text.Trim(),
                            this.txtCliCuit.Text.Trim(), this.txtCliIngbr.Text.Trim(), this.txtCliProve.Text.Trim(),
                            Convert.ToInt32(this.txtCliPCobr.Text.Trim()), this.txtCliCocom.Text.Trim().ToUpper(), this.txtCliTecom.Text.Trim(),
                            this.txtCliCotec.Text.Trim().ToUpper(), this.txtCliTetec.Text.Trim(), this.txtCliCoadm.Text.Trim().ToUpper(),
                            this.txtCliTeadm.Text.Trim(), this.txtCliOk.Text.Trim(), this.txtCliMail.Text.Trim(), this.txtCliPais.Text.Trim());                      
                    }
                    else
                    {
                        if (this.txtCliPCobr.Text == null || this.txtCliPCobr.Text == "")
                        {
                            this.txtCliPCobr.Text = "0";
                        }
                        rpta = NClientes.Editar(Convert.ToInt32(this.txtClienteID.Text),
                            this.txtCliCodigo.Text.Trim(),
                            this.txtCliNombr.Text.Trim().ToUpper(), this.txtCliDirec.Text.Trim().ToUpper(), this.txtCliTelef.Text.Trim(),
                            this.txtCliFax.Text.Trim(), this.txtCliLocal.Text.Trim().ToUpper(), this.txtCliProvi.Text.Trim(),
                            this.txtCliCPost.Text.Trim(), this.txtCliCIva.Text.Trim(), this.txtCliAgper.Text.Trim(),
                            this.txtCliCuit.Text.Trim(), this.txtCliIngbr.Text.Trim(), this.txtCliProve.Text.Trim(),
                            Convert.ToInt32(this.txtCliPCobr.Text.Trim()), this.txtCliCocom.Text.Trim().ToUpper(), this.txtCliTecom.Text.Trim(),
                            this.txtCliCotec.Text.Trim().ToUpper(), this.txtCliTetec.Text.Trim(), this.txtCliCoadm.Text.Trim().ToUpper(),
                            this.txtCliTeadm.Text.Trim(), this.txtCliOk.Text.Trim(), this.txtCliMail.Text.Trim(), this.txtCliPais.Text.Trim());
                    }
                    if (rpta.Equals("OK"))
                    {
                        //si recibe OK, puede ser de insertar o editar, entonces, pregunto
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("El Registro se Insertó de forma correcta");
                        }
                        else
                        {
                            this.MensajeOk("El Registro se Actualizó de forma correcta");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtClienteID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ClienteID"].Value);
            this.txtCliCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCodigo"].Value);
            this.txtCliNombr.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliNombr"].Value);
            this.txtCliDirec.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliDirec"].Value);
            this.txtCliTelef.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliTelef"].Value);            
            this.txtCliFax.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliFax"].Value);
            this.txtCliLocal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliLocal"].Value);
            this.txtCliProvi.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliProvi"].Value);            
            this.txtCliCPost.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCPost"].Value);
            this.txtCliCIva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCIva"].Value);
            this.txtCliAgper.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliAgper"].Value);
            this.txtCliCuit.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCuit"].Value);
            this.txtCliIngbr.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliIngbr"].Value);
            this.txtCliProve.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliProve"].Value);
            this.txtCliPCobr.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliPCobr"].Value);
            this.txtCliCocom.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCocom"].Value);
            this.txtCliTecom.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliTecom"].Value);
            this.txtCliCotec.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCotec"].Value);
            this.txtCliTetec.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliTetec"].Value);
            this.txtCliCoadm.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliCoadm"].Value);
            this.txtCliTeadm.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliTeadm"].Value);
            this.txtCliOk.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliOk"].Value);
            this.txtCliMail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliMail"].Value);
            this.txtCliPais.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliPais"].Value);
            //this.txtCliMail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliMail"].Value);
            //this.txtCliPais.Visible = true;
            //this.txtCliPais.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["CliPais"].Value);

            //selecciono los valores y paso al tap page de mantenimiento para ver lo seleccionado
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //para editar pregunto si el txt ClienteID no está vacio
            if (!this.txtClienteID.Text.Equals(""))
            {
                this.IsEditar = true;
                //llamo al método botones y habilitar para habilitar los botones
                this.Botones();
                this.Habilitar(true);
                //Fal
                this.txtCliCIva.Enabled = true;
                this.txtCliAgper.Enabled = true;
                //this.txtCliProvi.Enabled = true;
                //this.txtCliPais.Enabled = true;
            }
            else
            {
                this.MensajeError("Primero debe seleccionar el registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {           
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            //para deshabilitar todas las cajas de texto mando false al método Habilitar
            //y dejarlas como sólo lectura
            this.Habilitar(false);
            //Fal
            this.txtCliCIva.Enabled = false;
            this.txtCliAgper.Enabled = false;           
          //  this.cboCliPais.Enabled = false;
            this.btnNuevo.Focus();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //si este chkEliminar esta marcado
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
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell) dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //declaro una variable opcion para que el usuario diga si está seguro o no de la eliminación
                DialogResult Opcion;
                Opcion = MessageBox.Show("Confirme si Desea Eliminar los Registros", "Sistema EMA SA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
                            Rpta = NClientes.Eliminar(Convert.ToInt32(Codigo));

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {            
            FrmReporteClientes frm = new FrmReporteClientes();
            frm.ShowDialog();
        }             
        
        private void txtCliCuit_Validated(object sender, EventArgs e)
        {           
        }

        private void txtCliCuit_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtCliCuit.Text != "")
            {
                CUIT CadenaCuit = new CUIT();
                CadenaCuit.CUITSinFormato = txtCliCuit.Text;

                txtCliCuit.Text = CadenaCuit.CUITFormateado;                               
                                
                if (this.txtCliCuit.Text.Equals(""))
                {
                    MessageBox.Show("CUIT Inválido - Reingrese CUIT");                    
                    this.txtCliCuit.Focus();
                }
            }
            else
            {
                this.txtCliCuit.Text = "88-88888888-8";
            }
        }

        private void btnImprimirCodClien_Click(object sender, EventArgs e)
        {
            FrmCodClientes frm = new FrmCodClientes();            
            frm.ShowDialog();
        }

        private void btnImprimirNombreCli_Click(object sender, EventArgs e)
        {
            FrmNombreClientes frm = new FrmNombreClientes();
            frm.ShowDialog();
        }

        private void txtCliCuit_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCliCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fal - para detectar cuál fue la última tecla presionada
            //si es CANCEL
           if (e.KeyChar == Convert.ToChar(Keys.Cancel))
           {
                this.IsNuevo = false;                     
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();
                //para deshabilitar todas las cajas de texto mando false al método Habilitar
                //y dejarlas como sólo lectura
                this.Habilitar(false);
                //Fal
                this.txtCliCIva.Enabled = false;
                this.txtCliAgper.Enabled = false;
                
                //this.cboCliPais.Enabled = false;
            }
        }

        private void txtCliMail_Validating(object sender, CancelEventArgs e)
        {
            string texto = txtCliMail.Text;
            bool verificar = texto.Contains('@') && texto.Contains(".com");
            if (verificar == true)
            {
            }
            else
            {
                if (this.txtCliMail.Text != "")
                {
                    MessageBox.Show("Ingrese un Mail Válido");
                    this.txtCliMail.Focus();
                }                
            }            
        }      
        
        private void txtCliCodigo_Validating(object sender, CancelEventArgs e)
        {
            //fal- Controlar que el cód.cliente no exista en la tabla de Clientes (Cod.Fox)                                    
            
            this.dataListado.DataSource = NClientes.BuscarCliCodigo(this.txtCliCodigo.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (Convert.ToString(dataListado.Rows.Count) != "0")
            {              
                if (txtCliCodigo.Text!="")
                { 
                    MessageBox.Show("Este Código de Cliente ya Existe");
                    
                    //hago cancel
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    //para deshabilitar todas las cajas de texto mando false al método Habilitar
                    //y dejarlas como sólo lectura
                    this.Habilitar(false);
                    //Fal
                    this.txtCliCIva.Enabled = false;
                    this.txtCliAgper.Enabled = false;
                    
                    //this.cboCliPais.Enabled = false;
                    this.txtCliCodigo.Focus();
                }                
            }          
        }              
        
        private void txtCliCodigo_Leave(object sender, EventArgs e)
        {
            //fal- Completar con 0's a la izq del código ingresado
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtCliCodigo.Text.Length);

            if (cadena == 1)
            {
                txtCliCodigo.Text = "0" + txtCliCodigo.Text;
            }
            else if (cadena == 2)
            {
                txtCliCodigo.Text = "00" + txtCliCodigo.Text;
            }
            else if (cadena == 3)
            {
                txtCliCodigo.Text = "000" + txtCliCodigo.Text;
            }                        
        }

       // private void cboCliPais_SelectedIndexChanged(object sender, EventArgs e)
       // {
            //this.txtCliPais.Text = cboCliPais.Text.Trim();
       // }

       // private void cboCliPais_Click(object sender, EventArgs e)
       // {
           // this.cboCliPais.Enabled = true;
          //  this.txtCliPais.Visible = false;
        //}

      //  private void txtCliPais_Click(object sender, EventArgs e)
      //  {
      //      if (this.IsNuevo || this.IsEditar)
      //      {
               // this.cboCliPais.Enabled = true;
               // this.txtCliPais.Visible = false;
       //     }
       // }

        private void txtCliCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //envío a la clase ValidacionF parámetro e para validar si solo ingresé nros.
            //devuelve verd o falso
            vf.soloNumeros(e); 
        }        
    }
}
