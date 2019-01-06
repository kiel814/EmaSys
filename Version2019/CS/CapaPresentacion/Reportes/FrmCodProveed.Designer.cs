namespace CapaPresentacion
{
    partial class FrmCodProveed
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
            this.spmostrarproveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spmostrar_proveedorTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spmostrar_proveedorTableAdapter();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtProvCodHta = new System.Windows.Forms.TextBox();
            this.txtProvCodDde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarproveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrarproveedorBindingSource
            // 
            this.spmostrarproveedorBindingSource.DataMember = "spmostrar_proveedor";
            this.spmostrarproveedorBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.spmostrarproveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptCodProveed.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 393);
            this.reportViewer1.TabIndex = 0;
            // 
            // spmostrar_proveedorTableAdapter
            // 
            this.spmostrar_proveedorTableAdapter.ClearBeforeFill = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(674, 16);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(105, 23);
            this.btnImprimir.TabIndex = 10;
            this.btnImprimir.Text = "Imprimir por Código";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtProvCodHta
            // 
            this.txtProvCodHta.Location = new System.Drawing.Point(349, 17);
            this.txtProvCodHta.Name = "txtProvCodHta";
            this.txtProvCodHta.Size = new System.Drawing.Size(100, 20);
            this.txtProvCodHta.TabIndex = 9;
            this.txtProvCodHta.Validating += new System.ComponentModel.CancelEventHandler(this.txtProvCodHta_Validating);
            // 
            // txtProvCodDde
            // 
            this.txtProvCodDde.Location = new System.Drawing.Point(109, 17);
            this.txtProvCodDde.Name = "txtProvCodDde";
            this.txtProvCodDde.Size = new System.Drawing.Size(100, 20);
            this.txtProvCodDde.TabIndex = 8;
            this.txtProvCodDde.Validating += new System.ComponentModel.CancelEventHandler(this.txtProvCodDde_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Desde Código:";
            // 
            // FrmCodProveed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtProvCodHta);
            this.Controls.Add(this.txtProvCodDde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmCodProveed";
            this.Text = ".::  Listado por Código de Proveedor  ::.";
            this.Load += new System.EventHandler(this.FrmCodProveed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarproveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostrarproveedorBindingSource;
        private dsPrincipalTableAdapters.spmostrar_proveedorTableAdapter spmostrar_proveedorTableAdapter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtProvCodHta;
        private System.Windows.Forms.TextBox txtProvCodDde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}