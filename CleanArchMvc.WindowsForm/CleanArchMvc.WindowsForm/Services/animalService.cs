using CleanArchMvc.WindowsForm.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanArchMvc.WindowsForm.Classes
{
    public static class animalService
    {
        #region --|Private|--        
        public static List<Animal> ListaAnimal()
        {
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "animal");
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
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }
        public static Animal GetAnimal(int idAnimal)
        {
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("animal/{0}", idAnimal));
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
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }
        public static async Task<HttpStatusCode> CreateAnimalAsync(Animal data)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Animal");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> UpdateAnimalAsync(Animal data)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Animal?id={0}", data.Id));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync(_urlBase, data);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.StatusCode;
        }
        public static async Task<HttpStatusCode> DeleteAnimalAsync(int id)
        {
            var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Animal/{0}", id));
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(_urlBase);
            return response.StatusCode;
        }        
        #endregion
    }
}
