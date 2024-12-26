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
    public class InvoiceController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IItemService _itemService;
        private readonly ItemController _itemController;
        public InvoiceController()
        {
            _invoiceService = new InvoiceService();
            _itemService = new ItemService();
            _itemController= new ItemController();
        }
        public void Create()
        {
            Console.Write("Enter items count:");
            int itemsCount;
            itemsCount=Int32.Parse(Console.ReadLine());
            
            while (itemsCount > 0) {
                Invoice newInvoice = new Invoice();
                newInvoice.Items = new List<Item>();
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

                Item newItem = new Item()
                {
                    Name = newName,
                    Price = newPrice,
                    Count = newCount
                };
                newInvoice.Items.Add(newItem);
                newInvoice.TotalPrice += newPrice*newCount;
                _invoiceService.Create(newInvoice);
                Console.WriteLine("New item created and added in invoice !");
                itemsCount--;
            }
        }
        public void GetAll()
        {
            var res = _invoiceService.GetAll();
            if (res.Count() == 0)
            {
                Console.WriteLine("No invoices found!");
                return;
            }

            foreach (var invoice in res)
            {
                Console.WriteLine($"Invoice id: {invoice.Id}");
                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Item name: {item.Name}, Item count: {item.Count}, Item price: {item.Price}");
                }
                Console.WriteLine($"Invoice total price: {invoice.TotalPrice}");
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void Delete()
        {
            Console.Write("Enter deleted invoice id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _invoiceService.GetAll();
            var deletedInvoice = res.FirstOrDefault(m => m.Id == id);
            if (deletedInvoice == null)
            {
                Console.WriteLine("Not found invoice!");
            }
            else
            {
                _invoiceService.Delete(deletedInvoice);
                Console.WriteLine("Invoice deleted!");
            }
        }

        public void GetById()
        {
            Console.Write("Enter id: ");
            int id = Int32.Parse(Console.ReadLine());
            var invoices = _invoiceService.GetAll();
            var searchedInvoice = invoices.FirstOrDefault(m => m.Id == id);

            if (searchedInvoice == null)
            {
                Console.WriteLine("Invoice not found!");
            }
            else
            {
                Console.WriteLine($"Invoice Id: {searchedInvoice.Id}");
                Console.WriteLine($"Total Price: {searchedInvoice.TotalPrice}");
                Console.WriteLine("Items in this invoice:");

                foreach (var item in searchedInvoice.Items)
                {
                    Console.WriteLine($" - Name: {item.Name}, Count: {item.Count}, Price: {item.Price}");
                }
            }
        }

        public void Edit()
        {
            Console.Write("Enter invoice ID: ");
            int id = Int32.Parse(Console.ReadLine());
            var invoices = _invoiceService.GetAll();
            var editedInvoice = invoices.FirstOrDefault(m => m.Id == id);

            if (editedInvoice == null)
            {
                Console.WriteLine("Invoice not found!");
                return;
            }

            Console.WriteLine($"Editing Invoice ID: {editedInvoice.Id}");

            Console.WriteLine("Existing items:");
            foreach (var item in editedInvoice.Items)
            {
                Console.WriteLine($"Item Name: {item.Name}, Count: {item.Count}, Price: {item.Price}");
            }

            Console.Write("Enter the name of the item to edit: ");
            string itemName = Console.ReadLine();

            var editedItem = editedInvoice.Items.FirstOrDefault(i => i.Name == itemName);

            if (editedItem == null)
            {
                Console.WriteLine("Item not found in this invoice!");
                return;
            }

            Console.Write("Enter new item name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                editedItem.Name = newName;
            }

            Console.Write("Enter new item count: ");
            int newCount = Int32.Parse(Console.ReadLine());
            editedItem.Count = newCount;

            Console.Write("Enter new item price: ");
            decimal newPrice = Decimal.Parse(Console.ReadLine());
            editedItem.Price = newPrice;
            editedInvoice.TotalPrice = editedInvoice.Items.Sum(item => item.Price * item.Count);
            _invoiceService.Edit(editedInvoice);

            Console.WriteLine("Item edited successfully!");
        }


    }

}
