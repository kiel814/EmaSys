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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbbTipoFactura = new System.Windows.Forms.ComboBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.dtpCarga = new System.Windows.Forms.DateTimePicker();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.nudPorcentajeIVA = new System.Windows.Forms.NumericUpDown();
            this.txtMontoIVA = new System.Windows.Forms.TextBox();
            this.txtMontoIIBB = new System.Windows.Forms.TextBox();
            this.nudPorcentajeIIBB = new System.Windows.Forms.NumericUpDown();
            this.txtMontoPercepcionIVA = new System.Windows.Forms.TextBox();
            this.nudPorcentajePercepcionIVA = new System.Windows.Forms.NumericUpDown();
            this.txtNeto = new System.Windows.Forms.TextBox();
            this.txtExento = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.chkBienDeUso = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeIIBB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajePercepcionIVA)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCodigo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodigo.Location = new System.Drawing.Point(15, 25);
            this.txtCodigo.MaxLength = 4;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(66, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(87, 25);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(247, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TabStop = false;
            // 
            // cbbTipoFactura
            // 
            this.cbbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbTipoFactura.FormattingEnabled = true;
            this.cbbTipoFactura.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cbbTipoFactura.Location = new System.Drawing.Point(351, 24);
            this.cbbTipoFactura.Name = "cbbTipoFactura";
            this.cbbTipoFactura.Size = new System.Drawing.Size(51, 21);
            this.cbbTipoFactura.TabIndex = 2;
            // 
            // txtSucursal
            // 
            this.txtSucursal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSucursal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSucursal.Location = new System.Drawing.Point(408, 25);
            this.txtSucursal.MaxLength = 4;
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(47, 20);
            this.txtSucursal.TabIndex = 3;
            this.txtSucursal.Text = "0000";
            this.txtSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSucursal.Enter += new System.EventHandler(this.txtSucursal_Enter);
            this.txtSucursal.Leave += new System.EventHandler(this.txtSucursal_Leave);
            // 
            // txtDocumento
            // 
            this.txtDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDocumento.Location = new System.Drawing.Point(463, 25);
            this.txtDocumento.MaxLength = 8;
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(69, 20);
            this.txtDocumento.TabIndex = 4;
            this.txtDocumento.Text = "00000000";
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDocumento.Enter += new System.EventHandler(this.txtDocumento_Enter);
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFactura.Location = new System.Drawing.Point(15, 68);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(115, 20);
            this.dtpFechaFactura.TabIndex = 5;
            // 
            // dtpCarga
            // 
            this.dtpCarga.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCarga.Location = new System.Drawing.Point(136, 68);
            this.dtpCarga.Name = "dtpCarga";
            this.dtpCarga.Size = new System.Drawing.Size(115, 20);
            this.dtpCarga.TabIndex = 6;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(257, 68);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(115, 20);
            this.dtpVencimiento.TabIndex = 7;
            // 
            // nudPorcentajeIVA
            // 
            this.nudPorcentajeIVA.DecimalPlaces = 2;
            this.nudPorcentajeIVA.Location = new System.Drawing.Point(71, 149);
            this.nudPorcentajeIVA.Name = "nudPorcentajeIVA";
            this.nudPorcentajeIVA.Size = new System.Drawing.Size(65, 20);
            this.nudPorcentajeIVA.TabIndex = 11;
            this.nudPorcentajeIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPorcentajeIVA.ValueChanged += new System.EventHandler(this.nudPorcentajeIVA_ValueChanged);
            this.nudPorcentajeIVA.Enter += new System.EventHandler(this.nudPorcentajeIVA_Enter);
            // 
            // txtMontoIVA
            // 
            this.txtMontoIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMontoIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMontoIVA.Location = new System.Drawing.Point(142, 148);
            this.txtMontoIVA.Name = "txtMontoIVA";
            this.txtMontoIVA.ReadOnly = true;
            this.txtMontoIVA.Size = new System.Drawing.Size(66, 20);
            this.txtMontoIVA.TabIndex = 12;
            this.txtMontoIVA.TabStop = false;
            this.txtMontoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMontoIIBB
            // 
            this.txtMontoIIBB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMontoIIBB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMontoIIBB.Location = new System.Drawing.Point(142, 200);
            this.txtMontoIIBB.Name = "txtMontoIIBB";
            this.txtMontoIIBB.ReadOnly = true;
            this.txtMontoIIBB.Size = new System.Drawing.Size(66, 20);
            this.txtMontoIIBB.TabIndex = 17;
            this.txtMontoIIBB.TabStop = false;
            this.txtMontoIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPorcentajeIIBB
            // 
            this.nudPorcentajeIIBB.DecimalPlaces = 2;
            this.nudPorcentajeIIBB.Location = new System.Drawing.Point(71, 201);
            this.nudPorcentajeIIBB.Name = "nudPorcentajeIIBB";
            this.nudPorcentajeIIBB.Size = new System.Drawing.Size(65, 20);
            this.nudPorcentajeIIBB.TabIndex = 16;
            this.nudPorcentajeIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPorcentajeIIBB.ValueChanged += new System.EventHandler(this.nudPorcentajeIIBB_ValueChanged);
            this.nudPorcentajeIIBB.Enter += new System.EventHandler(this.nudPorcentajeIIBB_Enter);
            // 
            // txtMontoPercepcionIVA
            // 
            this.txtMontoPercepcionIVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMontoPercepcionIVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMontoPercepcionIVA.Location = new System.Drawing.Point(142, 174);
            this.txtMontoPercepcionIVA.Name = "txtMontoPercepcionIVA";
            this.txtMontoPercepcionIVA.ReadOnly = true;
            this.txtMontoPercepcionIVA.Size = new System.Drawing.Size(66, 20);
            this.txtMontoPercepcionIVA.TabIndex = 15;
            this.txtMontoPercepcionIVA.TabStop = false;
            this.txtMontoPercepcionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPorcentajePercepcionIVA
            // 
            this.nudPorcentajePercepcionIVA.DecimalPlaces = 2;
            this.nudPorcentajePercepcionIVA.Location = new System.Drawing.Point(71, 175);
            this.nudPorcentajePercepcionIVA.Name = "nudPorcentajePercepcionIVA";
            this.nudPorcentajePercepcionIVA.Size = new System.Drawing.Size(65, 20);
            this.nudPorcentajePercepcionIVA.TabIndex = 14;
            this.nudPorcentajePercepcionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPorcentajePercepcionIVA.ValueChanged += new System.EventHandler(this.nudPorcentajePercepcionIVA_ValueChanged);
            this.nudPorcentajePercepcionIVA.Enter += new System.EventHandler(this.nudPorcentajePercepcionIVA_Enter);
            // 
            // txtNeto
            // 
            this.txtNeto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNeto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNeto.Location = new System.Drawing.Point(71, 119);
            this.txtNeto.Name = "txtNeto";
            this.txtNeto.Size = new System.Drawing.Size(137, 20);
            this.txtNeto.TabIndex = 8;
            this.txtNeto.Text = "0.00";
            this.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNeto.TextChanged += new System.EventHandler(this.txtNeto_TextChanged);
            this.txtNeto.Enter += new System.EventHandler(this.txtNeto_Enter);
            // 
            // txtExento
            // 
            this.txtExento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtExento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtExento.BackColor = System.Drawing.SystemColors.Window;
            this.txtExento.Location = new System.Drawing.Point(234, 119);
            this.txtExento.Name = "txtExento";
            this.txtExento.Size = new System.Drawing.Size(78, 20);
            this.txtExento.TabIndex = 9;
            this.txtExento.Text = "0.00";
            this.txtExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExento.TextChanged += new System.EventHandler(this.txtExento_TextChanged);
            this.txtExento.Enter += new System.EventHandler(this.txtExento_Enter);
            // 
            // txtMaterial
            // 
            this.txtMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMaterial.Location = new System.Drawing.Point(381, 119);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(19, 20);
            this.txtMaterial.TabIndex = 10;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTotal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(71, 261);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(137, 26);
            this.txtTotal.TabIndex = 20;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProvincia
            // 
            this.txtProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProvincia.Location = new System.Drawing.Point(381, 149);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(78, 20);
            this.txtProvincia.TabIndex = 13;
            // 
            // chkBienDeUso
            // 
            this.chkBienDeUso.AutoSize = true;
            this.chkBienDeUso.Location = new System.Drawing.Point(234, 202);
            this.chkBienDeUso.Name = "chkBienDeUso";
            this.chkBienDeUso.Size = new System.Drawing.Size(84, 17);
            this.chkBienDeUso.TabIndex = 18;
            this.chkBienDeUso.Text = "Bien de Uso";
            this.chkBienDeUso.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(324, 202);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 19;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha de Factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fecha de Carga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Neto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "IVA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Exento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Material";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Perc. IVA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "IIBB";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(324, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Provincia";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(68, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Total";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(324, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtObservaciones.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtObservaciones.Location = new System.Drawing.Point(327, 261);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(205, 20);
            this.txtObservaciones.TabIndex = 21;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(457, 304);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 36;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmFacturasProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 340);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.chkBienDeUso);
            this.Controls.Add(this.txtProvincia);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.txtExento);
            this.Controls.Add(this.txtNeto);
            this.Controls.Add(this.txtMontoPercepcionIVA);
            this.Controls.Add(this.nudPorcentajePercepcionIVA);
            this.Controls.Add(this.txtMontoIIBB);
            this.Controls.Add(this.nudPorcentajeIIBB);
            this.Controls.Add(this.txtMontoIVA);
            this.Controls.Add(this.nudPorcentajeIVA);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.dtpCarga);
            this.Controls.Add(this.dtpFechaFactura);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtSucursal);
            this.Controls.Add(this.cbbTipoFactura);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFacturasProveedores";
            this.Text = "Facturas de Proveedores";
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajeIIBB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentajePercepcionIVA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbbTipoFactura;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.DateTimePicker dtpCarga;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.NumericUpDown nudPorcentajeIVA;
        private System.Windows.Forms.TextBox txtMontoIVA;
        private System.Windows.Forms.TextBox txtMontoIIBB;
        private System.Windows.Forms.NumericUpDown nudPorcentajeIIBB;
        private System.Windows.Forms.TextBox txtMontoPercepcionIVA;
        private System.Windows.Forms.NumericUpDown nudPorcentajePercepcionIVA;
        private System.Windows.Forms.TextBox txtNeto;
        private System.Windows.Forms.TextBox txtExento;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.CheckBox chkBienDeUso;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button BtnGuardar;
    }
}