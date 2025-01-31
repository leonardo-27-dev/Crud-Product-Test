using System;
using System.Collections.Generic;
using CrudProduct.Models;
using CrudProduct.Repositories.Interfaces;
using CrudProduct.Services.Interfaces;

namespace CrudProduct.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _productRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar produtos.", ex);
            }
        }

        public void Add(Product produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            try
            {
                _productRepository.Add(produto);
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
                var existingProduct = _productRepository.GetById(produto.id);
                if (existingProduct == null) throw new KeyNotFoundException("Produto não encontrado para atualização.");

                _productRepository.Update(produto);
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
                var existingProduct = _productRepository.GetById(id);
                if (existingProduct == null) throw new KeyNotFoundException("Produto não encontrado para exclusão.");

                _productRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao excluir produto.", ex);
            }
        }
    }
}