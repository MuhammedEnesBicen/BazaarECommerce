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
    public class CartController : Controller
    {
        CartManager cm = new CartManager(new EfCartRepository());
        public IActionResult Index(int customerId)
        {
            //int cusId = Int32.Parse(Request.Cookies["customerId"]); getting with cookie
            int cusId = Int32.Parse(HttpContext.Session.GetString("customerId"));// getting with session
            var result = cm.GetByCustomerId(cusId);
            double totalCost = 0;
            double totalDiscount = 0;
            foreach (var item in result)
            {
                totalCost += item.Product.Price * item.Quantity;
                totalDiscount += item.Product.Discount * item.Quantity;
            }
            ViewBag.totalCost = totalCost;
            ViewBag.totalDiscount = totalDiscount;
            return View(result);
        }


        public PartialViewResult UpdateCartQuantity(int cartId,int quantity)
        {
            cm.IncreaseOrDecreaseQuantity(cartId, quantity);
            int cusId = Int32.Parse(HttpContext.Session.GetString("customerId"));// getting with session
            var result = cm.GetByCustomerId(cusId);
            double totalCost = 0;
            double totalDiscount = 0;
            foreach (var item in result)
            {
                totalCost += item.Product.Price * item.Quantity;
                totalDiscount += item.Product.Discount * item.Quantity;
            }
            ViewBag.totalCost = totalCost;
            ViewBag.totalDiscount = totalDiscount;
            return PartialView(result);



        }

        public ResultModel AddItemToCart(int productId,int quantity, int customerId)
        {
            int cusId = Int32.Parse(HttpContext.Session.GetString("customerId"));// getting with session
            //it should be validation codes in here, for example if quantity of product is less than 1 then func has to return false as result
            if (quantity<1) return new ResultModel { Result = false, Message = "Product is not added your cart, because we dont have any!" };
            cm.CartAdd(new Cart { ProductId = productId, CustomerId = cusId, Quantity = 1 });
            return new ResultModel { Result = true, Message = "Product added to your cart!" };
        }

        public IActionResult DeleteCart(int cartId)
        {

            cm.CartDelete(cartId);
            return RedirectToAction("Index");

        }

        public bool EmptyCart(int customerId)
        {
            var result = cm.GetByCustomerId(customerId);
            foreach (var item in result)
            {
                cm.CartDelete(item);
            }
            
            return true;

        }
    }
}
