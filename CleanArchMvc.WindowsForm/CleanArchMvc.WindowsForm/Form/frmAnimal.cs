using CleanArchMvc.WindowsForm.Classes;
using CleanArchMvc.WindowsForm.Entity;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CleanArchMvc.WindowsForm.Formulario
{
    public partial class frmAnimal : Form
    {
        public frmAnimal()
        {
            InitializeComponent();
            LimpaCampo();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = animalService.ListaAnimal().ToList();
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
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //var valor = dataGridView1.CurrentRow.Cells[0].Value;

            int _Id = int.Parse(String.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text);
            if (_Id == 0)
            {
                MessageBox.Show("Selecione um registro", "Atenção");
            }
            
            var status = animalService.DeleteAnimalAsync(_Id);
            LimpaCampo();
            btnPesquisar_Click(sender, e);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescricao.Text) || string.IsNullOrEmpty(txtPreco.Text))
                {
                    MessageBox.Show("Necessaário informa Descrição e Preço", "Atenção");
                    txtDescricao.Focus();
                    return;
                }
                int _Id = int.Parse(String.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text);
                Animal record = new Animal
                {
                    Id = _Id,
                    Descricao = txtDescricao.Text,
                    Preco = decimal.Parse(String.IsNullOrEmpty(txtPreco.Text) ? "0" : txtPreco.Text)
                };
                Task<HttpStatusCode> status;
                if (_Id == 0)
                {
                    status = animalService.CreateAnimalAsync(record);                   
                }
                else
                {
                    status = animalService.UpdateAnimalAsync(record);
                    
                }

                // if (status.IsCompleted){
                    LimpaCampo();                    
                    MessageBox.Show("Registro gravado com sucesso....");
                // } else {
                //    MessageBox.Show("Registro não pode ser gravado....");
                // }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar registro....");
            }
            btnPesquisar_Click(sender, e);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var lista = animalService.ListaAnimal().Where(c => c.Descricao.Trim().Contains(String.IsNullOrEmpty(txtPesquisa.Text) ? c.Descricao.Trim() : txtPesquisa.Text)
                                            && c.Preco >= decimal.Parse(String.IsNullOrEmpty(txtFaixaPrecoInicial.Text) ? c.Preco.ToString() : txtFaixaPrecoInicial.Text)
                                            && c.Preco <= decimal.Parse(String.IsNullOrEmpty(txtFaixaPrecoFinal.Text) ? c.Preco.ToString() : txtFaixaPrecoFinal.Text)
            ).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Refresh();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Report.fmrRelatorio newMDIChild = new Report.fmrRelatorio();
            newMDIChild.NomeReport = "relanimal";
            newMDIChild.Show();           
        }



        #region --|Private|--
        private void LimpaCampo()
        {
            txtId.Text = null;
            txtPreco.Text = null;
            txtDescricao.Text = null;
            txtPesquisa.Text = null;
            txtFaixaPrecoFinal.Text = null;
            txtFaixaPrecoInicial.Text = null;
            txtDescricao.Focus();
        }
        //private List<Animal> ListaAnimal()
        //{
        //    using (var client = new HttpClient())
        //    {                
        //        var _urlBase = string.Format("{0}{1}",ConfigurationManager.AppSettings["UrlBase"], "animal");
        //        using (var response = client.GetAsync((_urlBase)))
        //        {
        //            if (response.Result.IsSuccessStatusCode)
        //            {
        //                var content = response.Result.Content.ReadAsStringAsync();
        //                var options = new JsonSerializerOptions
        //                {
        //                    IncludeFields = true,
        //                    PropertyNameCaseInsensitive = true
        //                };
        //                List<Animal> lista = JsonSerializer.Deserialize<List<Animal>>(content.Result, options);
        //                return lista;
        //                //dataGridView1.DataSource = lista;
        //            }
        //            else
        //            {
        //                throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
        //            }
        //        }
        //    }
        //}
        //private async Task<HttpStatusCode> CreateAnimalAsync(Animal data)
        //{
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Animal");
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
        //    response.EnsureSuccessStatusCode();
        //    return response.StatusCode;
        //}
        //private async Task<HttpStatusCode> UpdateAnimalAsync(Animal data)
        //{
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Animal?id={0}",data.Id));
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.PutAsJsonAsync(_urlBase, data);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.StatusCode;
        //}
        //private async Task<HttpStatusCode> DeleteAnimalAsync(int id)
        //{        
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Animal/{0}", id));
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.DeleteAsync(_urlBase);
        //    return response.StatusCode;
        //}
        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            {
                if (Regex.IsMatch(txtPreco.Text,"^\\d*\\.\\d{2}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;
        }
        private void txtFaixaPrecoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            {
                if (Regex.IsMatch(txtFaixaPrecoInicial.Text, "^\\d*\\.\\d{2}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;
        }
        private void txtFaixaPrecoFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            {
                if (Regex.IsMatch(txtFaixaPrecoFinal.Text, "^\\d*\\.\\d{2}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount.Equals(0)) return;
            if (dgv.CurrentRow.Selected)
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDescricao.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPreco.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }
        #endregion
    }
}
