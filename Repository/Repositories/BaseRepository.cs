using Domain.Common;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private static int _id = 1;
        public void Create(T entity)
        {
            entity.Id = _id++;
            AppDbContext<T>.Datas.Add(entity);
        }

        public void Delete(T entity)
        {
            AppDbContext<T>.Datas.Remove(entity);
        }
        public void Remove(int id)
        {
            AppDbContext<T>.Datas.RemoveAt(id);
        }
        public void Edit(T entity)
        {
            var existingEntity=AppDbContext<T>.Datas.FirstOrDefault(d=>d.Id==entity.Id);
            if (existingEntity != null) { 
                int index=AppDbContext<T>.Datas.IndexOf(existingEntity);
                AppDbContext<T>.Datas[index]=entity;
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }

        public List<T> GetAll()
        {
            return AppDbContext<T>.Datas.ToList();
        }

        public T GetById(int id)
        {
            return AppDbContext<T>.Datas.FirstOrDefault(d => d.Id == id);
        }
    }
}
