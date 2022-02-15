using BussinessLayer.Concrete;
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
        static bool rememberMe=false;
        static Customer customer; // if user had wanted be remembered, this object will be initialized
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        public IActionResult Index()
        {
            
            String mail = Request.Cookies["customerMail"];
            String password = Request.Cookies["customerPassword"];
            if (mail != null && password != null)
            {
                rememberMe = true;
                ViewBag.rememberMe = rememberMe;
                customer = new Customer { Email = mail, Password = password };
                return View(customer);
            }

            ViewBag.rememberMe = rememberMe;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer c)
        {
            ViewBag.rememberMe = rememberMe;
            var temp = cm.GetByEmail(c.Email);
            if (temp == null) ViewBag.message = "There is no such an email in our db.";
            else
            {
                if (temp.Password == c.Password)
                {
                    if (rememberMe && customer == null) CookieOperations("save", c.Email.ToString(), c.Password.ToString());
                    if (!rememberMe && customer != null) CookieOperations("delete", "", "");

                    HttpContext.Session.SetString("customerId", temp.CustomerId.ToString());
                    ViewBag.message = "true";
                    return RedirectToAction("Index", "Home");
                }
                else ViewBag.message = "Password is wrong!";
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


        [HttpPost]
        public void ChangeRememberMeOption(bool value)
        {
            rememberMe = value;
        }


        public void CookieOperations(string job, string email, string password)
        {
            switch (job)
            {
                case "save":
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddMonths(2);
                    Response.Cookies.Append("customerMail", email, cookie);
                    Response.Cookies.Append("customerPassword", password, cookie);
                    break;
                case "delete":
                    Response.Cookies.Delete("customerMail");
                    Response.Cookies.Delete("customerPassword");
                    break;
                default:
                    break;
            }
        }
    }


}
