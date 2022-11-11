using CleanArchMvc.WindowsForm.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using static System.Windows.Forms.Design.AxImporter;
using System.Reflection.Metadata;

namespace CleanArchMvc.WindowsForm.Services
{
    public static class compraDetalheService
    {
        public static async Task<HttpStatusCode> CreateAsync(CompraGado data)
        {
            try
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "compra");

                string json = JsonSerializer.Serialize<CompraGado>(data);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
                response.EnsureSuccessStatusCode();
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                return (new HttpResponseMessage()).StatusCode;
            }
        }
        public static async Task<HttpStatusCode> UpdateAsync(CompraGado data)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("compra?id={0}", data.Id));
            string json = JsonSerializer.Serialize<CompraGado>(data);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(_urlBase, data);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("CompraGado/{0}", id));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(_urlBase);
            return response.StatusCode;
        }

        public static List<Animal> ListaAnimal()
        {
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Animal");
                using (var response = client.GetAsync((_urlBase)))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var content = response.Result.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            IncludeFields = true,
                            PropertyNameCaseInsensitive = true
                        };
                        List<Animal> lista = JsonSerializer.Deserialize<List<Animal>>(content.Result, options);
                        return lista;
                        //dataGridView1.DataSource = lista;
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }
        public static Animal GetAnimal(int id)
        {
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Animal/{0}", id));
                using (var response = client.GetAsync((_urlBase)))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var content = response.Result.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            IncludeFields = true,
                            PropertyNameCaseInsensitive = true
                        };
                        Animal lista = JsonSerializer.Deserialize<Animal>(content.Result, options);
                        return lista;
                        //dataGridView1.DataSource = lista;
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }
    }
}
