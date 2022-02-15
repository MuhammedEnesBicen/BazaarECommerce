using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http;
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
        CartManager _cm = new CartManager(new EfCartRepository());
        public IActionResult Index()
        {
            var result = _ciManager.GetAll();
            var topRateds = _pm.GetTopRatedProducts();
            ViewBag.toprateds = topRateds;
            var mostLoved = _pm.GetMostLovedBooks();
            ViewBag.mostLoved = mostLoved;
            return View(result);
        }

        public PartialViewResult TopRatedProducts()
        {
            var result = _pm.GetTopRatedProducts();
            return PartialView(result);
        }

        public PartialViewResult MostLovedBooks()
        {
            //var result = _pm.GetMostLovedBooks(); bu kodlar çıkarıldı çalışmaya devam ederse top rated dan da çıkarılmalı
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult GetCartPreviewPopup()
        {
            string cId = HttpContext.Session.GetString("customerId");
            var result = _cm.GetByCustomerId(Int32.Parse(cId)); // we just brings max 2 cart items

            double totalCost = 0;
            double totalDiscount = 0;
            foreach (var item in result)
            {
                totalCost += item.Product.Price * item.Quantity;
                totalDiscount += item.Product.Discount * item.Quantity;
            }
            ViewBag.totalCost = totalCost - totalDiscount;
            

            var cart = result.Take(2);
            return PartialView(cart);
        }



        //When the user clicks on the profile button, redirecting herself/himself to the login or profile page according to the session information
        public IActionResult RouteLoginOrProfile()
        {
            String session = HttpContext.Session.GetString("customerId");
            if (session != null) return RedirectToAction("Index","Profile");
            else return RedirectToAction("Index","Login");


        }

        public bool IsAuthorize()
        {
            String session = HttpContext.Session.GetString("customerId");
            if (session != null) return true;
            else return false;
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("customerId");
            return RedirectToAction("Index");
        }



    }
}
