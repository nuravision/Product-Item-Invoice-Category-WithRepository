using Domain.Models;
using Service;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Item_Invoice_Category.Controllers
{
    public class ItemController
    {
        private readonly IItemService _itemService;
        public ItemController()
        {
            _itemService=new ItemService();
        }
        public void GetAll()
        {
            var result = _itemService.GetAll();
            if (result.Count() == 0)
            {
                Console.WriteLine("Item not found!");
                return;
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"Id:{item.Id} -  Name:{item.Name} - Count:{item.Count} - Price:{item.Price}");
                }
            }
        }
        public void GetById()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _itemService.GetAll();
            var searchedItem = res.FirstOrDefault(m => m.Id == id);
            if (searchedItem == null)
            {
                Console.WriteLine("Not found item!");
            }
            else
            {
                Console.WriteLine($"Id:{searchedItem.Id} -  Name:{searchedItem.Name} - Count:{searchedItem.Count} - Price:{searchedItem.Price}");
            }
        }

        public void Create()
        {
            string newName;
        Name: Console.Write("Enter new item name: ");
            newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("This field is required!");
                goto Name;
            }
            Console.Write("Enter new item price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter new item count:");
            int newCount = Int32.Parse(Console.ReadLine());

            Item newItem=new Item();
            newItem.Name = newName;
            newItem.Price = newPrice;
            newItem.Count = newCount;
            _itemService.Create(newItem);
            Console.WriteLine("New item created and added!");
        }

        public void Delete()
        {
            Console.Write("Enter deleted item id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _itemService.GetAll();
            var deletedItem = res.FirstOrDefault(m => m.Id == id);
            if (deletedItem == null)
            {
                Console.WriteLine("Not found item!");
            }
            else
            {
                _itemService.Delete(deletedItem);
                Console.WriteLine("Item deleted!");
            }
        }

        public void Edit()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _itemService.GetAll();
            var editedItem = res.FirstOrDefault(m => m.Id == id);
            if (editedItem == null)
            {
                Console.WriteLine("Not found item!");
            }
            else
            {
                Console.Write("Enter new item name:");
                string newName = Console.ReadLine();
                editedItem.Name = newName;

                Console.Write("Enter new item count:");
                int newCount =Int32.Parse(Console.ReadLine());
                editedItem.Count = newCount;

                Console.Write("Enter new item price:");
                decimal newPrice = Decimal.Parse(Console.ReadLine());
                editedItem.Price = newPrice;
                _itemService.Edit(editedItem);
                Console.WriteLine("Item edited!");
            }
        }
    }
}
