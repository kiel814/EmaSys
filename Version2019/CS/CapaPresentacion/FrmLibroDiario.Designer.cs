namespace CapaPresentacion
{
    partial class FrmLibroDiario
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PnlLineas = new System.Windows.Forms.Panel();
            this.LblTituloHaber = new System.Windows.Forms.Label();
            this.LblTituloDebe = new System.Windows.Forms.Label();
            this.LblTituloDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblTotalDebe = new System.Windows.Forms.Label();
            this.LblTotalHaber = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.PnlLineas.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(395, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 20);
            this.textBox2.TabIndex = 2;
            // 
            // PnlLineas
            // 
            this.PnlLineas.AutoScroll = true;
            this.PnlLineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlLineas.Controls.Add(this.LblTituloHaber);
            this.PnlLineas.Controls.Add(this.LblTituloDebe);
            this.PnlLineas.Controls.Add(this.LblTituloDescripcion);
            this.PnlLineas.Controls.Add(this.label1);
            this.PnlLineas.Location = new System.Drawing.Point(15, 63);
            this.PnlLineas.Name = "PnlLineas";
            this.PnlLineas.Size = new System.Drawing.Size(515, 205);
            this.PnlLineas.TabIndex = 7;
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
            this.LblTituloDebe.Location = new System.Drawing.Point(330, 10);
            this.LblTituloDebe.Name = "LblTituloDebe";
            this.LblTituloDebe.Size = new System.Drawing.Size(33, 13);
            this.LblTituloDebe.TabIndex = 6;
            this.LblTituloDebe.Text = "Debe";
            // 
            // LblTituloDescripcion
            // 
            this.LblTituloDescripcion.AutoSize = true;
            this.LblTituloDescripcion.Location = new System.Drawing.Point(70, 10);
            this.LblTituloDescripcion.Name = "LblTituloDescripcion";
            this.LblTituloDescripcion.Size = new System.Drawing.Size(63, 13);
            this.LblTituloDescripcion.TabIndex = 5;
            this.LblTituloDescripcion.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cuenta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Observaciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Moneda";
            // 
            // LblTotalDebe
            // 
            this.LblTotalDebe.AutoSize = true;
            this.LblTotalDebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalDebe.Location = new System.Drawing.Point(346, 271);
            this.LblTotalDebe.Name = "LblTotalDebe";
            this.LblTotalDebe.Size = new System.Drawing.Size(48, 16);
            this.LblTotalDebe.TabIndex = 12;
            this.LblTotalDebe.Text = "$ 0.00";
            this.LblTotalDebe.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblTotalHaber
            // 
            this.LblTotalHaber.AutoSize = true;
            this.LblTotalHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalHaber.Location = new System.Drawing.Point(454, 271);
            this.LblTotalHaber.Name = "LblTotalHaber";
            this.LblTotalHaber.Size = new System.Drawing.Size(48, 16);
            this.LblTotalHaber.TabIndex = 14;
            this.LblTotalHaber.Text = "$ 0.00";
            this.LblTotalHaber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(457, 306);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(75, 23);
            this.BtnGuardar.TabIndex = 15;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // FrmLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 341);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LblTotalHaber);
            this.Controls.Add(this.LblTotalDebe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PnlLineas);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.MinimumSize = new System.Drawing.Size(560, 380);
            this.Name = "FrmLibroDiario";
            this.Text = "Libro Diario";
            this.Resize += new System.EventHandler(this.FrmLibroDiario_Resize);
            this.PnlLineas.ResumeLayout(false);
            this.PnlLineas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel PnlLineas;
        private System.Windows.Forms.Label LblTituloHaber;
        private System.Windows.Forms.Label LblTituloDebe;
        private System.Windows.Forms.Label LblTituloDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblTotalDebe;
        private System.Windows.Forms.Label LblTotalHaber;
        private System.Windows.Forms.Button BtnGuardar;
    }
}