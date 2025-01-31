using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CrudProduct.Data;
using CrudProduct.Models;
using CrudProduct.Repositories.Interfaces;

namespace CrudProduct.Repositories.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _context.Produtos.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar produtos.", ex);
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _context.Produtos.FirstOrDefault(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar o produto com ID {id}.", ex);
            }
        }

        public void Add(Product produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao adicionar produto.", ex);
            }
        }

        public void Update(Product produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            try
            {
                var existingProduct = _context.Produtos.FirstOrDefault(p => p.id == produto.id);
                if (existingProduct == null) throw new KeyNotFoundException("Produto não encontrado para atualização.");

                _context.Entry(existingProduct).CurrentValues.SetValues(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao atualizar produto.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var produto = _context.Produtos.Find(id);
                if (produto == null) throw new KeyNotFoundException("Produto não encontrado para exclusão.");

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao excluir produto com ID {id}.", ex);
            }
        }
    }
}
