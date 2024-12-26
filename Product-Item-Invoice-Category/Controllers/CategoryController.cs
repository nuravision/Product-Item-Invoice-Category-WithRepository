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
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;

        public delegate bool CategoryFilter(Category category);
      

        public CategoryController()
        {
            _categoryService=new CategoryService();
        }
        public void Create()
        {
            string newName;
            Name: Console.Write("Enter new category name: ");
            newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("This field is required!");
                goto Name;
            }
            Category newCategory = new Category();
            newCategory.Name = newName;
            _categoryService.Create(newCategory);
            Console.WriteLine("Category created!");
        }
        public void GetAll()
        {
            var result=_categoryService.GetAll();
            if (result.Count()==0)
            {
                Console.WriteLine("Categories not found!");
                return;
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"Id:{item.Id} -  Name:{item.Name}");
                }
            }
        }
        public void Delete() { 
            Console.Write("Enter deleted category id:");
            int id=Int32.Parse(Console.ReadLine());
            var res=_categoryService.GetAll();
            var deletedCategory=res.FirstOrDefault(m=>m.Id==id);
            if (deletedCategory==null)
            {
                Console.WriteLine("Not found category!");
            }
            else
            {
                _categoryService.Delete(deletedCategory);
                Console.WriteLine("Category deleted!");
            }
        }
        public void GetById()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _categoryService.GetAll();
            var searchedCategory = res.FirstOrDefault(m => m.Id == id);
            if (searchedCategory == null)
            {
                Console.WriteLine("Not found category!");
            }
            else
            {
                Console.WriteLine($"Id:{searchedCategory.Id} -  Name:{searchedCategory.Name}");
            }
        }
        public void Edit()
        {
            Console.Write("Enter id:");
            int id = Int32.Parse(Console.ReadLine());
            var res = _categoryService.GetAll();
            var editedCategory = res.FirstOrDefault(m => m.Id == id);
            if (editedCategory == null)
            {
                Console.WriteLine("Not found category!");
            }
            else
            {
                Console.Write("Enter new category name:");
                string newName = Console.ReadLine();
                editedCategory.Name = newName;
                _categoryService.Edit(editedCategory);
            }
        }
        public void FilterCategories(CategoryFilter filter)
        {
            var categories = _categoryService.GetAll();
            var filteredCategories = categories.Where(category => filter(category)).ToList();

            if (filteredCategories.Count == 0)
            {
                Console.WriteLine("No categories found matching the filter.");
            }
            else
            {
                foreach (var category in filteredCategories)
                {
                    Console.WriteLine($"Id: {category.Id} - Name: {category.Name}");
                }
            }
        }
        public void GetFilteredCategories()
        {
            Console.Write("Enter a filter keyword:");
            string keyword = Console.ReadLine();

            FilterCategories(category => category.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
