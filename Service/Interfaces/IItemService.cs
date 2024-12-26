using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IItemService
    {
        void Create(Item item);
        void Delete(Item item);
        void Edit(Item item);
        Item GetById(int id);
        List<Item> GetAll();
    }
}
