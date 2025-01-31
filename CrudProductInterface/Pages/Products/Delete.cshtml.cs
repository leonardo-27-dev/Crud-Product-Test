using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrudProduct.Models;
using System.Text.Json;

namespace CrudProductInterface.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public Product Product { get; set; } = default!;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

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
                Product? product = products.FirstOrDefault(m => m.id == id);

                if (product == null)
                {
                    return NotFound();
                }

                Product = product;
            }
            else
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.DeleteAsync($"http://host.docker.internal:8000/api/product/{id}");

            if (response.IsSuccessStatusCode)
            {
                // A exclusão é tratada pela API, então não é necessário interagir diretamente com o banco aqui
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao excluir o produto.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}