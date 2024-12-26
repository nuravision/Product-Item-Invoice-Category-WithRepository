using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService()
        {
            _itemRepository = new ItemRepository();
        }
        public void Create(Item item)
        {
            _itemRepository.Create(item);
        }

        public void Delete(Item item)
        {
            _itemRepository.Delete(item);
        }

        public void Edit(Item item)
        {
            _itemRepository.Edit(item);
        }

        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }
    }
}
