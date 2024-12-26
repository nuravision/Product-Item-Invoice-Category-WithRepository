using Product_Item_Invoice_Category.Controllers;

CategoryController categoryController = new CategoryController();
ProductController productController = new ProductController();
ItemController itemController = new ItemController();
InvoiceController invoiceController = new InvoiceController();
while (true)
{
    Choice:
    Console.WriteLine("Operations:");
    Console.WriteLine("1-Category Operations 2-Product Operations 3-Item Operations  4-Invoice Operations");
    Console.Write("Enter your choice:");
    int choice=Int32.Parse(Console.ReadLine());
    if (choice == 1)
    {
    CategoryChoice:
        Console.WriteLine("1-Get All Categories  2-Create Category  3-Delete Category  4-GetById 5-Update");
        Console.Write("Enter your choice:");
        int categoryChoice = Int32.Parse(Console.ReadLine());
        if (categoryChoice == 1)
        {
            categoryController.GetAll();
        }
        else if (categoryChoice == 2)
        {
            categoryController.Create();
        }
        else if (categoryChoice == 3)
        {
            categoryController.Delete();
        }
        else if (categoryChoice == 4)
        {
            categoryController.GetById();
        }
        else if (categoryChoice == 5)
        {
            categoryController.Edit();
        }
        else
        {
            Console.WriteLine("Your choice is wrong! Enter true choice:");
            goto CategoryChoice;
        }
    }
    else if (choice == 2) {
    ProductChoice:
        Console.WriteLine("1-Get All Products  2-Create Product  3-GetByIdProduct  4-Delete Product 5-Update Product");
        Console.Write("Enter your choice:");
        int productChoice = Int32.Parse(Console.ReadLine());
        if (productChoice == 1)
        {
            productController.GetAll();
        }
        else if (productChoice == 2)
        {
            productController.Create();
        }
        else if (productChoice == 3)
        {
            productController.GetById();
        }
        else if (productChoice == 4)
        {
            productController.Delete();
        }
        else if (productChoice == 5)
        {
            productController.Edit();
        }
        else
        {
            Console.WriteLine("Your choice is wrong! Enter true choice:");
            goto ProductChoice;
        }
    }
    else if (choice == 3)
    {
    ItemChoice:
        Console.WriteLine("1-Get All Items  2-Create Item  3-GetByIdItem  4-Delete Item 5-Update Item");
        Console.Write("Enter your choice:");
        int itemChoice = Int32.Parse(Console.ReadLine());
        if (itemChoice == 1)
        {
            itemController.GetAll();
        }
        else if (itemChoice == 2)
        {
            itemController.Create();
        }
        else if (itemChoice == 3)
        {
            itemController.GetById();
        }
        else if (itemChoice == 4)
        {
            itemController.Delete();
        }
        else if (itemChoice == 5)
        {
            itemController.Edit();
        }
        else
        {
            Console.WriteLine("Your choice is wrong! Enter true choice:");
            goto ItemChoice;
        }
    }
    else if (choice == 4)
    {
    InvoiceChoice:
        Console.WriteLine("1-Get All Invoices  2-Create Invoice  3-GetByIdInvoice 4-Delete Invoice 5-Update Invoice");
        Console.Write("Enter your choice:");
        int invoiceChoice = Int32.Parse(Console.ReadLine());
        if (invoiceChoice == 1)
        {
            invoiceController.GetAll();
        }
        else if (invoiceChoice == 2)
        {
            invoiceController.Create();
        }
        else if (invoiceChoice == 3)
        {
            invoiceController.GetById();
        }
        else if (invoiceChoice == 4)
        {
            invoiceController.Delete();
        }
        else if (invoiceChoice == 5)
        {
            invoiceController.Edit();
        }
        else
        {
            Console.WriteLine("Your choice is wrong! Enter true choice:");
            goto InvoiceChoice;
        }
    }
    else
    {
        Console.WriteLine("Your choice is wrong! Enter true choice:");
        goto Choice;
    }
}