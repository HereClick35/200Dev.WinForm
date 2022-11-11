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

namespace CleanArchMvc.WindowsForm.Services
{
    public static class pecuaristaService
    {
        public static List<Pecuarista> ListaPecuarista()
        {
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Pecuarista");
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
                        List<Pecuarista> lista = JsonSerializer.Deserialize<List<Pecuarista>>(content.Result, options);
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
        public static async Task<HttpStatusCode> CreatePecuaristaAsync(Pecuarista data)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Pecuarista");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> UpdatePecuaristaAsync(Pecuarista data)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Pecuarista?id={0}", data.Id));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(_urlBase, data);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> DeletePecuaristaAsync(int id)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Pecuarista/{0}", id));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(_urlBase);
            return response.StatusCode;
        }
    }
}
