using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Controllers
{
    public class HomeController : Controller
    {
        CampaignImageManager _ciManager = new CampaignImageManager(new EfCampaignImageRepository());
        ProductManager _pm = new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            var result = _ciManager.GetAll();
            var topRateds = _pm.GetTopRatedProducts();
            ViewBag.toprateds = topRateds;
            return View(result);
        }

        public PartialViewResult TopRatedProducts()
        {
            // logic need to improve
            var result = _pm.GetTopRatedProducts();
            return PartialView(result);
        }




    }
}
