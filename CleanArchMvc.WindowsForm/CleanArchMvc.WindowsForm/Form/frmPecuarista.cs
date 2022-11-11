using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using CleanArchMvc.WindowsForm.Entity;
using System.Configuration;
using System.Net;
using System.Text;
using System.Net.Http.Json;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using CleanArchMvc.WindowsForm.Services;

namespace CleanArchMvc.WindowsForm.Formulario
{
    public partial class frmPecuarista : Form
    {
        public frmPecuarista()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = pecuaristaService.ListaPecuarista().ToList();
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

            var status = pecuaristaService.DeletePecuaristaAsync(_Id);
            LimpaCampo();
            btnPesquisar_Click(sender, e);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Necessaário informa Nome", "Atenção");
                    txtNome.Focus();
                    return;
                }
                int _Id = int.Parse(String.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text);
                Pecuarista record = new Pecuarista
                {
                    Id = _Id,
                    Name = txtNome.Text,

                };

                if (_Id == 0) { var status = pecuaristaService.CreatePecuaristaAsync(record); }
                else { var status = pecuaristaService.UpdatePecuaristaAsync(record); }
                
                LimpaCampo();                
                MessageBox.Show("Registro gravado com sucesso....");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar registro....");
            }
            btnPesquisar_Click(sender, e);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)

        {
            var lista1 = pecuaristaService.ListaPecuarista();
            var lista = pecuaristaService.ListaPecuarista().Where(c => c.Name.Trim().Contains(String.IsNullOrEmpty(txtPesquisa.Text) ? c.Name.Trim() : txtPesquisa.Text)
                                            
            ).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Refresh();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Report.fmrRelatorio newMDIChild = new Report.fmrRelatorio();
            newMDIChild.NomeReport = "relpecuarista";
            newMDIChild.Show();
        }

        #region --|Private|--
        private void LimpaCampo()
        {
            txtId.Text = null;            
            txtNome.Text = null;
            txtPesquisa.Text = null;            
            txtNome.Focus();
        }
        //private List<Pecuarista> ListaPecuarista()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Pecuarista");
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
        //                List<Pecuarista> lista = JsonSerializer.Deserialize<List<Pecuarista>>(content.Result, options);
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
        //private async Task<HttpStatusCode> CreatePecuaristaAsync(Pecuarista data)
        //{
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Pecuarista");
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
        //    response.EnsureSuccessStatusCode();
        //    return response.StatusCode;
        //}
        //private async Task<HttpStatusCode> UpdatePecuaristaAsync(Pecuarista data)
        //{
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Pecuarista?id={0}", data.Id));
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.PutAsJsonAsync(_urlBase, data);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.StatusCode;
        //}
        //private async Task<HttpStatusCode> DeletePecuaristaAsync(int id)
        //{
        //    var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Pecuarista/{0}", id));
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.DeleteAsync(_urlBase);
        //    return response.StatusCode;
        //}
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
