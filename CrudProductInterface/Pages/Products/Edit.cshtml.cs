using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudProduct.Models;

namespace CrudProductInterface.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

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
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonProduct = JsonSerializer.Serialize(Product);
            var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"http://host.docker.internal:8000/api/product/{Product.id}", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Erro ao atualizar o produto na API.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}