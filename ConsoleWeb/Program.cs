using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;

namespace ConsoleWeb
{
    class Program
    {

        static void Main(string[] args)
        {
            ElectronicManager cm = new ElectronicManager(new EfElectronicRepository());
            ProductManager pm = new ProductManager(new EfProductRepository());
            //CreateProducts(cm, pm);
            //var a =cm.GetListWithProduct();
            //Console.WriteLine(a[0].Product.Description);

            //Customer jobs
            CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
            var temp = customerManager.GetById(1);
            Console.WriteLine(temp.Address.AddressText);

        }

        
    }
}
