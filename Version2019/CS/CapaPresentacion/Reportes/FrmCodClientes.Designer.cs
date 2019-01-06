namespace CapaPresentacion
{
    partial class FrmCodClientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliCodDde = new System.Windows.Forms.TextBox();
            this.txtCliCodHta = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
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
            reportDataSource1.Value = this.spmostrarclienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptCodClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 404);
            this.reportViewer1.TabIndex = 0;
            // 
            // spmostrar_clienteTableAdapter
            // 
            this.spmostrar_clienteTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta Código:";
            // 
            // txtCliCodDde
            // 
            this.txtCliCodDde.Location = new System.Drawing.Point(108, 15);
            this.txtCliCodDde.Name = "txtCliCodDde";
            this.txtCliCodDde.Size = new System.Drawing.Size(100, 20);
            this.txtCliCodDde.TabIndex = 3;
            this.txtCliCodDde.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliCodDde_Validating);
            // 
            // txtCliCodHta
            // 
            this.txtCliCodHta.Location = new System.Drawing.Point(348, 15);
            this.txtCliCodHta.Name = "txtCliCodHta";
            this.txtCliCodHta.Size = new System.Drawing.Size(100, 20);
            this.txtCliCodHta.TabIndex = 4;
            this.txtCliCodHta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliCodHta_Validating);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(673, 14);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(105, 23);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir por Código";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmCodClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtCliCodHta);
            this.Controls.Add(this.txtCliCodDde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmCodClientes";
            this.Text = ".::  Listado por Código de Clientes  ::.";
            this.Load += new System.EventHandler(this.FrmCodClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostrarclienteBindingSource;
        private dsPrincipalTableAdapters.spmostrar_clienteTableAdapter spmostrar_clienteTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliCodDde;
        private System.Windows.Forms.TextBox txtCliCodHta;
        private System.Windows.Forms.Button btnImprimir;
    }
}