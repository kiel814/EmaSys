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

namespace CapaPresentacion
{
    public partial class FrmProveedores : Form
    {
        //Llamo a la clase para validar numeros
        ValidacionF vf = new ValidacionF();

        //creo 2 variables para saber si voy a registrar un proveedor o lo voy a editar
        //bool es verdadera o falsa
        private bool IsNuevo = false;

        private bool IsEditar = false;               

        public FrmProveedores()
        {
            InitializeComponent();
            //muestra mensaje de ayuda en el txt
            this.ttMensaje.SetToolTip(this.txtProCodigo, "Ingrese el Código de Proveedor");
            this.ttMensaje.SetToolTip(this.txtProNombr, "Ingrese el Nombre del Proveedor");
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

        //Limpiar todos los controles del formulario - Sólo los textbox se limpian -
        private void Limpiar()
        {
            this.txtProCodigo.Text = string.Empty;
            this.txtProNombr.Text = string.Empty;            
            this.txtProveedorID.Text = string.Empty;
            this.txtProNomch.Text = string.Empty;
            this.txtProDirec.Text = string.Empty;
            this.txtProTelef.Text = string.Empty;
            this.txtProFax.Text = string.Empty;
            this.txtProLocal.Text = string.Empty;
            this.txtProProvi.Text = string.Empty;
            this.txtProCPost.Text = string.Empty;
            this.txtProCIva.Text = string.Empty;
            this.txtProCuit.Text = string.Empty;
            this.txtProRamo.Text = string.Empty;
            this.txtProServi.Text = string.Empty;
            this.txtProIngbr.Text = string.Empty;
            this.txtProGanan.Text = string.Empty;
            this.txtProNIngb.Text = string.Empty;
            this.txtProActiv.Text = string.Empty;
            this.cboProActiv.Text = string.Empty;
            this.txtProAgper.Text = string.Empty;
            this.txtProGrupo.Text = string.Empty;
            //this.txtProFeins.Text = string.Empty;
            this.txtProAciva.Text = string.Empty;
            this.txtProCai.Text = string.Empty;
            //this.txtProFecai.Text = string.Empty;
            this.txtProAduan.Text = string.Empty;
            this.txtProCBanc.Text = string.Empty;
            this.txtProDespa.Text = string.Empty;
            this.txtProOk.Text = string.Empty;
            this.txtProMail.Text = string.Empty;
            this.txtProActivDesc.Text = string.Empty;
            this.txtProPais.Text = string.Empty;
          //  this.cboProPais.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        //recibe parametro valor que puede ser verd o falso
        //si recibo true entonces las cajas de textos van a estar habilitadas
        private void Habilitar(bool valor)
        {
            this.txtProCodigo.ReadOnly = !valor;
            this.txtProNombr.ReadOnly = !valor;
            this.txtProveedorID.ReadOnly = !valor;
            this.txtProNomch.ReadOnly = !valor;
            this.txtProDirec.ReadOnly = !valor;
            this.txtProTelef.ReadOnly = !valor;
            this.txtProFax.ReadOnly = !valor;
            this.txtProLocal.ReadOnly = !valor;
            this.txtProProvi.ReadOnly = !valor;
            this.txtProCPost.ReadOnly = !valor;
            //this.txtProCIva.ReadOnly = !valor;
            this.txtProCIva.Enabled = false;
            this.txtProCuit.ReadOnly = !valor;
            //this.txtProRamo.ReadOnly = !valor;
            this.txtProRamo.Enabled = false;
            //this.txtProServi.ReadOnly = !valor;
            this.txtProServi.Enabled = false;
            //this.txtProIngbr.ReadOnly = !valor;
            this.txtProIngbr.Enabled = false;
            //this.txtProGanan.ReadOnly = !valor;
            this.txtProGanan.Enabled = false;
            this.txtProNIngb.ReadOnly = !valor;
            this.txtProActiv.ReadOnly = !valor;
            this.cboProActiv.Enabled = false;
            //this.txtProAgper.ReadOnly = !valor;
            this.txtProAgper.Enabled = false;
            this.txtProGrupo.ReadOnly = !valor;
            //this.txtProFeins.ReadOnly = !valor;
            this.txtProAciva.ReadOnly = !valor;
            this.txtProCai.ReadOnly = !valor;
            //this.txtProFecai.ReadOnly = !valor;
            this.txtProAduan.ReadOnly = !valor;
            this.txtProCBanc.ReadOnly = !valor;
            //this.txtProDespa.ReadOnly = !valor;
            this.txtProDespa.Enabled = false;
            this.txtProOk.ReadOnly = !valor;
            this.txtProMail.ReadOnly = !valor;
            this.txtProActivDesc.ReadOnly = !valor;
            this.txtProPais.ReadOnly = !valor;
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
            //columna 1 es ProveedorID que no necesito visualizar
            this.dataListado.Columns[1].Visible = false;

            //fal
            //columna 28 es ProOk que no necesito visualizar
            this.dataListado.Columns[28].Visible = false;
            //Columna 20 es ProGrupo
            dataListado.Columns[20].Visible = false;
            //Columna 25 es ProAduan
            dataListado.Columns[25].Visible = false;
            //Columna 22 es ProAciva
            dataListado.Columns[22].Visible = false;

            dataListado.Columns[2].HeaderText = "CódigoFox";
            dataListado.Columns[3].HeaderText = "Nombre";
            dataListado.Columns[4].HeaderText = "Nombre para Cheque";
            dataListado.Columns[5].HeaderText = "Domicilio";
            dataListado.Columns[6].HeaderText = "Teléfono";
            dataListado.Columns[7].HeaderText = "Fax";
            dataListado.Columns[8].HeaderText = "Localidad";
            dataListado.Columns[9].HeaderText = "Provincia";
            dataListado.Columns[10].HeaderText = "Cód.Postal";
            dataListado.Columns[11].HeaderText = "Cond.IVA";
            dataListado.Columns[12].HeaderText = "CUIT";
            dataListado.Columns[13].HeaderText = "Ramo";
            dataListado.Columns[14].HeaderText = "Servicios";
            dataListado.Columns[15].HeaderText = "Ing.Brutos";
            dataListado.Columns[16].HeaderText = "Ganancias";
            dataListado.Columns[17].HeaderText = "Ing.Brutos N°";
            dataListado.Columns[18].HeaderText = "Actividad";
            dataListado.Columns[19].HeaderText = "Ag.Perc";
            //dataListado.Columns[20].HeaderText = "Grupo";
            dataListado.Columns[21].HeaderText = "Feins";
            //dataListado.Columns[22].HeaderText = "Aciva";
            dataListado.Columns[23].HeaderText = "CAI N°";
            dataListado.Columns[24].HeaderText = "Fecha Venc.CAI";
            //dataListado.Columns[25].HeaderText = "Aduana";
            dataListado.Columns[26].HeaderText = "Cta.Bancaria";
            dataListado.Columns[27].HeaderText = "Despacho";
            dataListado.Columns[29].HeaderText = "Mail";
            dataListado.Columns[30].HeaderText = "País";
            dataListado.Columns[31].HeaderText = "Descripción Actividad";
        }

        //Fal - Método Ordenar las columnas dentro del dataListado
        private void OrdenarColumnas()
        {          
            dataListado.Columns["ProCodigo"].DisplayIndex = 2;
            dataListado.Columns["ProNombr"].DisplayIndex = 3;
            dataListado.Columns["ProNomch"].DisplayIndex = 4;
            dataListado.Columns["ProDirec"].DisplayIndex = 5;
            dataListado.Columns["ProTelef"].DisplayIndex = 6;
            dataListado.Columns["ProMail"].DisplayIndex = 7;
            dataListado.Columns["ProFax"].DisplayIndex = 8;
            dataListado.Columns["ProLocal"].DisplayIndex = 9;
            dataListado.Columns["ProProvi"].DisplayIndex = 10;
            dataListado.Columns["ProPais"].DisplayIndex = 11;
            dataListado.Columns["ProCPost"].DisplayIndex = 12;
            dataListado.Columns["ProCIva"].DisplayIndex = 13;
            dataListado.Columns["ProCuit"].DisplayIndex = 14;
            dataListado.Columns["ProRamo"].DisplayIndex = 15;
            dataListado.Columns["ProServi"].DisplayIndex = 16;
            dataListado.Columns["ProIngbr"].DisplayIndex = 17;
            dataListado.Columns["ProGanan"].DisplayIndex = 18;
            dataListado.Columns["ProNIngb"].DisplayIndex = 19;
            dataListado.Columns["ProActiv"].DisplayIndex = 20;
            dataListado.Columns["ProActivDesc"].DisplayIndex = 21;
            dataListado.Columns["ProAgper"].DisplayIndex = 22;
            dataListado.Columns["ProGrupo"].Visible = false;
            dataListado.Columns["ProFeins"].DisplayIndex = 24;
            dataListado.Columns["ProAciva"].DisplayIndex = 25;
            dataListado.Columns["ProCai"].DisplayIndex = 26;
            dataListado.Columns["ProFecai"].DisplayIndex = 27;
            dataListado.Columns["ProAduan"].Visible = false ;
            dataListado.Columns["ProCBanc"].DisplayIndex = 29;
            dataListado.Columns["ProDespa"].DisplayIndex = 30;
            
            // dataListado.Columns["ClienteID"].Visible = false;
        }

        //Método Mostrar todos los registros de la tabla Proveedores
        private void Mostrar()
        {
            //muestra todos los registros de la tabla Proveedores
            this.dataListado.DataSource = NProveedores.Mostrar();

            //Fal - Para ajustar tamaño de columnas y celdas           
            dataListado.AutoResizeColumns();
            dataListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.OcultarColumnas();
            //Fal
            this.OrdenarColumnas();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProveedores.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarCuit
        private void BuscarCuit()
        {
            this.dataListado.DataSource = NProveedores.BuscarCuit(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarProCodigo
        private void BuscarProCodigo()
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
                MessageBox.Show("Debe Ingresar el Código de Proveedor");
                this.txtBuscar.Focus();
            }
            //
            this.dataListado.DataSource = NProveedores.BuscarProCodigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {          
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            //las cajas de textos no están habilitadas o son de sólo lectura
            this.Habilitar(false);

            this.dtProFeins.Visible = false;
            this.dtProFecai.Visible = false;
            //this.mskProFeins.Visible = true;
            this.mskProFecai.Visible = true;

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
                this.BuscarProCodigo();
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
            //fal habilito el datetimepicker y dehabilito el txt, es para evitar el error
            //en Sql tiene null en esos campos de fecha y el datetimepicker no los acepta
            //this.dtProFeins.Visible = true;
            this.dtProFecai.Visible = true;            
            this.mskProFeins.Visible = false;
            this.mskProFecai.Visible = false;

            //para habilitar las cajas de textos donde el usuario carga datos
            this.Habilitar(true);
            //this.txtProNombr.Focus();
            this.txtProCodigo.Focus();
            //Fal
            this.txtProCIva.Enabled = true;
            this.txtProAgper.Enabled = true;
            this.txtProGanan.Enabled = true;
            this.txtProDespa.Enabled = true;
            this.txtProServi.Enabled = true;
            this.txtProRamo.Enabled = true;
            this.txtProIngbr.Enabled = true;
            this.cboProActiv.Enabled = true;
           // this.cboProPais.Enabled = true;
            this.txtProActiv.Enabled = false;
          //  this.txtProPais.Enabled = false;
          //  this.txtProPais.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                //Debo evaluar que el campo ProNombr y ProCodigo no pueden ser null
                if (this.txtProNombr.Text == string.Empty || this.txtProCodigo.Text == string.Empty || this.txtProCuit.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtProNombr, "Ingrese el Nombre del Proveedor");                    
                    errorIcono.SetError(txtProCodigo, "Ingrese el Código de Proveedor");
                    errorIcono.SetError(txtProCuit, "Ingrese el CUIT del Proveedor");
                }
                else
                {
                    //Veo si el usuario quiere ingresar un nuevo registro
                    if (this.IsNuevo)
                    {
                        //rpta va a verificar si se insertó o modificó un registro
                        rpta = NProveedores.Insertar(this.txtProCodigo.Text.Trim(), this.txtProNombr.Text.Trim().ToUpper(),
                            this.txtProNomch.Text.Trim().ToUpper(), this.txtProDirec.Text.Trim().ToUpper(), this.txtProTelef.Text.Trim(),
                            this.txtProFax.Text.Trim(), this.txtProLocal.Text.Trim().ToUpper(), this.txtProProvi.Text.Trim().ToUpper(),
                            this.txtProCPost.Text.Trim(), this.txtProCIva.Text.Trim(), this.txtProCuit.Text.Trim(),
                            this.txtProRamo.Text.Trim(), this.txtProServi.Text.Trim(), this.txtProIngbr.Text.Trim(),
                            this.txtProGanan.Text.Trim(), this.txtProNIngb.Text.Trim(), this.txtProActiv.Text.Trim(),
                            this.txtProAgper.Text.Trim(), this.txtProGrupo.Text.Trim(), dtProFeins.Value, this.txtProAciva.Text.Trim(),
                            this.txtProCai.Text.Trim(), dtProFecai.Value, this.txtProAduan.Text.Trim(), this.txtProCBanc.Text.Trim(),
                            this.txtProDespa.Text.Trim(), this.txtProOk.Text.Trim(), this.txtProMail.Text.Trim(),
                            this.txtProActivDesc.Text.Trim(), this.txtProPais.Text.Trim());
                    }
                    else
                    {
                        rpta = NProveedores.Editar(Convert.ToInt32(this.txtProveedorID.Text),
                            this.txtProCodigo.Text.Trim(), this.txtProNombr.Text.Trim().ToUpper(),
                            this.txtProNomch.Text.Trim().ToUpper(), this.txtProDirec.Text.Trim().ToUpper(), this.txtProTelef.Text.Trim(),
                            this.txtProFax.Text.Trim(), this.txtProLocal.Text.Trim().ToUpper(), this.txtProProvi.Text.Trim().ToUpper(),
                            this.txtProCPost.Text.Trim(), this.txtProCIva.Text.Trim(), this.txtProCuit.Text.Trim(),
                            this.txtProRamo.Text.Trim(), this.txtProServi.Text.Trim(), this.txtProIngbr.Text.Trim(),
                            this.txtProGanan.Text.Trim(), this.txtProNIngb.Text.Trim(), this.txtProActiv.Text.Trim(),
                            this.txtProAgper.Text.Trim(), this.txtProGrupo.Text.Trim(), dtProFeins.Value, this.txtProAciva.Text.Trim(),
                            this.txtProCai.Text.Trim(), dtProFecai.Value, this.txtProAduan.Text.Trim(), this.txtProCBanc.Text.Trim(),
                            this.txtProDespa.Text.Trim(), this.txtProOk.Text.Trim(), this.txtProMail.Text.Trim(),
                            this.txtProActivDesc.Text.Trim(), this.txtProPais.Text.Trim());
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //para editar pregunto si el txt ProveedorID no está vacio
            if (!this.txtProveedorID.Text.Equals(""))
            {
                this.IsEditar = true;
                //llamo al método botones y habilitar para habilitar los botones
                this.Botones();
                this.Habilitar(true);
                //fal habilito el datetimepicker y dehabilito el txt, es para evitar el error
                //en Sql tiene null en esos campos de fecha y el datetimepicker no los acepta
                //this.dtProFeins.Visible = true;
                this.dtProFecai.Visible = true;              
                this.mskProFeins.Visible = false;
                this.mskProFecai.Visible = false;
                //Fal
                this.txtProCIva.Enabled = true;
                this.txtProAgper.Enabled = true;
                this.txtProGanan.Enabled = true;
                this.txtProDespa.Enabled = true;
                this.txtProServi.Enabled = true;
                this.txtProRamo.Enabled = true;
                this.txtProIngbr.Enabled = true;

              //  this.cboProActiv.Enabled = true;                
              //  this.txtProActiv.Enabled = false;                
              //  this.txtProActivDesc.Visible = false;
              //  this.cboProPais.Enabled = true;                
              //  this.txtProPais.Visible = false;
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
            this.txtProCIva.Enabled = false;
            this.txtProAgper.Enabled = false;
            this.txtProGanan.Enabled = false;
            this.txtProDespa.Enabled = false;
            this.txtProServi.Enabled = false;
            this.txtProRamo.Enabled = false;
            this.txtProIngbr.Enabled = false;
            this.cboProActiv.Enabled = false;
          //  this.cboProPais.Enabled = false;
            this.btnNuevo.Focus();
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
                            //Codigo es string pero NProveedores.Eliminar espera un int, entonces convierto
                            Rpta = NProveedores.Eliminar(Convert.ToInt32(Codigo));

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
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtProveedorID.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProveedorID"].Value);
            this.txtProCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCodigo"].Value);
            this.txtProNombr.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProNombr"].Value);
            this.txtProNomch.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProNomch"].Value);
            this.txtProDirec.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProDirec"].Value);
            this.txtProTelef.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProTelef"].Value);
            this.txtProFax.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProFax"].Value);
            this.txtProLocal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProLocal"].Value);
            this.txtProProvi.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProProvi"].Value);
            this.txtProCPost.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCPost"].Value);
            this.txtProCIva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCIva"].Value);            
            this.txtProCuit.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCuit"].Value);
            this.txtProRamo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProRamo"].Value);
            this.txtProServi.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProServi"].Value);
            this.txtProIngbr.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProIngbr"].Value);
            this.txtProGanan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProGanan"].Value);
            this.txtProNIngb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProNIngb"].Value);
            this.txtProActiv.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProActiv"].Value);
            this.txtProAgper.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProAgper"].Value);
            this.txtProGrupo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProGrupo"].Value);
            //fal habilito y deshabilito los controles para evitar el error de Null, no puede ser 
            //convertido a fecha en el datetimepicker
            this.dtProFeins.Visible = false;
            this.dtProFecai.Visible = false;            
            //this.mskProFeins.Visible = true;
            this.mskProFecai.Visible = true;            
            this.mskProFeins.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProFeins"].Value);
            this.mskProFecai.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProFecai"].Value);                       
            this.txtProAciva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProAciva"].Value);
            this.txtProCai.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCai"].Value);
            //if (!this.dtProFecai.Text.Equals(""))
            // {            
            //    this.dtProFecai.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["ProFecai"].Value);                
            //}
            this.txtProAduan.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProAduan"].Value);
            this.txtProCBanc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProCBanc"].Value);
            this.txtProDespa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProDespa"].Value);
            this.txtProOk.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProOk"].Value);
            this.txtProMail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProMail"].Value);
            this.txtProActivDesc.Visible = true;
            this.txtProActivDesc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProActivDesc"].Value);
           // this.txtProPais.Visible = true;
            this.txtProPais.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ProPais"].Value);

            //selecciono los valores y paso al tap page de mantenimiento para ver lo seleccionado
            this.tabControl1.SelectedIndex = 1;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtProProvi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtProCPost_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtProFeins_ValueChanged(object sender, EventArgs e)
        {
            //this.dtProFeins.CustomFormat = "dd/MM/yyyy";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteProveedores frm = new FrmReporteProveedores();
            frm.ShowDialog();
        }

        private void btnImprimirCodProv_Click(object sender, EventArgs e)
        {
            FrmCodProveed frm = new FrmCodProveed();
            frm.ShowDialog();
        }

        private void btnImprimirNombreProv_Click(object sender, EventArgs e)
        {
            FrmNombreProveed frm = new FrmNombreProveed();
            frm.ShowDialog();
        }

        private void txtProMail_Validating(object sender, CancelEventArgs e)
        {
            string texto = txtProMail.Text;
            bool verificar = texto.Contains('@') && texto.Contains(".com");
            if (verificar == true)
            {
            }
            else
            {
                if (this.txtProMail.Text != "")
                {
                    MessageBox.Show("Ingrese un Mail válido");
                    this.txtProMail.Focus();
                }
            }
        }

        private void txtProCuit_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtProCuit.Text != "")
            {
                CUIT CadenaCuit = new CUIT();
                CadenaCuit.CUITSinFormato = txtProCuit.Text;

                txtProCuit.Text = CadenaCuit.CUITFormateado;

                if (this.txtProCuit.Text.Equals(""))
                {
                    MessageBox.Show("CUIT Inválido - Reingrese CUIT");
                    this.txtProCuit.Focus();
                }
            }
            else
            {
                this.txtProCuit.Text = "88-88888888-8";
            }
        }

        private void txtProCuit_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtProCIva.Enabled = false;
                this.txtProAgper.Enabled = false;
                this.txtProGanan.Enabled = false;
                this.txtProDespa.Enabled = false;
                this.txtProServi.Enabled = false;
                this.txtProRamo.Enabled = false;
                this.txtProIngbr.Enabled = false;
                this.cboProActiv.Enabled = false;
              //  this.cboProPais.Enabled = false;
            }
        }

        private void txtProCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProCodigo_Validating(object sender, CancelEventArgs e)
        {
            //fal- Controlar que el cód.proveedor no exista en la tabla de Proveedores (Cod.Fox)                                   

            this.dataListado.DataSource = NProveedores.BuscarProCodigo(this.txtProCodigo.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            if (Convert.ToString(dataListado.Rows.Count) != "0")
            {
                if (txtProCodigo.Text != "")
                {
                    MessageBox.Show("Este Código de Proveedor ya Existe");
                    //hago cancel
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    //para deshabilitar todas las cajas de texto mando false al método Habilitar
                    //y dejarlas como sólo lectura
                    this.Habilitar(false);
                    //Fal
                    this.txtProCIva.Enabled = false;
                    this.txtProAgper.Enabled = false;
                    this.txtProGanan.Enabled = false;
                    this.txtProDespa.Enabled = false;
                    this.txtProServi.Enabled = false;
                    this.txtProRamo.Enabled = false;
                    this.txtProIngbr.Enabled = false;
                    this.cboProActiv.Enabled = false;
                   // this.cboProPais.Enabled = false;
                    this.txtProCodigo.Focus();
                }               
            }
        }

        private void txtProCodigo_Leave(object sender, EventArgs e)
        {
            //fal- Completar con 0's a la izq del código ingresado
            int totalWidth = 4;
            int cadena = totalWidth - Convert.ToInt32(txtProCodigo.Text.Length);

            if (cadena == 1)
            {
                txtProCodigo.Text = "0" + txtProCodigo.Text;
            }
            else if (cadena == 2)
            {
                txtProCodigo.Text = "00" + txtProCodigo.Text;
            }
            else if (cadena == 3)
            {
                txtProCodigo.Text = "000" + txtProCodigo.Text;
            }
        }

        private void cboProActiv_Leave(object sender, EventArgs e)
        {               
            //this.txtProActiv.Text = cboProActiv.Text.Substring(0, 2).Trim();
            //this.txtProActivDesc.Text = cboProActiv.Text.Substring(4, 53 ).Trim();
        }

        private void cboProActiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtProActiv.Text = cboProActiv.Text.Substring(0, 2).Trim();

            String ActivDesc = this.cboProActiv.Text;
            ActivDesc = ActivDesc.Substring(4, ActivDesc.Length - 4);
            this.txtProActivDesc.Text = ActivDesc;

            //this.txtProActivDesc.Text = cboProActiv.Text.Substring(4, 50).Trim();
        }

       // private void cboProPais_Leave(object sender, EventArgs e)
       // {
            //this.txtProPais.Text = cboProPais.Text.Trim();
       // }

       // private void cboProPais_SelectedIndexChanged(object sender, EventArgs e)
       // {
       //     this.txtProPais.Text = cboProPais.Text.Trim();
       // }

       // private void cboProPais_Click(object sender, EventArgs e)
       // {            
       //     this.cboProPais.Enabled = true;
       //     this.txtProPais.Visible = false;
       // }

        private void cboProActiv_Click(object sender, EventArgs e)
        {
            this.cboProActiv.Enabled = true;
            this.txtProActiv.Enabled = false;
            this.txtProActivDesc.Visible = false;            
        }

        private void txtProActivDesc_Click(object sender, EventArgs e)
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.cboProActiv.Enabled = true;
                this.txtProActiv.Enabled = false;
                this.txtProActivDesc.Visible = false;
                this.txtProActiv.Visible = false;
            }               
        }

       // private void txtProPais_Click(object sender, EventArgs e)
       // {
        //    if (this.IsNuevo || this.IsEditar)
           // {             
         //       this.cboProPais.Enabled = true;                
           //     this.txtProPais.Visible = false;
           // }
        //}

        private void txtProCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //envío a la clase ValidacionF parámetro e para validar si solo ingresé nros.
            //devuelve verd o falso
            vf.soloNumeros(e);
        }
    }
}
