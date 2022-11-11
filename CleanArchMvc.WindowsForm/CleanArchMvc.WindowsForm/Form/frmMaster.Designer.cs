namespace CleanArchMvc.WindowsForm
{
    partial class frmMaster
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
            this.mnuAnimal = new System.Windows.Forms.MenuStrip();
            this.cadsatrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pecuaristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnimal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAnimal
            // 
            this.mnuAnimal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadsatrosToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.mnuAnimal.Location = new System.Drawing.Point(0, 0);
            this.mnuAnimal.Name = "mnuAnimal";
            this.mnuAnimal.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnuAnimal.Size = new System.Drawing.Size(1394, 24);
            this.mnuAnimal.TabIndex = 1;
            this.mnuAnimal.Text = "&Animal";
            // 
            // cadsatrosToolStripMenuItem
            // 
            this.cadsatrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animalToolStripMenuItem,
            this.pecuaristaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.compraToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
            this.cadsatrosToolStripMenuItem.Name = "cadsatrosToolStripMenuItem";
            this.cadsatrosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadsatrosToolStripMenuItem.Text = "&Cadastro";
            // 
            // animalToolStripMenuItem
            // 
            this.animalToolStripMenuItem.Name = "animalToolStripMenuItem";
            this.animalToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.animalToolStripMenuItem.Text = "&Animal";
            this.animalToolStripMenuItem.Click += new System.EventHandler(this.animalToolStripMenuItem_Click);
            // 
            // pecuaristaToolStripMenuItem
            // 
            this.pecuaristaToolStripMenuItem.Name = "pecuaristaToolStripMenuItem";
            this.pecuaristaToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.pecuaristaToolStripMenuItem.Text = "&Pecuarista";
            this.pecuaristaToolStripMenuItem.Click += new System.EventHandler(this.pecuaristaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 6);
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.compraToolStripMenuItem.Text = "C&ompra";
            this.compraToolStripMenuItem.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.sairToolStripMenuItem.Text = "Sai&r";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "&Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 783);
            this.Controls.Add(this.mnuAnimal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuAnimal;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: MARFRIG :: ";
            this.mnuAnimal.ResumeLayout(false);
            this.mnuAnimal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAnimal;
        private System.Windows.Forms.ToolStripMenuItem cadsatrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pecuaristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem compraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
    }
}

