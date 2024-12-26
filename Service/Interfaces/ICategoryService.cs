using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        void Create(Category category);
        void Delete(Category category);
        void Edit(Category category);
        Category GetById(int id);
        List<Category> GetAll();
    }
}
