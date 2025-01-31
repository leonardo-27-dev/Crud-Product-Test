using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudProduct.Models;

namespace CrudProductInterface.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailsModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Product? Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"http://host.docker.internal:8000/api/product");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(jsonResponse) ?? new List<Product>();
                Product = products.FirstOrDefault(m => m.id == id);

                if (Product == null)
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}