using CrudProduct.Models;

namespace CrudProduct.Services.Interfaces;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    void Add(Product produto);
    void Update(Product produto);
    void Delete(int id);
}
