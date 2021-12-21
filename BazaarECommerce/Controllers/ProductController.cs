using BazaarECommerce.Views.Product;
using BussinessLayer.Abstract;
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
    public class ProductController : Controller
    {
        private ProductManager _pm = new ProductManager(new EfProductRepository());
        private ComputerManager _cm = new ComputerManager(new EfComputerRepository());
        private BookManager _bm = new BookManager(new EfBookRepository());
        FilterModel filterModel;

        public ProductController()
        {
            filterModel = new FilterModel { BrandIds = new List<int>(), StarRates = new List<int>() };
        }

        public IActionResult Index(int categoryId)
        {
            ViewBag.category = categoryId;
            ViewData["filterModel"] = new FilterModel { BrandIds=new List<int>(), StarRates= new List<int>()};
            var list = _pm.GetByCategory(categoryId);
            return View(list);
        }



        public IActionResult GetProductDetail(int productId)
        {
            var product = _pm.GetById(productId);
            dynamic secondTable;
            switch (product.CategoryId)
            {
                case 2:
                    secondTable = _cm.GetByProductId(productId);
                    break;
                case 1003:
                    secondTable = _bm.GetByProductId(productId);
                    break;

                default:
                    secondTable = _bm.GetByProductId(productId);
                    break;
            }
             

            //ViewData["product"] = product;
            //ViewData["computer"] = computer;
            ViewBag.secondTable = secondTable;
            return View(product);
        }

        public PartialViewResult GetFilteredProducts(int categoryId,int brandId)
        {
            if (filterModel.BrandIds.Contains(brandId)) filterModel.BrandIds.Remove(brandId);
            else filterModel.BrandIds.Add(brandId);


            var products = _pm.GetByCategory(categoryId);
            //var a = products.Where(p => p.BrandId ==brandId).ToList();
            var a = products.Where(p => filterModel.BrandIds.Contains(p.BrandId)).ToList();



            return PartialView(a);
        }



    }
}
