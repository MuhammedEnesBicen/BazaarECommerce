using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;

namespace ConsoleWeb
{
    class Program
    {
        static void CustomerManCOdes()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
            Customer c = new Customer()
            {
                Name = "Enes",
                BirthDate = DateTime.Parse("10.12.1999"),
                EarnedPoint = 0,
                Email = "email",
                Gender = "man",
                Password = "1234",
                Phone = "123",
                PhotoPath = "qwqe",
                Surname = "12"

            };
            //customerManager.CustomerAdd(c);
            Customer a = customerManager.GetByEmail("email");
            Console.WriteLine("Hello World!" + a.Cards);
        }
        
        static void Main(string[] args)
        {
            ComputerManager cm = new ComputerManager(new EfComputerRepository());
            ProductManager pm = new ProductManager(new EfProductRepository());
            for (int i = 0; i < 5; i++)
            {


                pm.ProductAdd(new Product
                {
                    ProductName = "MSI pc",
                    BrandId = 1,
                    CategoryId = 1,
                    Description = "msi notebook",
                    Discount = 12,
                    Installment = 6,
                    Price = 12000,
                    StarRate = 4.8
                });
                cm.AddComputer(new Computer
                {
                    ProductId = 2,
                    ColorId = 1,
                    DisplayCard = "2gb",
                    Memory = 126,
                    MemoryType = "ssd",
                    OperatingSystem = "MAC",
                    Processor = "i7",
                    Ram = 8,
                    ScreenSize = "17.1",
                    Webcam = true
                });
            }
            //var a =cm.GetListWithProduct();
            //Console.WriteLine(a[0].Product.Description);

        }
    }
}
