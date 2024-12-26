using Repository.Repositories.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using Domain.Models;

namespace Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }
       
        public void Edit(Product product)
        {
            _productRepository.Edit(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
