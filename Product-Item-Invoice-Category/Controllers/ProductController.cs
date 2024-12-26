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
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }
        public void GetAll()
        {
            var res = _productService.GetAll();
            if (res.Count()==0)
            {
                Console.WriteLine("Products not found!");
            }
            else
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Product id:{item.Id} - Product name:{item.Name} " +
        $"- Product price:{item.Price} - Category Id:{item.Category.Id} - Category name:{item.Category.Name}");
                }
            }
        }
            
        public void Create()
        {
            string newName;
        Name: Console.Write("Enter new product name: ");
            newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("This field is required!");
                goto Name;
            }
        CategoryName: Console.Write("Enter new category name: ");
           string newCategoryName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                Console.WriteLine("This field is required!");
                goto Name;
            }
            Category newCategory = new Category();
            newCategory.Name = newCategoryName;
            _categoryService.Create(newCategory);
            Console.WriteLine("Category created!");

            Console.Write("Enter new product price:");
            decimal newPrice=decimal.Parse(Console.ReadLine());
            Product newProduct=new Product();   
            newProduct.Name=newName;
            newProduct.Price=newPrice;
            newProduct.Category=newCategory;
            _productService.Create(newProduct);
            Console.WriteLine("Product added in stock!");
        }

        public void GetById()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _productService.GetAll();
            var searchedCategory = res.FirstOrDefault(m => m.Id == id);
            if (searchedCategory == null)
            {
                Console.WriteLine("Not found product!");
            }
            else
            {
                
                    Console.WriteLine($"Product id:{searchedCategory.Id} - Product name:{searchedCategory.Name} " +
        $"- Product price:{searchedCategory.Price} - Category Id:{searchedCategory.Category.Id} - Category name:{searchedCategory.Category.Name}");
                
            }
        }

        public void Delete()
        {
            Console.Write("Enter deleted product id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _productService.GetAll();
            var deletedProduct = res.FirstOrDefault(m => m.Id == id);
            if (deletedProduct == null)
            {
                Console.WriteLine("Not found product!");
            }
            else
            {
                _productService.Delete(id);
                Console.WriteLine("Product deleted!");
            }
        }

        public void Edit()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _productService.GetAll();
            var editedProduct = res.FirstOrDefault(m => m.Id == id);
            if (editedProduct == null)
            {
                Console.WriteLine("Not found product!");
            }
            else
            {
                Console.Write("Enter new product name:");
                string editProductName = Console.ReadLine();
                editedProduct.Name = editProductName;

                Console.Write("Enter new product price:");
                int newProductPrice = Int32.Parse(Console.ReadLine());
                editedProduct.Price = newProductPrice;

            CategoryName: Console.Write("Enter edit category new name: ");
                string newCategoryName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    Console.WriteLine("This field is required!");
                    goto CategoryName;
                }
                editedProduct.Category.Name = newCategoryName;
                Console.WriteLine("Category created!");
                _productService.Edit(editedProduct);
            }
        }
    }
}
