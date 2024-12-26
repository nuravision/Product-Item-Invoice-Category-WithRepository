using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        void Delete(int id);
        public void Edit(Product product);
        List<Product> GetAll();
        Product GetById(int id);
    }
}
