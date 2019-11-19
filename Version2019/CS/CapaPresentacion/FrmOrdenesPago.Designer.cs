namespace CapaPresentacion
{
	partial class FrmOrdenesPago
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
			this.LblTitle = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabListadoPagos = new System.Windows.Forms.TabControl();
			this.TabListado = new System.Windows.Forms.TabPage();
			this.BtnRefresh = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.TxtCodigoLista = new System.Windows.Forms.TextBox();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.DgvListado = new System.Windows.Forms.DataGridView();
			this.BtnEditar = new System.Windows.Forms.Button();
			this.TabOrden = new System.Windows.Forms.TabPage();
			this.BtnIIBB = new System.Windows.Forms.Button();
			this.TxtMontoGanancias = new System.Windows.Forms.TextBox();
			this.TxtPorcentajeGanancias = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.TxtMontoIIBB = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.LblPadronCABA = new System.Windows.Forms.Label();
			this.LblPadronARBA = new System.Windows.Forms.Label();
			this.BtnActualizar = new System.Windows.Forms.Button();
			this.PnlPendientes = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
			this.DtpFechaIni = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.TxtNombre = new System.Windows.Forms.TextBox();
			this.TxtCodigo = new System.Windows.Forms.TextBox();
			this.BtnGuardar = new System.Windows.Forms.Button();
			this.LblTotal = new System.Windows.Forms.Label();
			this.BtnNueva = new System.Windows.Forms.Button();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.btnTodo = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.TabListadoPagos.SuspendLayout();
			this.TabListado.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
			this.TabOrden.SuspendLayout();
			this.PnlPendientes.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblTitle
			// 
			this.LblTitle.AutoSize = true;
			this.LblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTitle.ForeColor = System.Drawing.Color.Maroon;
			this.LblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LblTitle.Location = new System.Drawing.Point(12, 9);
			this.LblTitle.Name = "LblTitle";
			this.LblTitle.Size = new System.Drawing.Size(219, 29);
			this.LblTitle.TabIndex = 40;
			this.LblTitle.Text = "Órdenes de Pago";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CapaPresentacion.Properties.Resources.Logo_EMA_FC;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(492, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(296, 49);
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			// 
			// TabListadoPagos
			// 
			this.TabListadoPagos.Controls.Add(this.TabListado);
			this.TabListadoPagos.Controls.Add(this.TabOrden);
			this.TabListadoPagos.Location = new System.Drawing.Point(17, 96);
			this.TabListadoPagos.Name = "TabListadoPagos";
			this.TabListadoPagos.SelectedIndex = 0;
			this.TabListadoPagos.Size = new System.Drawing.Size(771, 470);
			this.TabListadoPagos.TabIndex = 42;
			// 
			// TabListado
			// 
			this.TabListado.Controls.Add(this.BtnRefresh);
			this.TabListado.Controls.Add(this.label21);
			this.TabListado.Controls.Add(this.TxtCodigoLista);
			this.TabListado.Controls.Add(this.btnEliminar);
			this.TabListado.Controls.Add(this.DgvListado);
			this.TabListado.Controls.Add(this.BtnEditar);
			this.TabListado.Location = new System.Drawing.Point(4, 22);
			this.TabListado.Name = "TabListado";
			this.TabListado.Padding = new System.Windows.Forms.Padding(3);
			this.TabListado.Size = new System.Drawing.Size(763, 444);
			this.TabListado.TabIndex = 0;
			this.TabListado.Text = "Listado";
			this.TabListado.UseVisualStyleBackColor = true;
			// 
			// BtnRefresh
			// 
			this.BtnRefresh.Location = new System.Drawing.Point(17, 66);
			this.BtnRefresh.Name = "BtnRefresh";
			this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
			this.BtnRefresh.TabIndex = 66;
			this.BtnRefresh.Text = "Actualizar";
			this.BtnRefresh.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(14, 13);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(40, 13);
			this.label21.TabIndex = 65;
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
			this.TxtCodigoLista.TabIndex = 64;
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(668, 66);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 63;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			// 
			// DgvListado
			// 
			this.DgvListado.AllowUserToAddRows = false;
			this.DgvListado.AllowUserToDeleteRows = false;
			this.DgvListado.AllowUserToOrderColumns = true;
			this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvListado.Location = new System.Drawing.Point(17, 104);
			this.DgvListado.MultiSelect = false;
			this.DgvListado.Name = "DgvListado";
			this.DgvListado.ReadOnly = true;
			this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvListado.Size = new System.Drawing.Size(726, 289);
			this.DgvListado.TabIndex = 61;
			// 
			// BtnEditar
			// 
			this.BtnEditar.Location = new System.Drawing.Point(587, 66);
			this.BtnEditar.Name = "BtnEditar";
			this.BtnEditar.Size = new System.Drawing.Size(75, 23);
			this.BtnEditar.TabIndex = 62;
			this.BtnEditar.Text = "Editar";
			this.BtnEditar.UseVisualStyleBackColor = true;
			// 
			// TabOrden
			// 
			this.TabOrden.Controls.Add(this.btnTodo);
			this.TabOrden.Controls.Add(this.BtnIIBB);
			this.TabOrden.Controls.Add(this.TxtMontoGanancias);
			this.TabOrden.Controls.Add(this.TxtPorcentajeGanancias);
			this.TabOrden.Controls.Add(this.label15);
			this.TabOrden.Controls.Add(this.TxtMontoIIBB);
			this.TabOrden.Controls.Add(this.label14);
			this.TabOrden.Controls.Add(this.label13);
			this.TabOrden.Controls.Add(this.label6);
			this.TabOrden.Controls.Add(this.LblPadronCABA);
			this.TabOrden.Controls.Add(this.LblPadronARBA);
			this.TabOrden.Controls.Add(this.BtnActualizar);
			this.TabOrden.Controls.Add(this.PnlPendientes);
			this.TabOrden.Controls.Add(this.label5);
			this.TabOrden.Controls.Add(this.label4);
			this.TabOrden.Controls.Add(this.DtpFechaFin);
			this.TabOrden.Controls.Add(this.DtpFechaIni);
			this.TabOrden.Controls.Add(this.label2);
			this.TabOrden.Controls.Add(this.label1);
			this.TabOrden.Controls.Add(this.TxtNombre);
			this.TabOrden.Controls.Add(this.TxtCodigo);
			this.TabOrden.Controls.Add(this.BtnGuardar);
			this.TabOrden.Controls.Add(this.LblTotal);
			this.TabOrden.Location = new System.Drawing.Point(4, 22);
			this.TabOrden.Name = "TabOrden";
			this.TabOrden.Padding = new System.Windows.Forms.Padding(3);
			this.TabOrden.Size = new System.Drawing.Size(763, 444);
			this.TabOrden.TabIndex = 1;
			this.TabOrden.Text = "Órden";
			this.TabOrden.UseVisualStyleBackColor = true;
			// 
			// BtnIIBB
			// 
			this.BtnIIBB.Location = new System.Drawing.Point(85, 374);
			this.BtnIIBB.Name = "BtnIIBB";
			this.BtnIIBB.Size = new System.Drawing.Size(60, 23);
			this.BtnIIBB.TabIndex = 87;
			this.BtnIIBB.Text = "Editar...";
			this.BtnIIBB.UseVisualStyleBackColor = true;
			this.BtnIIBB.Click += new System.EventHandler(this.BtnIIBB_Click);
			// 
			// TxtMontoGanancias
			// 
			this.TxtMontoGanancias.Location = new System.Drawing.Point(151, 405);
			this.TxtMontoGanancias.Name = "TxtMontoGanancias";
			this.TxtMontoGanancias.Size = new System.Drawing.Size(100, 20);
			this.TxtMontoGanancias.TabIndex = 86;
			// 
			// TxtPorcentajeGanancias
			// 
			this.TxtPorcentajeGanancias.Location = new System.Drawing.Point(85, 405);
			this.TxtPorcentajeGanancias.Name = "TxtPorcentajeGanancias";
			this.TxtPorcentajeGanancias.Size = new System.Drawing.Size(60, 20);
			this.TxtPorcentajeGanancias.TabIndex = 85;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(15, 408);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(58, 13);
			this.label15.TabIndex = 84;
			this.label15.Text = "Ganancias";
			// 
			// TxtMontoIIBB
			// 
			this.TxtMontoIIBB.Location = new System.Drawing.Point(151, 376);
			this.TxtMontoIIBB.Name = "TxtMontoIIBB";
			this.TxtMontoIIBB.Size = new System.Drawing.Size(100, 20);
			this.TxtMontoIIBB.TabIndex = 83;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(15, 379);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(27, 13);
			this.label14.TabIndex = 81;
			this.label14.Text = "IIBB";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(15, 89);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(75, 13);
			this.label13.TabIndex = 80;
			this.label13.Text = "Padrón CABA:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 13);
			this.label6.TabIndex = 79;
			this.label6.Text = "Padrón ARBA:";
			// 
			// LblPadronCABA
			// 
			this.LblPadronCABA.AutoSize = true;
			this.LblPadronCABA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPadronCABA.Location = new System.Drawing.Point(97, 89);
			this.LblPadronCABA.Name = "LblPadronCABA";
			this.LblPadronCABA.Size = new System.Drawing.Size(19, 13);
			this.LblPadronCABA.TabIndex = 78;
			this.LblPadronCABA.Text = "---";
			// 
			// LblPadronARBA
			// 
			this.LblPadronARBA.AutoSize = true;
			this.LblPadronARBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblPadronARBA.Location = new System.Drawing.Point(97, 65);
			this.LblPadronARBA.Name = "LblPadronARBA";
			this.LblPadronARBA.Size = new System.Drawing.Size(19, 13);
			this.LblPadronARBA.TabIndex = 77;
			this.LblPadronARBA.Text = "---";
			// 
			// BtnActualizar
			// 
			this.BtnActualizar.Location = new System.Drawing.Point(663, 29);
			this.BtnActualizar.Name = "BtnActualizar";
			this.BtnActualizar.Size = new System.Drawing.Size(88, 23);
			this.BtnActualizar.TabIndex = 76;
			this.BtnActualizar.Text = "Siguiente";
			this.BtnActualizar.UseVisualStyleBackColor = true;
			this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
			// 
			// PnlPendientes
			// 
			this.PnlPendientes.AutoScroll = true;
			this.PnlPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PnlPendientes.Controls.Add(this.label12);
			this.PnlPendientes.Controls.Add(this.label11);
			this.PnlPendientes.Controls.Add(this.label10);
			this.PnlPendientes.Controls.Add(this.label9);
			this.PnlPendientes.Controls.Add(this.label8);
			this.PnlPendientes.Controls.Add(this.label7);
			this.PnlPendientes.Controls.Add(this.label3);
			this.PnlPendientes.Location = new System.Drawing.Point(18, 128);
			this.PnlPendientes.Name = "PnlPendientes";
			this.PnlPendientes.Size = new System.Drawing.Size(733, 226);
			this.PnlPendientes.TabIndex = 75;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(172, 10);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(91, 13);
			this.label12.TabIndex = 88;
			this.label12.Text = "Contradocumento";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(595, 10);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(45, 13);
			this.label11.TabIndex = 76;
			this.label11.Text = "A Pagar";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(487, 10);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(101, 13);
			this.label10.TabIndex = 75;
			this.label10.Text = "Deuda c/Impuestos";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(393, 10);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 13);
			this.label9.TabIndex = 74;
			this.label9.Text = "Vencimiento";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(299, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 73;
			this.label8.Text = "Fecha";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(45, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(62, 13);
			this.label7.TabIndex = 72;
			this.label7.Text = "Documento";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 70;
			this.label3.Text = "Tipo";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(471, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 74;
			this.label5.Text = "Hasta";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(349, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 73;
			this.label4.Text = "Desde";
			// 
			// DtpFechaFin
			// 
			this.DtpFechaFin.CustomFormat = "dd/MM/yyyy";
			this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpFechaFin.Location = new System.Drawing.Point(473, 31);
			this.DtpFechaFin.Name = "DtpFechaFin";
			this.DtpFechaFin.Size = new System.Drawing.Size(115, 20);
			this.DtpFechaFin.TabIndex = 72;
			// 
			// DtpFechaIni
			// 
			this.DtpFechaIni.CustomFormat = "dd/MM/yyyy";
			this.DtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.DtpFechaIni.Location = new System.Drawing.Point(352, 31);
			this.DtpFechaIni.Name = "DtpFechaIni";
			this.DtpFechaIni.Size = new System.Drawing.Size(115, 20);
			this.DtpFechaIni.TabIndex = 71;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(89, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 70;
			this.label2.Text = "Proveedor";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 69;
			this.label1.Text = "Código";
			// 
			// TxtNombre
			// 
			this.TxtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TxtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.TxtNombre.Location = new System.Drawing.Point(90, 31);
			this.TxtNombre.Name = "TxtNombre";
			this.TxtNombre.Size = new System.Drawing.Size(247, 20);
			this.TxtNombre.TabIndex = 68;
			this.TxtNombre.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
			this.TxtNombre.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtNombre.Leave += new System.EventHandler(this.TxtNombre_Leave);
			// 
			// TxtCodigo
			// 
			this.TxtCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.TxtCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.TxtCodigo.Location = new System.Drawing.Point(18, 31);
			this.TxtCodigo.MaxLength = 4;
			this.TxtCodigo.Name = "TxtCodigo";
			this.TxtCodigo.Size = new System.Drawing.Size(66, 20);
			this.TxtCodigo.TabIndex = 67;
			this.TxtCodigo.Click += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
			this.TxtCodigo.Enter += new System.EventHandler(this.TextBoxSelectAll);
			this.TxtCodigo.Leave += new System.EventHandler(this.TxtCodigo_Leave);
			// 
			// BtnGuardar
			// 
			this.BtnGuardar.Enabled = false;
			this.BtnGuardar.Location = new System.Drawing.Point(676, 403);
			this.BtnGuardar.Name = "BtnGuardar";
			this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
			this.BtnGuardar.TabIndex = 66;
			this.BtnGuardar.Text = "Guardar";
			this.BtnGuardar.UseVisualStyleBackColor = true;
			this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
			// 
			// LblTotal
			// 
			this.LblTotal.AutoSize = true;
			this.LblTotal.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTotal.Location = new System.Drawing.Point(621, 373);
			this.LblTotal.Name = "LblTotal";
			this.LblTotal.Size = new System.Drawing.Size(130, 22);
			this.LblTotal.TabIndex = 65;
			this.LblTotal.Text = "Total: $0.00";
			// 
			// BtnNueva
			// 
			this.BtnNueva.Location = new System.Drawing.Point(628, 79);
			this.BtnNueva.Name = "BtnNueva";
			this.BtnNueva.Size = new System.Drawing.Size(75, 23);
			this.BtnNueva.TabIndex = 43;
			this.BtnNueva.Text = "Nueva";
			this.BtnNueva.UseVisualStyleBackColor = true;
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(709, 79);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
			this.BtnCancelar.TabIndex = 44;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnTodo
			// 
			this.btnTodo.Location = new System.Drawing.Point(663, 99);
			this.btnTodo.Name = "btnTodo";
			this.btnTodo.Size = new System.Drawing.Size(88, 23);
			this.btnTodo.TabIndex = 88;
			this.btnTodo.Text = "Pagar Todo";
			this.btnTodo.UseVisualStyleBackColor = true;
			this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
			// 
			// FrmOrdenesPago
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 577);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.BtnNueva);
			this.Controls.Add(this.TabListadoPagos);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.LblTitle);
			this.Name = "FrmOrdenesPago";
			this.Text = "Órdenes de Pago";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.TabListadoPagos.ResumeLayout(false);
			this.TabListado.ResumeLayout(false);
			this.TabListado.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
			this.TabOrden.ResumeLayout(false);
			this.TabOrden.PerformLayout();
			this.PnlPendientes.ResumeLayout(false);
			this.PnlPendientes.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LblTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabControl TabListadoPagos;
		private System.Windows.Forms.TabPage TabListado;
		private System.Windows.Forms.TabPage TabOrden;
		private System.Windows.Forms.Button BtnNueva;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Button BtnRefresh;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox TxtCodigoLista;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.DataGridView DgvListado;
		private System.Windows.Forms.Button BtnEditar;
		private System.Windows.Forms.Button BtnGuardar;
		private System.Windows.Forms.Label LblTotal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxtNombre;
		private System.Windows.Forms.TextBox TxtCodigo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker DtpFechaFin;
		private System.Windows.Forms.DateTimePicker DtpFechaIni;
		private System.Windows.Forms.Panel PnlPendientes;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button BtnActualizar;
		private System.Windows.Forms.Label LblPadronCABA;
		private System.Windows.Forms.Label LblPadronARBA;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox TxtMontoIIBB;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox TxtMontoGanancias;
		private System.Windows.Forms.TextBox TxtPorcentajeGanancias;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button BtnIIBB;
		private System.Windows.Forms.Button btnTodo;
	}
}