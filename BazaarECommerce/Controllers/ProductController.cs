using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _pm = new ProductManager(new EfProductRepository());

        public IActionResult Index(int categoryId)
        {
            var list = _pm.GetByCategory(1);
            return View(list);
        }
    }
}
