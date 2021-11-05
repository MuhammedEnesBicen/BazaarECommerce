using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Controllers
{
    public class LoginController : Controller
    {
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer c)
        {
            ViewBag.message = "";

            var temp = cm.GetByEmail(c.Email);
            if (temp == null)
            {
                ViewBag.message = "There is no such an email in our db.";
            }
            else
            {
                
                if (temp.Password == c.Password) {
                    ViewBag.message = "true";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.message = "Password is wrong!";
                }

            }
            return View();
        }
    }
}
