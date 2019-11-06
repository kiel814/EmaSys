namespace CapaPresentacion
{
    partial class FrmFacturasProveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabFacturaAsientos = new System.Windows.Forms.TabControl();
			this.tabListado = new System.Windows.Forms.TabPage();
			this.BtnRefresh = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.TxtCodigoLista = new System.Windows.Forms.TextBox();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.DgvListado = new System.Windows.Forms.DataGridView();
			this.BtnEditar = new System.Windows.Forms.Button();
			this.tabFactura = new System.Windows.Forms.TabPage();
			this.BtnIIBB = new System.Windows.Forms.Button();
			this.LblFacturaOriginal = new System.Windows.Forms.Label();
			this.TxtDocumentoOriginal = new System.Windows.Forms.TextBox();
			this.TxtSucursalOriginal = new System.Windows.Forms.TextBox();
			this.CbbTipoFacturaOriginal = new System.Windows.Forms.ComboBox();
			this.txtDespacho = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkMaterial = new System.Windows.Forms.CheckBox();
			this.lblActividad = new System.Windows.Forms.Label();
			this.cbbActividad = new System.Windows.Forms.ComboBox();
			this.txtPorcentajePercepIVA = new System.Windows.Forms.TextBox();
			this.txtPorcentajeIVA = new System.Windows.Forms.TextBox();
			this.BtnAsientos = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.LblDocumento = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.txtExento = new System.Windows.Forms.TextBox();
			this.txtNeto = new System.Windows.Forms.TextBox();
			this.txtMontoPercepIVA = new System.Windows.Forms.TextBox();
			this.txtMontoIIBB = new System.Windows.Forms.TextBox();
			this.txtMontoIVA = new System.Windows.Forms.TextBox();
			this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
			this.dtpCarga = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.txtSucursal = new System.Windows.Forms.TextBox();
			this.cbbTipoFactura = new System.Windows.Forms.ComboBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.tabAsiento = new System.Windows.Forms.TabPage();
			this.CbbMoneda = new System.Windows.Forms.ComboBox();
			this.BtnGuardar = new System.Windows.Forms.Button();
			this.LblTotalHaber = new System.Windows.Forms.Label();
			this.LblTotalDebe = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.PnlLineas = new System.Windows.Forms.Panel();
			this.btnAgregarAsiento = new System.Windows.Forms.Button();
			this.LblTituloHaber = new System.Windows.Forms.Label();
			this.LblTituloDebe = new System.Windows.Forms.Label();
			this.LblTituloDescripcion = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.TxtObservacionesLD = new System.Windows.Forms.TextBox();
			this.DtpAsiento = new System.Windows.Forms.DateTimePicker();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnNuevo = new System.Windows.Forms.Button();
			this.LblTitle = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabFacturaAsientos.SuspendLayout();
			this.tabListado.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
			this.tabFactura.SuspendLayout();
			this.tabAsiento.SuspendLayout();
			this.PnlLineas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabFacturaAsientos
			// 
			this.tabFacturaAsientos.Controls.Add(this.tabListado);
			this.tabFacturaAsientos.Controls.Add(this.tabFactura);
			this.tabFacturaAsientos.Controls.Add(this.tabAsiento);
			this.tabFacturaAsientos.Location = new System.Drawing.Point(12, 112);
			this.tabFacturaAsientos.Name = "tabFacturaAsientos";
			this.tabFacturaAsientos.SelectedIndex = 0;
			this.tabFacturaAsientos.Size = new System.Drawing.Size(740, 423);
			this.tabFacturaAsientos.TabIndex = 37;
			// 
			// tabListado
			// 
			this.tabListado.Controls.Add(this.BtnRefresh);
			this.tabListado.Controls.Add(this.label21);
			this.tabListado.Controls.Add(this.TxtCodigoLista);
			this.tabListado.Controls.Add(this.btnEliminar);
			this.tabListado.Controls.Add(this.DgvListado);
			this.tabListado.Controls.Add(this.BtnEditar);
			this.tabListado.Location = new System.Drawing.Point(4, 22);
			this.tabListado.Name = "tabListado";
			this.tabListado.Size = new System.Drawing.Size(732, 397);
			this.tabListado.TabIndex = 2;
			this.tabListado.Text = "Listado";
			this.tabListado.UseVisualStyleBackColor = true;
			// 
			// BtnRefresh
			// 
			this.BtnRefresh.Location = new System.Drawing.Point(17, 77);
			this.BtnRefresh.Name = "BtnRefresh";
			this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
			this.BtnRefresh.TabIndex = 60;
			this.BtnRefresh.Text = "Actualizar";
			this.BtnRefresh.UseVisualStyleBackColor = true;
			this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(14, 13);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(40, 13);
			this.label21.TabIndex = 59;
			this.label21.Text = "Codigo";
			// 
			// TxtCodigoLista
			// 
			this.TxtCodigoLista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.TxtCodigoLista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.TxtCodigoLista.Location = new System.Drawing.Point(17, 29);
			this.TxtCodigoLista.MaxLength = 4;
			this.TxtCodigoLista.Name = "TxtCodigoLista";
			this.TxtCodigoLista.Size = new System.Drawing.Size(66, 20);
			this.TxtCodigoLista.TabIndex = 58;
			this.TxtCodigoLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoLista_KeyDown);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(655, 77);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 42;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// DgvListado
			// 
			this.DgvListado.AllowUserToAddRows = false;
			this.DgvListado.AllowUserToDeleteRows = false;
			this.DgvListado.AllowUserToOrderColumns = true;
			this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvListado.Location = new System.Drawing.Point(3, 106);
			this.DgvListado.MultiSelect = false;
			this.DgvListado.Name = "DgvListado";
			this.DgvListado.ReadOnly = true;
			this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvListado.Size = new System.Drawing.Size(726, 281);
			this.DgvListado.TabIndex = 0;
			// 
			// BtnEditar
			// 
			this.BtnEditar.Location = new System.Drawing.Point(574, 77);
			this.BtnEditar.Name = "BtnEditar";
			this.BtnEditar.Size = new System.Drawing.Size(75, 23);
			this.BtnEditar.TabIndex = 41;
			this.BtnEditar.Text = "Editar";
			this.BtnEditar.UseVisualStyleBackColor = true;
			this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
			// 
			// tabFactura
			// 
			this.tabFactura.Controls.Add(this.BtnIIBB);
			this.tabFactura.Controls.Add(this.LblFacturaOriginal);
			this.tabFactura.Controls.Add(this.TxtDocumentoOriginal);
			this.tabFactura.Controls.Add(this.TxtSucursalOriginal);
			this.tabFactura.Controls.Add(this.CbbTipoFacturaOriginal);
			this.tabFactura.Controls.Add(this.txtDespacho);
			this.tabFactura.Controls.Add(this.label10);
			this.tabFactura.Controls.Add(this.chkMaterial);
			this.tabFactura.Controls.Add(this.lblActividad);
			this.tabFactura.Controls.Add(this.cbbActividad);
			this.tabFactura.Controls.Add(this.txtPorcentajePercepIVA);
			this.tabFactura.Controls.Add(this.txtPorcentajeIVA);
			this.tabFactura.Controls.Add(this.BtnAsientos);
			this.tabFactura.Controls.Add(this.label15);
			this.tabFactura.Controls.Add(this.txtObservaciones);
			this.tabFactura.Controls.Add(this.label14);
			this.tabFactura.Controls.Add(this.label13);
			this.tabFactura.Controls.Add(this.label12);
			this.tabFactura.Controls.Add(this.label11);
			this.tabFactura.Controls.Add(this.label9);
			this.tabFactura.Controls.Add(this.label8);
			this.tabFactura.Controls.Add(this.label7);
			this.tabFactura.Controls.Add(this.label6);
			this.tabFactura.Controls.Add(this.label5);
			this.tabFactura.Controls.Add(this.label4);
			this.tabFactura.Controls.Add(this.LblDocumento);
			this.tabFactura.Controls.Add(this.label2);
			this.tabFactura.Controls.Add(this.label1);
			this.tabFactura.Controls.Add(this.txtProvincia);
			this.tabFactura.Controls.Add(this.txtTotal);
			this.tabFactura.Controls.Add(this.txtExento);
			this.tabFactura.Controls.Add(this.txtNeto);
			this.tabFactura.Controls.Add(this.txtMontoPercepIVA);
			this.tabFactura.Controls.Add(this.txtMontoIIBB);
			this.tabFactura.Controls.Add(this.txtMontoIVA);
			this.tabFactura.Controls.Add(this.dtpVencimiento);
			this.tabFactura.Controls.Add(this.dtpCarga);
			this.tabFactura.Controls.Add(this.dtpFechaFactura);
			this.tabFactura.Controls.Add(this.txtDocumento);
			this.tabFactura.Controls.Add(this.txtSucursal);
			this.tabFactura.Controls.Add(this.cbbTipoFactura);
			this.tabFactura.Controls.Add(this.txtNombre);
			this.tabFactura.Controls.Add(this.txtCodigo);
			this.tabFactura.Location = new System.Drawing.Point(4, 22);
			this.tabFactura.Name = "tabFactura";
			this.tabFactura.Padding = new System.Windows.Forms.Padding(3);
			this.tabFactura.Size = new System.Drawing.Size(732, 397);
			this.tabFactura.TabIndex = 0;
			this.tabFactura.Text = "Factura";
			this.tabFactura.UseVisualStyleBackColor = true;
			// 
			// BtnIIBB
			// 
			this.BtnIIBB.Location = new System.Drawing.Point(78, 224);
			this.BtnIIBB.Name = "BtnIIBB";
			this.BtnIIBB.Size = new System.Drawing.Size(59, 21);
			this.BtnIIBB.TabIndex = 86;
			this.BtnIIBB.Text = "Editar...";
			this.BtnIIBB.UseVisualStyleBackColor = true;
			this.BtnIIBB.Click += new System.EventHandler(this.BtnIIBB_Click);
			// 
			// LblFacturaOriginal
			// 
			this.LblFacturaOriginal.AutoSize = true;
			this.LblFacturaOriginal.Location = new System.Drawing.Point(75, 319);
			this.LblFacturaOriginal.Name = "LblFacturaOriginal";
			this.LblFacturaOriginal.Size = new System.Drawing.Size(43, 13);
			this.LblFacturaOriginal.TabIndex = 85;
			this.LblFacturaOriginal.Text = "Factura";
			// 
			// TxtDocumentoOriginal
			// 
			this.TxtDocumentoOriginal.Enabled = false;
			this.TxtDocumentoOriginal.Location = new System.Drawing.Point(190, 334);
			this.TxtDocumentoOriginal.MaxLength = 8;
			this.TxtDocumentoOriginal.Name = "TxtDocumentoOriginal";
			this.TxtDocumentoOriginal.Size = new System.Drawing.Size(69, 20);
			this.TxtDocumentoOriginal.TabIndex = 84;
			this.TxtDocumentoOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtDocumentoOriginal.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtDocumentoOriginal.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtDocumentoOriginal.Leave += new System.EventHandler(this.TxtDocumentoOriginal_Leave);
			// 
			// TxtSucursalOriginal
			// 
			this.TxtSucursalOriginal.Enabled = false;
			this.TxtSucursalOriginal.Location = new System.Drawing.Point(135, 334);
			this.TxtSucursalOriginal.MaxLength = 5;
			this.TxtSucursalOriginal.Name = "TxtSucursalOriginal";
			this.TxtSucursalOriginal.Size = new System.Drawing.Size(47, 20);
			this.TxtSucursalOriginal.TabIndex = 83;
			this.TxtSucursalOriginal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtSucursalOriginal.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtSucursalOriginal.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtSucursalOriginal.Leave += new System.EventHandler(this.TxtSucursalOriginal_Leave);
			// 
			// CbbTipoFacturaOriginal
			// 
			this.CbbTipoFacturaOriginal.BackColor = System.Drawing.SystemColors.Window;
			this.CbbTipoFacturaOriginal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbbTipoFacturaOriginal.Enabled = false;
			this.CbbTipoFacturaOriginal.FormattingEnabled = true;
			this.CbbTipoFacturaOriginal.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            " "});
			this.CbbTipoFacturaOriginal.Location = new System.Drawing.Point(78, 333);
			this.CbbTipoFacturaOriginal.MaxLength = 1;
			this.CbbTipoFacturaOriginal.Name = "CbbTipoFacturaOriginal";
			this.CbbTipoFacturaOriginal.Size = new System.Drawing.Size(51, 21);
			this.CbbTipoFacturaOriginal.TabIndex = 82;
			// 
			// txtDespacho
			// 
			this.txtDespacho.Enabled = false;
			this.txtDespacho.Location = new System.Drawing.Point(334, 274);
			this.txtDespacho.Name = "txtDespacho";
			this.txtDespacho.Size = new System.Drawing.Size(205, 20);
			this.txtDespacho.TabIndex = 81;
			this.txtDespacho.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtDespacho.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtDespacho.Leave += new System.EventHandler(this.TextboxToUpper);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(331, 258);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(114, 13);
			this.label10.TabIndex = 80;
			this.label10.Text = "Despacho Importación";
			// 
			// chkMaterial
			// 
			this.chkMaterial.AutoSize = true;
			this.chkMaterial.Enabled = false;
			this.chkMaterial.Location = new System.Drawing.Point(476, 147);
			this.chkMaterial.Name = "chkMaterial";
			this.chkMaterial.Size = new System.Drawing.Size(63, 17);
			this.chkMaterial.TabIndex = 16;
			this.chkMaterial.Text = "Material";
			this.chkMaterial.UseVisualStyleBackColor = true;
			// 
			// lblActividad
			// 
			this.lblActividad.AutoSize = true;
			this.lblActividad.Location = new System.Drawing.Point(385, 199);
			this.lblActividad.Name = "lblActividad";
			this.lblActividad.Size = new System.Drawing.Size(51, 13);
			this.lblActividad.TabIndex = 79;
			this.lblActividad.Text = "Actividad";
			// 
			// cbbActividad
			// 
			this.cbbActividad.BackColor = System.Drawing.SystemColors.Window;
			this.cbbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbActividad.Enabled = false;
			this.cbbActividad.FormattingEnabled = true;
			this.cbbActividad.Items.AddRange(new object[] {
            "Industrial",
            "Servicio"});
			this.cbbActividad.Location = new System.Drawing.Point(442, 199);
			this.cbbActividad.MaxLength = 10;
			this.cbbActividad.Name = "cbbActividad";
			this.cbbActividad.Size = new System.Drawing.Size(97, 21);
			this.cbbActividad.TabIndex = 18;
			// 
			// txtPorcentajePercepIVA
			// 
			this.txtPorcentajePercepIVA.Enabled = false;
			this.txtPorcentajePercepIVA.Location = new System.Drawing.Point(78, 199);
			this.txtPorcentajePercepIVA.Name = "txtPorcentajePercepIVA";
			this.txtPorcentajePercepIVA.Size = new System.Drawing.Size(59, 20);
			this.txtPorcentajePercepIVA.TabIndex = 12;
			this.txtPorcentajePercepIVA.Text = "2,00";
			this.txtPorcentajePercepIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPorcentajePercepIVA.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtPorcentajePercepIVA.TextChanged += new System.EventHandler(this.txtPorcentajePercepIVA_TextChanged);
			this.txtPorcentajePercepIVA.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtPorcentajePercepIVA.Leave += new System.EventHandler(this.txtPorcentajePercepIVA_Leave);
			// 
			// txtPorcentajeIVA
			// 
			this.txtPorcentajeIVA.Enabled = false;
			this.txtPorcentajeIVA.Location = new System.Drawing.Point(78, 171);
			this.txtPorcentajeIVA.Name = "txtPorcentajeIVA";
			this.txtPorcentajeIVA.Size = new System.Drawing.Size(59, 20);
			this.txtPorcentajeIVA.TabIndex = 10;
			this.txtPorcentajeIVA.Text = "21,00";
			this.txtPorcentajeIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPorcentajeIVA.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtPorcentajeIVA.TextChanged += new System.EventHandler(this.txtPorcentajeIVA_TextChanged);
			this.txtPorcentajeIVA.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtPorcentajeIVA.Leave += new System.EventHandler(this.txtPorcentajeIVA_Leave);
			// 
			// BtnAsientos
			// 
			this.BtnAsientos.Enabled = false;
			this.BtnAsientos.Location = new System.Drawing.Point(415, 361);
			this.BtnAsientos.Name = "BtnAsientos";
			this.BtnAsientos.Size = new System.Drawing.Size(124, 23);
			this.BtnAsientos.TabIndex = 20;
			this.BtnAsientos.Text = "Generar Asientos >>";
			this.BtnAsientos.UseVisualStyleBackColor = true;
			this.BtnAsientos.Click += new System.EventHandler(this.BtnAsientos_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(331, 319);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(78, 13);
			this.label15.TabIndex = 73;
			this.label15.Text = "Observaciones";
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Enabled = false;
			this.txtObservaciones.Location = new System.Drawing.Point(334, 335);
			this.txtObservaciones.MaxLength = 50;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.Size = new System.Drawing.Size(205, 20);
			this.txtObservaciones.TabIndex = 19;
			this.txtObservaciones.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtObservaciones.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtObservaciones.Leave += new System.EventHandler(this.TextboxToUpper);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(75, 258);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(31, 13);
			this.label14.TabIndex = 72;
			this.label14.Text = "Total";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(385, 174);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(51, 13);
			this.label13.TabIndex = 71;
			this.label13.Text = "Provincia";
			this.label13.Visible = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(45, 228);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(27, 13);
			this.label12.TabIndex = 70;
			this.label12.Text = "IIBB";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(20, 202);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(52, 13);
			this.label11.TabIndex = 69;
			this.label11.Text = "Perc. IVA";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(141, 116);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 67;
			this.label9.Text = "Exento";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(48, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 66;
			this.label8.Text = "IVA";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 116);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 65;
			this.label7.Text = "Neto";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(261, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 13);
			this.label6.TabIndex = 64;
			this.label6.Text = "Vencimiento";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(141, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 13);
			this.label5.TabIndex = 63;
			this.label5.Text = "Fecha de Carga";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 62;
			this.label4.Text = "Fecha de Factura";
			// 
			// LblDocumento
			// 
			this.LblDocumento.AutoSize = true;
			this.LblDocumento.Location = new System.Drawing.Point(355, 23);
			this.LblDocumento.Name = "LblDocumento";
			this.LblDocumento.Size = new System.Drawing.Size(43, 13);
			this.LblDocumento.TabIndex = 61;
			this.LblDocumento.Text = "Factura";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 59;
			this.label2.Text = "Proveedor";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 57;
			this.label1.Text = "Codigo";
			// 
			// txtProvincia
			// 
			this.txtProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtProvincia.Enabled = false;
			this.txtProvincia.Location = new System.Drawing.Point(442, 171);
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.Size = new System.Drawing.Size(97, 20);
			this.txtProvincia.TabIndex = 17;
			this.txtProvincia.Visible = false;
			this.txtProvincia.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtProvincia.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtProvincia.Leave += new System.EventHandler(this.txtProvincia_Leave);
			// 
			// txtTotal
			// 
			this.txtTotal.Enabled = false;
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotal.Location = new System.Drawing.Point(78, 274);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(180, 26);
			this.txtTotal.TabIndex = 58;
			this.txtTotal.TabStop = false;
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtExento
			// 
			this.txtExento.BackColor = System.Drawing.SystemColors.Window;
			this.txtExento.Location = new System.Drawing.Point(144, 132);
			this.txtExento.Name = "txtExento";
			this.txtExento.Size = new System.Drawing.Size(115, 20);
			this.txtExento.TabIndex = 9;
			this.txtExento.Text = "0,00";
			this.txtExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtExento.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtExento.TextChanged += new System.EventHandler(this.txtExento_TextChanged);
			this.txtExento.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtExento.Leave += new System.EventHandler(this.txtExento_Leave);
			// 
			// txtNeto
			// 
			this.txtNeto.Enabled = false;
			this.txtNeto.Location = new System.Drawing.Point(22, 132);
			this.txtNeto.Name = "txtNeto";
			this.txtNeto.Size = new System.Drawing.Size(115, 20);
			this.txtNeto.TabIndex = 8;
			this.txtNeto.Text = "0,00";
			this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNeto.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtNeto.TextChanged += new System.EventHandler(this.txtNeto_TextChanged);
			this.txtNeto.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtNeto.Leave += new System.EventHandler(this.txtNeto_Leave);
			// 
			// txtMontoPercepIVA
			// 
			this.txtMontoPercepIVA.Enabled = false;
			this.txtMontoPercepIVA.Location = new System.Drawing.Point(143, 199);
			this.txtMontoPercepIVA.Name = "txtMontoPercepIVA";
			this.txtMontoPercepIVA.Size = new System.Drawing.Size(115, 20);
			this.txtMontoPercepIVA.TabIndex = 13;
			this.txtMontoPercepIVA.Text = "0,00";
			this.txtMontoPercepIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMontoPercepIVA.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtMontoPercepIVA.TextChanged += new System.EventHandler(this.txtMontoPercepIVA_TextChanged);
			this.txtMontoPercepIVA.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtMontoPercepIVA.Leave += new System.EventHandler(this.txtMontoPercepIVA_Leave);
			// 
			// txtMontoIIBB
			// 
			this.txtMontoIIBB.Enabled = false;
			this.txtMontoIIBB.Location = new System.Drawing.Point(143, 225);
			this.txtMontoIIBB.Name = "txtMontoIIBB";
			this.txtMontoIIBB.Size = new System.Drawing.Size(115, 20);
			this.txtMontoIIBB.TabIndex = 15;
			this.txtMontoIIBB.TabStop = false;
			this.txtMontoIIBB.Text = "0,00";
			this.txtMontoIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMontoIIBB.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtMontoIIBB.Enter += new System.EventHandler(this.TextBoxSelectAll);
			// 
			// txtMontoIVA
			// 
			this.txtMontoIVA.Enabled = false;
			this.txtMontoIVA.Location = new System.Drawing.Point(143, 173);
			this.txtMontoIVA.Name = "txtMontoIVA";
			this.txtMontoIVA.Size = new System.Drawing.Size(115, 20);
			this.txtMontoIVA.TabIndex = 11;
			this.txtMontoIVA.Text = "0,00";
			this.txtMontoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMontoIVA.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtMontoIVA.TextChanged += new System.EventHandler(this.txtMontoIVA_TextChanged);
			this.txtMontoIVA.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtMontoIVA.Leave += new System.EventHandler(this.txtMontoIVA_Leave);
			// 
			// dtpVencimiento
			// 
			this.dtpVencimiento.CustomFormat = "dd/MM/yyyy";
			this.dtpVencimiento.Enabled = false;
			this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpVencimiento.Location = new System.Drawing.Point(264, 81);
			this.dtpVencimiento.Name = "dtpVencimiento";
			this.dtpVencimiento.Size = new System.Drawing.Size(115, 20);
			this.dtpVencimiento.TabIndex = 7;
			// 
			// dtpCarga
			// 
			this.dtpCarga.CustomFormat = "dd/MM/yyyy";
			this.dtpCarga.Enabled = false;
			this.dtpCarga.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpCarga.Location = new System.Drawing.Point(143, 81);
			this.dtpCarga.Name = "dtpCarga";
			this.dtpCarga.Size = new System.Drawing.Size(115, 20);
			this.dtpCarga.TabIndex = 6;
			// 
			// dtpFechaFactura
			// 
			this.dtpFechaFactura.CustomFormat = "dd/MM/yyyy";
			this.dtpFechaFactura.Enabled = false;
			this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFechaFactura.Location = new System.Drawing.Point(22, 81);
			this.dtpFechaFactura.Name = "dtpFechaFactura";
			this.dtpFechaFactura.Size = new System.Drawing.Size(115, 20);
			this.dtpFechaFactura.TabIndex = 5;
			this.dtpFechaFactura.ValueChanged += new System.EventHandler(this.dtpFechaFactura_ValueChanged);
			// 
			// txtDocumento
			// 
			this.txtDocumento.Enabled = false;
			this.txtDocumento.Location = new System.Drawing.Point(470, 38);
			this.txtDocumento.MaxLength = 8;
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(69, 20);
			this.txtDocumento.TabIndex = 4;
			this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtDocumento.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtDocumento.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
			// 
			// txtSucursal
			// 
			this.txtSucursal.Enabled = false;
			this.txtSucursal.Location = new System.Drawing.Point(415, 38);
			this.txtSucursal.MaxLength = 5;
			this.txtSucursal.Name = "txtSucursal";
			this.txtSucursal.Size = new System.Drawing.Size(47, 20);
			this.txtSucursal.TabIndex = 3;
			this.txtSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtSucursal.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtSucursal.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtSucursal.Leave += new System.EventHandler(this.txtSucursal_Leave);
			// 
			// cbbTipoFactura
			// 
			this.cbbTipoFactura.BackColor = System.Drawing.SystemColors.Window;
			this.cbbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbTipoFactura.Enabled = false;
			this.cbbTipoFactura.FormattingEnabled = true;
			this.cbbTipoFactura.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            " "});
			this.cbbTipoFactura.Location = new System.Drawing.Point(358, 37);
			this.cbbTipoFactura.MaxLength = 1;
			this.cbbTipoFactura.Name = "cbbTipoFactura";
			this.cbbTipoFactura.Size = new System.Drawing.Size(51, 21);
			this.cbbTipoFactura.TabIndex = 2;
			// 
			// txtNombre
			// 
			this.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtNombre.Enabled = false;
			this.txtNombre.Location = new System.Drawing.Point(94, 38);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(247, 20);
			this.txtNombre.TabIndex = 1;
			this.txtNombre.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
			this.txtNombre.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
			// 
			// txtCodigo
			// 
			this.txtCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtCodigo.Enabled = false;
			this.txtCodigo.Location = new System.Drawing.Point(22, 38);
			this.txtCodigo.MaxLength = 4;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(66, 20);
			this.txtCodigo.TabIndex = 0;
			this.txtCodigo.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
			this.txtCodigo.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
			// 
			// tabAsiento
			// 
			this.tabAsiento.Controls.Add(this.CbbMoneda);
			this.tabAsiento.Controls.Add(this.BtnGuardar);
			this.tabAsiento.Controls.Add(this.LblTotalHaber);
			this.tabAsiento.Controls.Add(this.LblTotalDebe);
			this.tabAsiento.Controls.Add(this.label17);
			this.tabAsiento.Controls.Add(this.label18);
			this.tabAsiento.Controls.Add(this.label19);
			this.tabAsiento.Controls.Add(this.PnlLineas);
			this.tabAsiento.Controls.Add(this.TxtObservacionesLD);
			this.tabAsiento.Controls.Add(this.DtpAsiento);
			this.tabAsiento.Location = new System.Drawing.Point(4, 22);
			this.tabAsiento.Name = "tabAsiento";
			this.tabAsiento.Padding = new System.Windows.Forms.Padding(3);
			this.tabAsiento.Size = new System.Drawing.Size(732, 397);
			this.tabAsiento.TabIndex = 1;
			this.tabAsiento.Text = "Asiento";
			this.tabAsiento.UseVisualStyleBackColor = true;
			// 
			// CbbMoneda
			// 
			this.CbbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CbbMoneda.Enabled = false;
			this.CbbMoneda.FormattingEnabled = true;
			this.CbbMoneda.Location = new System.Drawing.Point(416, 31);
			this.CbbMoneda.Name = "CbbMoneda";
			this.CbbMoneda.Size = new System.Drawing.Size(133, 21);
			this.CbbMoneda.TabIndex = 26;
			// 
			// BtnGuardar
			// 
			this.BtnGuardar.Enabled = false;
			this.BtnGuardar.Location = new System.Drawing.Point(461, 351);
			this.BtnGuardar.Name = "BtnGuardar";
			this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
			this.BtnGuardar.TabIndex = 25;
			this.BtnGuardar.Text = "Guardar";
			this.BtnGuardar.UseVisualStyleBackColor = true;
			this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
			// 
			// LblTotalHaber
			// 
			this.LblTotalHaber.AutoSize = true;
			this.LblTotalHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTotalHaber.Location = new System.Drawing.Point(458, 310);
			this.LblTotalHaber.Name = "LblTotalHaber";
			this.LblTotalHaber.Size = new System.Drawing.Size(48, 16);
			this.LblTotalHaber.TabIndex = 24;
			this.LblTotalHaber.Text = "$ 0.00";
			this.LblTotalHaber.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LblTotalDebe
			// 
			this.LblTotalDebe.AutoSize = true;
			this.LblTotalDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTotalDebe.Location = new System.Drawing.Point(350, 310);
			this.LblTotalDebe.Name = "LblTotalDebe";
			this.LblTotalDebe.Size = new System.Drawing.Size(48, 16);
			this.LblTotalDebe.TabIndex = 23;
			this.LblTotalDebe.Text = "$ 0.00";
			this.LblTotalDebe.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(413, 15);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(46, 13);
			this.label17.TabIndex = 22;
			this.label17.Text = "Moneda";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(146, 15);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(78, 13);
			this.label18.TabIndex = 21;
			this.label18.Text = "Observaciones";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(16, 15);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(37, 13);
			this.label19.TabIndex = 20;
			this.label19.Text = "Fecha";
			// 
			// PnlLineas
			// 
			this.PnlLineas.AutoScroll = true;
			this.PnlLineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PnlLineas.Controls.Add(this.btnAgregarAsiento);
			this.PnlLineas.Controls.Add(this.LblTituloHaber);
			this.PnlLineas.Controls.Add(this.LblTituloDebe);
			this.PnlLineas.Controls.Add(this.LblTituloDescripcion);
			this.PnlLineas.Controls.Add(this.label20);
			this.PnlLineas.Location = new System.Drawing.Point(19, 69);
			this.PnlLineas.Name = "PnlLineas";
			this.PnlLineas.Size = new System.Drawing.Size(530, 238);
			this.PnlLineas.TabIndex = 19;
			// 
			// btnAgregarAsiento
			// 
			this.btnAgregarAsiento.Enabled = false;
			this.btnAgregarAsiento.Location = new System.Drawing.Point(10, 28);
			this.btnAgregarAsiento.Name = "btnAgregarAsiento";
			this.btnAgregarAsiento.Size = new System.Drawing.Size(20, 23);
			this.btnAgregarAsiento.TabIndex = 8;
			this.btnAgregarAsiento.Text = "+";
			this.btnAgregarAsiento.UseVisualStyleBackColor = true;
			this.btnAgregarAsiento.Click += new System.EventHandler(this.btnAgregarAsiento_Click);
			// 
			// LblTituloHaber
			// 
			this.LblTituloHaber.AutoSize = true;
			this.LblTituloHaber.Location = new System.Drawing.Point(420, 10);
			this.LblTituloHaber.Name = "LblTituloHaber";
			this.LblTituloHaber.Size = new System.Drawing.Size(36, 13);
			this.LblTituloHaber.TabIndex = 7;
			this.LblTituloHaber.Text = "Haber";
			// 
			// LblTituloDebe
			// 
			this.LblTituloDebe.AutoSize = true;
			this.LblTituloDebe.Location = new System.Drawing.Point(365, 10);
			this.LblTituloDebe.Name = "LblTituloDebe";
			this.LblTituloDebe.Size = new System.Drawing.Size(33, 13);
			this.LblTituloDebe.TabIndex = 6;
			this.LblTituloDebe.Text = "Debe";
			// 
			// LblTituloDescripcion
			// 
			this.LblTituloDescripcion.AutoSize = true;
			this.LblTituloDescripcion.Location = new System.Drawing.Point(85, 10);
			this.LblTituloDescripcion.Name = "LblTituloDescripcion";
			this.LblTituloDescripcion.Size = new System.Drawing.Size(63, 13);
			this.LblTituloDescripcion.TabIndex = 5;
			this.LblTituloDescripcion.Text = "Descripción";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(10, 10);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(41, 13);
			this.label20.TabIndex = 4;
			this.label20.Text = "Cuenta";
			// 
			// TxtObservacionesLD
			// 
			this.TxtObservacionesLD.Enabled = false;
			this.TxtObservacionesLD.Location = new System.Drawing.Point(149, 31);
			this.TxtObservacionesLD.MaxLength = 50;
			this.TxtObservacionesLD.Name = "TxtObservacionesLD";
			this.TxtObservacionesLD.Size = new System.Drawing.Size(249, 20);
			this.TxtObservacionesLD.TabIndex = 17;
			this.TxtObservacionesLD.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtObservacionesLD.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtObservacionesLD.Leave += new System.EventHandler(this.TextboxToUpper);
			// 
			// DtpAsiento
			// 
			this.DtpAsiento.Enabled = false;
			this.DtpAsiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.DtpAsiento.Location = new System.Drawing.Point(19, 31);
			this.DtpAsiento.Name = "DtpAsiento";
			this.DtpAsiento.Size = new System.Drawing.Size(105, 20);
			this.DtpAsiento.TabIndex = 16;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Enabled = false;
			this.btnCancelar.Location = new System.Drawing.Point(671, 83);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 42;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnNuevo
			// 
			this.btnNuevo.Location = new System.Drawing.Point(590, 83);
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(75, 23);
			this.btnNuevo.TabIndex = 40;
			this.btnNuevo.Text = "Nueva";
			this.btnNuevo.UseVisualStyleBackColor = true;
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			// 
			// LblTitle
			// 
			this.LblTitle.AutoSize = true;
			this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTitle.ForeColor = System.Drawing.Color.Maroon;
			this.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LblTitle.Location = new System.Drawing.Point(7, 12);
			this.LblTitle.Name = "LblTitle";
			this.LblTitle.Size = new System.Drawing.Size(307, 29);
			this.LblTitle.TabIndex = 39;
			this.LblTitle.Text = "Facturas de Proveedores";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CapaPresentacion.Properties.Resources.Logo_EMA_FC;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(456, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(296, 49);
			this.pictureBox1.TabIndex = 38;
			this.pictureBox1.TabStop = false;
			// 
			// FrmFacturasProveedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 547);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.LblTitle);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.tabFacturaAsientos);
			this.Controls.Add(this.btnNuevo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FrmFacturasProveedores";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Facturas de Proveedores";
			this.tabFacturaAsientos.ResumeLayout(false);
			this.tabListado.ResumeLayout(false);
			this.tabListado.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
			this.tabFactura.ResumeLayout(false);
			this.tabFactura.PerformLayout();
			this.tabAsiento.ResumeLayout(false);
			this.tabAsiento.PerformLayout();
			this.PnlLineas.ResumeLayout(false);
			this.PnlLineas.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabFacturaAsientos;
        private System.Windows.Forms.TabPage tabFactura;
        private System.Windows.Forms.Button BtnAsientos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtExento;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.TextBox txtMontoPercepIVA;
        private System.Windows.Forms.TextBox txtMontoIIBB;
        private System.Windows.Forms.TextBox txtMontoIVA;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.DateTimePicker dtpCarga;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.ComboBox cbbTipoFactura;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TabPage tabAsiento;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox txtPorcentajeIVA;
        private System.Windows.Forms.TextBox txtPorcentajePercepIVA;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.ComboBox cbbActividad;
        private System.Windows.Forms.CheckBox chkMaterial;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.TextBox txtDespacho;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button BtnGuardar;
		private System.Windows.Forms.Label LblTotalHaber;
		private System.Windows.Forms.Label LblTotalDebe;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel PnlLineas;
		private System.Windows.Forms.Button btnAgregarAsiento;
		private System.Windows.Forms.Label LblTituloHaber;
		private System.Windows.Forms.Label LblTituloDebe;
		private System.Windows.Forms.Label LblTituloDescripcion;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox TxtObservacionesLD;
		private System.Windows.Forms.DateTimePicker DtpAsiento;
		private System.Windows.Forms.ComboBox CbbMoneda;
		private System.Windows.Forms.TabPage tabListado;
		private System.Windows.Forms.DataGridView DgvListado;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button BtnRefresh;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox TxtCodigoLista;
		private System.Windows.Forms.Label LblFacturaOriginal;
		private System.Windows.Forms.TextBox TxtDocumentoOriginal;
		private System.Windows.Forms.TextBox TxtSucursalOriginal;
		private System.Windows.Forms.ComboBox CbbTipoFacturaOriginal;
		private System.Windows.Forms.Button BtnIIBB;
	}
}