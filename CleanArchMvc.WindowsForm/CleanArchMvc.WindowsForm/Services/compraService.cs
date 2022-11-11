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
    public static class compraService
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
        public static List<CompraGadoGrid> ListaCompra()
        {
            List<CompraGadoGrid> lstgrid = new List<CompraGadoGrid>();
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Compra");
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
                        List<CompraGado> lista = JsonSerializer.Deserialize<List<CompraGado>>(content.Result, options);

                        foreach (var lst in lista)
                        {
                            lstgrid.Add(new CompraGadoGrid()
                            {
                                Id = lst.Id,
                                dataEntrega = lst.dataEntrega,
                                Pecuarista = lst.Pecuarista.Name,
                                PecuaristaId = lst.PecuaristaId,
                                ValorCompra = lst.valorCompra
                            });
                        }
                        return lstgrid;
                        //dataGridView1.DataSource = lista;
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }        
        public static CompraGado GetCompra(int idCompra)
        {
            CompraGado lstgrid = new CompraGado();
            using (var client = new HttpClient())
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Compra/{0}", idCompra));
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
                        lstgrid = JsonSerializer.Deserialize<CompraGado>(content.Result, options);                        
                        return lstgrid;
                        //dataGridView1.DataSource = lista;
                    }
                    else
                    {
                        return lstgrid; // throw new Exception("Não foi possível obter o produto: " + response.Result.StatusCode);
                    }
                }
            }
        }
        public static async Task<HttpStatusCode> CreateAsync(CompraGado data)
        {
            try
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], "Compra");
                HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync(_urlBase);
                HttpResponseMessage response = await client.PostAsJsonAsync(_urlBase, data);
                response.EnsureSuccessStatusCode();
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                return (new HttpResponseMessage()).StatusCode;
            }
        }
        public static async Task<HttpStatusCode> DeleteAsync(int idCompra)
        {
            try
            {
                var _urlBase = string.Format("{0}{1}", ConfigurationManager.AppSettings["UrlBase"], string.Format("Compra/{0}", idCompra));
                HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync(_urlBase);
                HttpResponseMessage response = await client.DeleteAsync(_urlBase);
                response.EnsureSuccessStatusCode();
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                return (new HttpResponseMessage()).StatusCode;
            }
        }
    }
}
