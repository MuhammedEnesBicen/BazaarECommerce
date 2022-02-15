using BussinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
    public class ProfileController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());
        static int customerId;
        public IActionResult Index()
        {
            customerId=Int32.Parse( HttpContext.Session.GetString("customerId"));
            var temp = customerManager.GetById(customerId);
            return View(temp);
        }

        [HttpPost]
        public IActionResult Index(Customer customer, string whichTable)
        {
            var temp = customerManager.GetById(customerId);
            if (whichTable == "customer")
            {
                temp.Name = customer.Name;
                temp.Surname = customer.Surname;
                temp.BirthDate = customer.BirthDate;
                temp.Gender = customer.Gender;
                temp.Phone = customer.Phone;
                customerManager.CustomerUpdate(temp);
                return View(temp);
            }
            else if(whichTable == "address")
            {
                var address = customer.Address;
                address.AddressId = temp.Address.AddressId;
                address.CustomerId = temp.Address.CustomerId;
                using (var context = new Context())
                {
                    context.Addresses.Update(address);
                    context.SaveChanges();
                }
                temp.Address = address;
                return View(temp);
            }
            return View();
        }

        [HttpPost]
        public ResultModel ChangePassword(string oldPassword, string newPassword)
        {
            var temp = customerManager.GetById(customerId);
            if (temp.Password == oldPassword)
            {
                temp.Password = newPassword;
                customerManager.CustomerUpdate(temp);
                return new ResultModel { Result = true, Message = "Password changed succesfully." };
            }
            return new ResultModel { Result = false, Message = "The password could not be changed. The password you entered is incorrect! " };
        }
    }
}
