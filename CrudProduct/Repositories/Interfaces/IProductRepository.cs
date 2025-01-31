using CrudProduct.Models;

namespace CrudProduct.Repositories.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Add(Product produto);
    void Update(Product produto);
    void Delete(int id);
}
