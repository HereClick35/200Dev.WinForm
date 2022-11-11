using CleanArchMvc.WindowsForm.Formulario;
using System;
using System.Windows.Forms;

namespace CleanArchMvc.WindowsForm
{
    public partial class frmMaster : Form
    {
        public frmMaster()
        {
            InitializeComponent();
        }
        public Form ReferenciaDaInstanciaDoForm { get; set; }

        private void frmMaster_Load(object sender, EventArgs e)
        {

        }

        private void animalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnimal newMDIChild = new frmAnimal();            
            newMDIChild.MdiParent = this;
            newMDIChild.ReferenciaDaInstanciaDoForm = this;
            newMDIChild.Show();            
        }

        private void pecuaristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPecuarista newMDIChild = new frmPecuarista();
            newMDIChild.MdiParent = this;
            newMDIChild.ReferenciaDaInstanciaDoForm = this;
            newMDIChild.Show();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra newMDIChild = new frmCompra();
            newMDIChild.MdiParent = this;
            newMDIChild.ReferenciaDaInstanciaDoForm = this;
            newMDIChild.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre newMDIChild = new frmSobre();
            newMDIChild.MdiParent = this;
            newMDIChild.ReferenciaDaInstanciaDoForm = this;
            newMDIChild.Show();
        }
    }
}
