namespace CapaPresentacion
{
	partial class FrmIIBB
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
			this.LblNeto = new System.Windows.Forms.Label();
			this.LblTotal = new System.Windows.Forms.Label();
			this.BtnGuardar = new System.Windows.Forms.Button();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.PnlIIBB = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.BtnAgregar = new System.Windows.Forms.Button();
			this.PnlIIBB.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblNeto
			// 
			this.LblNeto.AutoSize = true;
			this.LblNeto.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblNeto.Location = new System.Drawing.Point(12, 9);
			this.LblNeto.Name = "LblNeto";
			this.LblNeto.Size = new System.Drawing.Size(180, 22);
			this.LblNeto.TabIndex = 1;
			this.LblNeto.Text = "Monto neto: $0.00";
			// 
			// LblTotal
			// 
			this.LblTotal.AutoSize = true;
			this.LblTotal.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTotal.Location = new System.Drawing.Point(12, 413);
			this.LblTotal.Name = "LblTotal";
			this.LblTotal.Size = new System.Drawing.Size(180, 22);
			this.LblTotal.TabIndex = 8;
			this.LblTotal.Text = "Total IIBB: $0.00";
			// 
			// BtnGuardar
			// 
			this.BtnGuardar.Location = new System.Drawing.Point(401, 34);
			this.BtnGuardar.Name = "BtnGuardar";
			this.BtnGuardar.Size = new System.Drawing.Size(82, 23);
			this.BtnGuardar.TabIndex = 9;
			this.BtnGuardar.Text = "Guardar";
			this.BtnGuardar.UseVisualStyleBackColor = true;
			this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.Location = new System.Drawing.Point(401, 64);
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.Size = new System.Drawing.Size(82, 23);
			this.BtnCancelar.TabIndex = 10;
			this.BtnCancelar.Text = "Cancelar";
			this.BtnCancelar.UseVisualStyleBackColor = true;
			this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
			// 
			// PnlIIBB
			// 
			this.PnlIIBB.AutoScroll = true;
			this.PnlIIBB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PnlIIBB.Controls.Add(this.label7);
			this.PnlIIBB.Controls.Add(this.label6);
			this.PnlIIBB.Controls.Add(this.label5);
			this.PnlIIBB.Controls.Add(this.BtnAgregar);
			this.PnlIIBB.Location = new System.Drawing.Point(16, 34);
			this.PnlIIBB.Name = "PnlIIBB";
			this.PnlIIBB.Size = new System.Drawing.Size(379, 376);
			this.PnlIIBB.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(186, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Monto";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(117, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(58, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Porcentaje";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Provincia";
			// 
			// BtnAgregar
			// 
			this.BtnAgregar.Location = new System.Drawing.Point(10, 30);
			this.BtnAgregar.Name = "BtnAgregar";
			this.BtnAgregar.Size = new System.Drawing.Size(97, 23);
			this.BtnAgregar.TabIndex = 8;
			this.BtnAgregar.Text = "Agregar...";
			this.BtnAgregar.UseVisualStyleBackColor = true;
			this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
			// 
			// FrmIIBB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 445);
			this.Controls.Add(this.PnlIIBB);
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.BtnGuardar);
			this.Controls.Add(this.LblTotal);
			this.Controls.Add(this.LblNeto);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmIIBB";
			this.Text = "Ingresos Brutos";
			this.PnlIIBB.ResumeLayout(false);
			this.PnlIIBB.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label LblNeto;
		private System.Windows.Forms.Label LblTotal;
		private System.Windows.Forms.Button BtnGuardar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.Panel PnlIIBB;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button BtnAgregar;
	}
}