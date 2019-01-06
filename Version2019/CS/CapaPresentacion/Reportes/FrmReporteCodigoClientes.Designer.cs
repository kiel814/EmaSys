namespace CapaPresentacion
{ 
    partial class FrmReporteCodClientes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spmostrarclienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spmostrar_clienteTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spmostrar_clienteTableAdapter();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtDdeCodClien = new System.Windows.Forms.TextBox();
            this.txtHtaCodClien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spmostrar_clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrarclienteBindingSource
            // 
            this.spmostrarclienteBindingSource.DataMember = "spmostrar_cliente";
            this.spmostrarclienteBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spmostrar_clienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptCodigoClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 81);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 369);
            this.reportViewer1.TabIndex = 0;
            // 
            // spmostrar_clienteTableAdapter
            // 
            this.spmostrar_clienteTableAdapter.ClearBeforeFill = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(616, 25);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtDdeCodClien
            // 
            this.txtDdeCodClien.Location = new System.Drawing.Point(172, 25);
            this.txtDdeCodClien.Name = "txtDdeCodClien";
            this.txtDdeCodClien.Size = new System.Drawing.Size(100, 20);
            this.txtDdeCodClien.TabIndex = 2;
            // 
            // txtHtaCodClien
            // 
            this.txtHtaCodClien.Location = new System.Drawing.Point(420, 26);
            this.txtHtaCodClien.Name = "txtHtaCodClien";
            this.txtHtaCodClien.Size = new System.Drawing.Size(100, 20);
            this.txtHtaCodClien.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // spmostrar_clienteBindingSource
            // 
            this.spmostrar_clienteBindingSource.DataMember = "spmostrar_cliente";
            this.spmostrar_clienteBindingSource.DataSource = this.dsPrincipal;
            // 
            // FrmReporteCodClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHtaCodClien);
            this.Controls.Add(this.txtDdeCodClien);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCodClientes";
            this.Text = "FrmReporteCodCliente";
            this.Load += new System.EventHandler(this.FrmReporteCodCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostrarclienteBindingSource;
        private dsPrincipalTableAdapters.spmostrar_clienteTableAdapter spmostrar_clienteTableAdapter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtDdeCodClien;
        private System.Windows.Forms.TextBox txtHtaCodClien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource spmostrar_clienteBindingSource;
    }
}