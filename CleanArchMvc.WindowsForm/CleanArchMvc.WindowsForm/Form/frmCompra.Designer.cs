namespace CleanArchMvc.WindowsForm.Formulario
{
    partial class frmCompra
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtEntregaFinal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEntregaInicio = new System.Windows.Forms.TextBox();
            this.lblEntrega = new System.Windows.Forms.Label();
            this.cmbPecuarista = new System.Windows.Forms.ComboBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.txtEntregaFinal);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtEntregaInicio);
            this.groupBox3.Controls.Add(this.lblEntrega);
            this.groupBox3.Controls.Add(this.cmbPecuarista);
            this.groupBox3.Controls.Add(this.lblNome);
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Controls.Add(this.btnPesquisar);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(14, 96);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(1182, 561);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(982, 88);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 20;
            this.txtId.Visible = false;
            // 
            // txtEntregaFinal
            // 
            this.txtEntregaFinal.Location = new System.Drawing.Point(300, 74);
            this.txtEntregaFinal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEntregaFinal.MaxLength = 10;
            this.txtEntregaFinal.Name = "txtEntregaFinal";
            this.txtEntregaFinal.Size = new System.Drawing.Size(144, 23);
            this.txtEntregaFinal.TabIndex = 19;
            this.txtEntregaFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntregaFinal_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Até";
            // 
            // txtEntregaInicio
            // 
            this.txtEntregaInicio.Location = new System.Drawing.Point(114, 74);
            this.txtEntregaInicio.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEntregaInicio.MaxLength = 10;
            this.txtEntregaInicio.Name = "txtEntregaInicio";
            this.txtEntregaInicio.Size = new System.Drawing.Size(144, 23);
            this.txtEntregaInicio.TabIndex = 17;
            this.txtEntregaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntregaInicio_KeyPress);
            // 
            // lblEntrega
            // 
            this.lblEntrega.AutoSize = true;
            this.lblEntrega.Location = new System.Drawing.Point(8, 77);
            this.lblEntrega.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(90, 15);
            this.lblEntrega.TabIndex = 16;
            this.lblEntrega.Text = "Data Entrega de";
            // 
            // cmbPecuarista
            // 
            this.cmbPecuarista.FormattingEnabled = true;
            this.cmbPecuarista.Location = new System.Drawing.Point(13, 37);
            this.cmbPecuarista.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbPecuarista.Name = "cmbPecuarista";
            this.cmbPecuarista.Size = new System.Drawing.Size(828, 23);
            this.cmbPecuarista.TabIndex = 15;
            this.cmbPecuarista.SelectedIndexChanged += new System.EventHandler(this.cmbPecuarista_SelectedIndexChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(8, 18);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(61, 15);
            this.lblNome.TabIndex = 14;
            this.lblNome.Text = "Pecuarista";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1077, 35);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(88, 47);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(982, 35);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(88, 47);
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1153, 418);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSair);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Location = new System.Drawing.Point(14, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1182, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1077, 16);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(88, 60);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sai&r";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(12, 16);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(128, 60);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // frmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1210, 685);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: COMPRA ::";
            this.Load += new System.EventHandler(this.frmCompra_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtEntregaFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEntregaInicio;
        private System.Windows.Forms.Label lblEntrega;
        private System.Windows.Forms.ComboBox cmbPecuarista;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtId;
    }
}