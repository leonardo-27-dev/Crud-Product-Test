using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudProduct.Models;

namespace CrudProductInterface.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("http://host.docker.internal:8000/api/product");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Product = JsonSerializer.Deserialize<List<Product>>(jsonResponse) ?? new List<Product>();
            }
            else
            {
                Product = new List<Product>();
            }
        }
    }
}