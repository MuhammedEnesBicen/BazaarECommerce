using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
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
            //String a = HttpContext.Session.GetString("customerId");
            String b = Request.Cookies["customerId"]; //currenty any cookie didn't saved
            if (b != null)
            {
                Customer temp = cm.GetById(Int32.Parse(b));
                return View(temp);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer c, bool rememberMe)
        {
            ViewBag.message = "";

            var temp = cm.GetByEmail(c.Email);
            if (temp == null)
            {
                ViewBag.message = "There is no such an email in our db.";
            }
            else
            {

                if (temp.Password == c.Password)
                {
                    //CookieOptions cookie = new CookieOptions();
                    //cookie.Expires = DateTime.Now.AddYears(10);
                    //Response.Cookies.Append("customerId", temp.CustomerId.ToString(), cookie);
                    HttpContext.Session.SetString("customerId", temp.CustomerId.ToString());
                    ViewBag.message = "true";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Password is wrong!";
                }

            }
            return View();
        }


        public bool Validate(string email, string password)
        {
            var temp = cm.GetByEmail(email);
            if (temp == null)
            {
                return false;
            }
            else
            {

                if (temp.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }


}
