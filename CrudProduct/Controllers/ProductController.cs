using Microsoft.AspNetCore.Mvc;
using CrudProduct.Models;
using CrudProduct.Services.Interfaces;

namespace CrudProduct.Controllers;

[Route("api/product")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProductService _produtoService;

    public ProdutoController(IProductService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_produtoService.GetAll());

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        _produtoService.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        if (id != product.id) return BadRequest("ID inválido.");
        _produtoService.Update(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _produtoService.Delete(id);
        return NoContent();
    }
}
