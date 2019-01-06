namespace CapaPresentacion
{
    partial class FrmNombreClientes
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
            this.spmostrar_clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.dsPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnImprimirNombCli = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliNombDde = new System.Windows.Forms.TextBox();
            this.txtCliNombHta = new System.Windows.Forms.TextBox();
            this.spmostrar_clienteTableAdapter = new CapaPresentacion.dsPrincipalTableAdapters.spmostrar_clienteTableAdapter();
            this.spmostrarclienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spmostrar_clienteBindingSource
            // 
            this.spmostrar_clienteBindingSource.DataMember = "spmostrar_cliente";
            this.spmostrar_clienteBindingSource.DataSource = this.dsPrincipal;
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
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptNombreClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 46);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 404);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnImprimirNombCli
            // 
            this.btnImprimirNombCli.Location = new System.Drawing.Point(639, 9);
            this.btnImprimirNombCli.Name = "btnImprimirNombCli";
            this.btnImprimirNombCli.Size = new System.Drawing.Size(109, 23);
            this.btnImprimirNombCli.TabIndex = 1;
            this.btnImprimirNombCli.Text = "Imprimir por Nombre";
            this.btnImprimirNombCli.UseVisualStyleBackColor = true;
            this.btnImprimirNombCli.Click += new System.EventHandler(this.btnImprimirNombCli_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde Letra:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta Letra:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCliNombDde
            // 
            this.txtCliNombDde.Location = new System.Drawing.Point(86, 12);
            this.txtCliNombDde.Name = "txtCliNombDde";
            this.txtCliNombDde.Size = new System.Drawing.Size(100, 20);
            this.txtCliNombDde.TabIndex = 4;
            this.txtCliNombDde.TextChanged += new System.EventHandler(this.txtCliNombDde_TextChanged);
            // 
            // txtCliNombHta
            // 
            this.txtCliNombHta.Location = new System.Drawing.Point(314, 12);
            this.txtCliNombHta.Name = "txtCliNombHta";
            this.txtCliNombHta.Size = new System.Drawing.Size(100, 20);
            this.txtCliNombHta.TabIndex = 5;
            this.txtCliNombHta.TextChanged += new System.EventHandler(this.txtCliNombHta_TextChanged);
            // 
            // spmostrar_clienteTableAdapter
            // 
            this.spmostrar_clienteTableAdapter.ClearBeforeFill = true;
            // 
            // spmostrarclienteBindingSource
            // 
            this.spmostrarclienteBindingSource.DataMember = "spmostrar_cliente";
            this.spmostrarclienteBindingSource.DataSource = this.dsPrincipal;
            // 
            // FrmNombreClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCliNombHta);
            this.Controls.Add(this.txtCliNombDde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirNombCli);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmNombreClientes";
            this.Text = "FrmNombreClientes";
            this.Load += new System.EventHandler(this.FrmNombreClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrarclienteBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnImprimirNombCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliNombDde;
        private System.Windows.Forms.TextBox txtCliNombHta;
        private System.Windows.Forms.BindingSource spmostrar_clienteBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.spmostrar_clienteTableAdapter spmostrar_clienteTableAdapter;
        private System.Windows.Forms.BindingSource spmostrarclienteBindingSource;
    }
}