using CleanArchMvc.WindowsForm.Classes;
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
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CleanArchMvc.WindowsForm.Formulario
{
    public partial class frmCompraDetalhe : Form
    {
        public frmCompraDetalhe()
        {
            InitializeComponent();
            LimpaCampo();


        }
        List<AnimalList> lstanimais = new List<AnimalList>();
        public Form ReferenciaDaInstanciaDoForm { get; set; }
        public int IdCompra { get; set; }
        private void frmCompraDetalhe_Load(object sender, EventArgs e)
        {
            if (!IdCompra.Equals(0))
            {
                CarregaRegistro(IdCompra);
            }
        }

        private void CarregaRegistro(int idcompra)
        {
            var compra = compraService.GetCompra(idcompra);
            txtIdCompra.Text = compra.Id.ToString();
            cmbPecuarista.SelectedValue = compra.PecuaristaId;
            cmbPecuarista.Refresh();
            txtEntrega.Text = compra.dataEntrega;
            if(compra.Id.Equals(0))
            {
                MessageBox.Show("Registro não localizado ...", "Atenção");
                txtIdCompra.Text = null;
                AtualizaGrid();
                return;
            }
            if (compra.items != null)
            {
                if (compra.items.Count() > 0)
                {
                    foreach (var itens in compra.items.OrderBy(c => c.animalId).ToList())
                    {
                        var animal = animalService.GetAnimal(itens.animalId);

                        lstanimais.Add(new AnimalList()
                        {
                            CompraId = compra.Id,
                            Id = itens.animalId,
                            Descricao = animal.Descricao,
                            Quantidade = itens.quantidade,
                            Preco = animal.Preco,
                            Total = itens.quantidade * animal.Preco
                        });
                    }
                }
            }
            AtualizaGrid();

        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            lstanimais = new List<AnimalList>();
            LimpaCampo();
            dgvAnimal.DataSource = null;

            AtualizaGrid();
            PreencheComboPecuarista();
            PreencheComboAnimal();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtIdCompra.Text))
                {
                    MessageBox.Show("Selecione um registro");
                    return;
                }
                var status = compraService.DeleteAsync(int.Parse(txtIdCompra.Text));
                
                LimpaCampo();
                dgvAnimal.DataSource = null;

                AtualizaGrid();
                PreencheComboPecuarista();
                PreencheComboAnimal();

            }
            catch(Exception ex)
            {

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdCompra.Text.ToString() == "0" )
                {
                    MessageBox.Show("Necessário selecionar Pecuarista ");
                    cmbPecuarista.Focus();
                    return;
                }

                if(string.IsNullOrEmpty(txtEntrega.Text.ToString()))
                {
                    MessageBox.Show("Necessário informar data de entrega");
                    txtEntrega.Focus();
                    return;
                }

                if (lstanimais.Count() <= 0)
                {
                    MessageBox.Show("Necessário adicionais animais");
                    return;
                }

                int _Id = int.Parse(String.IsNullOrEmpty(txtIdCompra.Text) ? "0" : txtIdCompra.Text);
                List<CompraGadoItem> itens = new List<CompraGadoItem>();
                foreach (AnimalList x in lstanimais)
                {
                    itens.Add(new CompraGadoItem()
                    {
                        compraGadoId = _Id,
                        animalId = x.Id,
                        quantidade = x.Quantidade
                    });
                };
                CompraGado record = new CompraGado
                {
                    Id = _Id,
                    PecuaristaId = int.Parse(cmbPecuarista.SelectedValue.ToString()),
                    dataEntrega = DateTime.Parse(txtEntrega.Text).ToString(),
                    items = itens.ToList()
                };

                if (_Id == 0)
                {
                    var status = compraDetalheService.CreateAsync(record);
                }
                else
                {
                    var status = compraDetalheService.UpdateAsync(record);
                }
                LimpaCampo();
                MessageBox.Show("Registro gravado com sucesso....");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar registro....");
            }
            AtualizaGrid();

        }

        private void btnAnimalAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdAnimal.Text) && string.IsNullOrEmpty(txtIdCompra.Text))
            {
                MessageBox.Show("Selecione um animal...", "Atenção");
                LimpaCampoAnimal();                
                cmbAnimal.Focus();
                return;
            }

            if (lstanimais.Where(c => c.Id.Equals(int.Parse(txtIdAnimal.Text)) && c.CompraId.Equals(string.IsNullOrEmpty(txtIdCompra.Text) ? c.CompraId : int.Parse(txtIdAnimal.Text))).Count() >0 )
            {
                MessageBox.Show("Registro ja adicionado");
                LimpaCampoAnimal();
                return;
            }


            if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                MessageBox.Show("Informe uma quantidade");
                txtQuantidade.Focus();
                return;
            }


            lstanimais.Add(new AnimalList()
            {
                Id = int.Parse(txtIdAnimal.Text),
                CompraId = int.Parse(String.IsNullOrEmpty(txtIdCompra.Text) ? "0" : txtIdCompra.Text),
                Descricao = cmbAnimal.Text,
                Quantidade = int.Parse(txtQuantidade.Text),
                Preco = decimal.Parse(txtPreco.Text),
                Total = int.Parse(txtQuantidade.Text) * decimal.Parse(txtPreco.Text)
            });
            LimpaCampoAnimal();
            AtualizaGrid();
        }

        private void btnAnimalRemover_Click(object sender, EventArgs e)
        {

            int _Id = int.Parse(String.IsNullOrEmpty(txtIdAnimal.Text) ? "0" : txtIdAnimal.Text);
            if (_Id == 0)
            {
                MessageBox.Show("Selecione um registro", "Atenção");
            }
            lstanimais.FirstOrDefault(c => c.Id.Equals(_Id));
            lstanimais.Remove(lstanimais.FirstOrDefault(c => c.Id.Equals(_Id)));
            
            LimpaCampoAnimal();
            AtualizaGrid();
        }



        #region --|Private|--
        private void LimpaCampo()
        {
            this.Text = ":: DETALHE COMPRA ::";
            txtIdCompra.Text = null;
            txtIdAnimal.Text = null;
            cmbPecuarista.Refresh();
            txtEntrega.Text = null;
            lstanimais = new List<AnimalList>();
            LimpaCampoAnimal();
            PreencheComboPecuarista();
            PreencheComboAnimal();
        }
        private void LimpaCampoAnimal()
        {
            txtIdAnimal.Text = null;
            cmbAnimal.Refresh();
            txtPreco.Text = null;
            txtQuantidade.Text = null;
            txtTotal.Text = null;
            PreencheComboAnimal();
        }

        private void AtualizaGrid()
        {
            dgvAnimal.DataSource = null;
            dgvAnimal.DataSource = lstanimais;
            dgvAnimal.Refresh();

        }
        private void PreencheComboPecuarista()
        {
            List<Pecuarista> dados = new List<Pecuarista>();
            dados.Add(new Pecuarista() { Id = 0, Name = "*** Selecione ***" });
            dados.AddRange(pecuaristaService.ListaPecuarista());

            cmbPecuarista.DisplayMember = "Name";
            cmbPecuarista.ValueMember = "Id";
            cmbPecuarista.DataSource = dados;
        }
        private void PreencheComboAnimal()
        {
            List<Animal> dados = new List<Animal>();
            dados.Add(new Animal() { Id = 0, Descricao = "*** Selecione ***", Preco = 0 });
            dados.AddRange(animalService.ListaAnimal());

            cmbAnimal.DisplayMember = "Descricao";
            cmbAnimal.ValueMember = "Id";
            cmbAnimal.DataSource = dados;
        }
        private void cmbAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(cmbAnimal.SelectedValue.ToString()) != 0)
            {
                var dados = compraDetalheService.GetAnimal(int.Parse(cmbAnimal.SelectedValue.ToString()));
                txtPreco.Text = dados.Preco.ToString();
                txtIdAnimal.Text = dados.Id.ToString();
            }
        }




        #endregion

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Report.fmrRelatorio newMDIChild = new Report.fmrRelatorio();
            newMDIChild.NomeReport = "relcompradetalhe";
            newMDIChild.idCompra = int.Parse(txtIdCompra.Text);
            newMDIChild.Show();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (char.IsNumber(e.KeyChar))
            {
                //if (Regex.IsMatch(txtQuantidade.Text, "^\\d*\\.\\d{2}$")) e.Handled = true;
                if (Regex.IsMatch(txtQuantidade.Text, "^\\d\\d{2}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;

        }

        private void dgvAnimal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount.Equals(0)) return;
            if (dgv.CurrentRow.Selected)
            {
                txtIdAnimal.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                cmbAnimal.SelectedValue = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                txtQuantidade.Text = dgv.CurrentRow.Cells[3].Value.ToString();
                txtPreco.Text = dgv.CurrentRow.Cells[4].Value.ToString();
                txtTotal.Text = dgv.CurrentRow.Cells[5].Value.ToString();
            }
        }


        public class AnimalList
        {
            public int Id { get; set; }
            public int CompraId { get; set; }
            public string Descricao { get; set; }
            public int Quantidade { get; set; }
            public decimal Preco { get; set; }
            public decimal Total { get; set; }
        }
    }
}