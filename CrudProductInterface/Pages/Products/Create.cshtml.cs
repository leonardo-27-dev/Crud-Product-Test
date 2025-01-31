using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CrudProduct.Models;

namespace CrudProductInterface.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonProduct = JsonSerializer.Serialize(Product);
            var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://host.docker.internal:8000/api/product", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Erro ao enviar os dados para a API.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}