using CleanArchMvc.WindowsForm.Entity;
using CleanArchMvc.WindowsForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CleanArchMvc.WindowsForm.Formulario
{
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
            LimpaCampo();
            PreencheCombo();

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource =compraService.ListaCompra().ToList(); ;
            dataGridView1.Refresh();
        }
        public Form ReferenciaDaInstanciaDoForm { get; set; }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampo();
            PreencheCombo();

            frmCompraDetalhe newMDIChild = new frmCompraDetalhe();
            newMDIChild.ReferenciaDaInstanciaDoForm = this;
            newMDIChild.IdCompra = 0;
            newMDIChild.Text = ":: DETALHE COMPRA ::";
            newMDIChild.Show();
            this.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
            var lista = compraService.ListaCompra().Where(c => c.PecuaristaId.Equals(string.IsNullOrEmpty(cmbPecuarista.SelectedValue.ToString())  ? c.PecuaristaId : int.Parse(cmbPecuarista.SelectedValue.ToString()) == 0 ? c.PecuaristaId : int.Parse(cmbPecuarista.SelectedValue.ToString()))                
            ).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Refresh();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Report.fmrRelatorio newMDIChild = new Report.fmrRelatorio();
            newMDIChild.NomeReport = "relcompra";
            
            newMDIChild.Show();
        }

        private void cmbPecuarista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEntregaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEntregaFinal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount.Equals(0)) return;
            if (dgv.CurrentRow.Selected)
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                
                frmCompraDetalhe newMDIChild = new frmCompraDetalhe();                
                newMDIChild.ReferenciaDaInstanciaDoForm = this;
                newMDIChild.IdCompra = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                newMDIChild.Text = string.Format(":: DETALHE COMPRA [{0}] ::", newMDIChild.IdCompra);
                newMDIChild.Show();
                this.Enabled = true;
            }
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {

        }



        #region --|Private|--
        private void LimpaCampo()
        {
            txtId.Text = null;
            txtEntregaFinal.Text = null;
            txtEntregaInicio.Text = null;
            cmbPecuarista.Refresh();

        }
        private void PreencheCombo()
        {
            List<Pecuarista> dados = new List<Pecuarista>();
            dados.Add(new Pecuarista()
            {
                Id = 0,
                Name = "*** Selecione ***"
            });
            dados.AddRange(pecuaristaService.ListaPecuarista());

            cmbPecuarista.DisplayMember = "Name";
            cmbPecuarista.ValueMember = "Id";
            cmbPecuarista.DataSource = dados;
        }
        
        #endregion
    }
}
