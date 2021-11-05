using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Controllers
{
    public class RegisterController : Controller
    {
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            customer.RegisterDate = DateTime.Now;
            bool result = cm.CustomerAdd(customer);
            //if (cm.GetByEmail(customer.Email)==null)
            //{
                //bu kodlar manager sınıfına taşındı
            //}
            return View();
        }
    }
}
