using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        void Create(T entity);
        public void Remove(int id);
        void Edit(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);  
    }
}
