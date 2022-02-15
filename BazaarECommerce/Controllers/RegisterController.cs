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
            ResultModel result = cm.CustomerAdd(customer);
            if (result.Result) ViewBag.message2 = result.Message;
            else ViewBag.message = result.Message;
            return View();
        }
    }
}
