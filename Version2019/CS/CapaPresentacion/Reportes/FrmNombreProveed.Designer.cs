namespace CapaPresentacion
{
    partial class FrmNombreProveed
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.spmostrarproveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spmostrar_proveedorTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spmostrar_proveedorTableAdapter();
            this.txtProvNombHta = new System.Windows.Forms.TextBox();
            this.txtProvNombDde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimirNombCli = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarproveedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.spmostrarproveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptNombreProveed.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 59);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 391);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spmostrarproveedorBindingSource
            // 
            this.spmostrarproveedorBindingSource.DataMember = "spmostrar_proveedor";
            this.spmostrarproveedorBindingSource.DataSource = this.dsPrincipal;
            // 
            // spmostrar_proveedorTableAdapter
            // 
            this.spmostrar_proveedorTableAdapter.ClearBeforeFill = true;
            // 
            // txtProvNombHta
            // 
            this.txtProvNombHta.Location = new System.Drawing.Point(334, 21);
            this.txtProvNombHta.Name = "txtProvNombHta";
            this.txtProvNombHta.Size = new System.Drawing.Size(100, 20);
            this.txtProvNombHta.TabIndex = 10;
            // 
            // txtProvNombDde
            // 
            this.txtProvNombDde.Location = new System.Drawing.Point(106, 21);
            this.txtProvNombDde.Name = "txtProvNombDde";
            this.txtProvNombDde.Size = new System.Drawing.Size(100, 20);
            this.txtProvNombDde.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta Letra:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde Letra:";
            // 
            // btnImprimirNombCli
            // 
            this.btnImprimirNombCli.Location = new System.Drawing.Point(659, 18);
            this.btnImprimirNombCli.Name = "btnImprimirNombCli";
            this.btnImprimirNombCli.Size = new System.Drawing.Size(109, 23);
            this.btnImprimirNombCli.TabIndex = 6;
            this.btnImprimirNombCli.Text = "Imprimir por Nombre";
            this.btnImprimirNombCli.UseVisualStyleBackColor = true;
            this.btnImprimirNombCli.Click += new System.EventHandler(this.btnImprimirNombCli_Click);
            // 
            // FrmNombreProveed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtProvNombHta);
            this.Controls.Add(this.txtProvNombDde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirNombCli);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmNombreProveed";
            this.Text = "FrmNombreProveed";
            this.Load += new System.EventHandler(this.FrmNombreProveed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarproveedorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostrarproveedorBindingSource;
        private dsPrincipalTableAdapters.spmostrar_proveedorTableAdapter spmostrar_proveedorTableAdapter;
        private System.Windows.Forms.TextBox txtProvNombHta;
        private System.Windows.Forms.TextBox txtProvNombDde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprimirNombCli;
    }
}