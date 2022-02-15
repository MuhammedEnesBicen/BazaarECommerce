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
        private ElectronicManager _cm = new ElectronicManager(new EfElectronicRepository());
        private BookManager _bm = new BookManager(new EfBookRepository());
        static FilterModel filterModel;
        static List<Product> products;


        public IActionResult Index(int categoryId)
        {
            ViewBag.category = categoryId;
            filterModel = new FilterModel { BrandIds = new List<int>(), StarRates = new List<int>(),Searchtext="",MinPrice=0 };
            var list = _pm.GetByCategory(categoryId);
            products = list;
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

        [HttpPost]
        public void BrandFilter(int brandId)
        {
            if (filterModel.BrandIds.Contains(brandId)) filterModel.BrandIds.Remove(brandId);
            else filterModel.BrandIds.Add(brandId);
        }

        [HttpPost]
        public void StarFilter(int starRate)
        {
            if (filterModel.StarRates.Contains(starRate)) filterModel.StarRates.Remove(starRate);
            else filterModel.StarRates.Add(starRate);
        }

        [HttpPost]
        public void TextFilter(string text)
        {
            filterModel.Searchtext = text;
        }
        [HttpPost]
        public void PriceFilter(int min, int max)
        {
            filterModel.MinPrice = min;
            filterModel.MaxPrice = max;

        }

        [HttpPost]
        public PartialViewResult GetFilteredProducts()
        {
            List<Product> list= products;
            if (!String.IsNullOrEmpty(filterModel.Searchtext))
            {
                list = list.Where(p => p.ProductName.ToLower().Contains(filterModel.Searchtext.ToLower())).ToList();
            }
            if (filterModel.MinPrice != 0)
            {
                list = list.Where(p => p.Price-p.Discount >= filterModel.MinPrice).ToList();
            }
            if (filterModel.MaxPrice != 0)
            {
                list = list.Where(p => p.Price - p.Discount <= filterModel.MaxPrice).ToList();
            }
            if (filterModel.BrandIds.Count>0)
                list = list.Where(p => filterModel.BrandIds.Contains(p.BrandId)).ToList();
            if (filterModel.StarRates.Count > 0)
            {
                var tempList = new List<Product>();
                foreach (var rate in filterModel.StarRates)
                {
                    switch (rate)
                    {
                        case 0:
                            tempList = tempList.Concat(list.Where(p=>(p.StarRate>=0 && p.StarRate<2)).ToList()).ToList();
                            break;
                        case 2:
                            tempList = tempList.Concat(list.Where(p => (p.StarRate >= 2 && p.StarRate < 3)).ToList()).ToList();
                            break;
                        case 3:
                            tempList = tempList.Concat(list.Where(p => (p.StarRate >= 3 && p.StarRate < 4)).ToList()).ToList();
                            break;
                        case 4:
                            tempList = tempList.Concat(list.Where(p => (p.StarRate >= 4 && p.StarRate <= 5)).ToList()).ToList();
                            break;
                    }
                }
                list = tempList;
            }



            return PartialView(list);
        }



    }
}
