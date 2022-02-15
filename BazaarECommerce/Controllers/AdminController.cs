using AutoMapper;
using BazaarECommerce.Models;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BazaarECommerce.Controllers
{
    public class AdminController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        ProductManager pm = new ProductManager(new EfProductRepository());
        BookManager bookManager = new BookManager(new EfBookRepository());
        ElectronicManager electronicManager = new ElectronicManager(new EfElectronicRepository());
        ImageManager im = new ImageManager();



        public IActionResult Index()
        {
            List<Category> catList = cm.GetAllCategories();
            ViewBag.categories = catList;

            List<Brand> brandList = bm.GetAllBrands();
            ViewBag.brands = brandList;


            ViewBag.productVM = new ProductVM();

            return View();
        }

        [HttpPost]
        public PartialViewResult GetProductsSecondTable(int categoryId)
        {
            ProductVM temp = new ProductVM();
            temp.Product.CategoryId = categoryId;

            return PartialView(temp);
        }

        [HttpPost]
        public async Task AddImagesAsync(List<IFormFile> files, int productId)
        {
            Product product = pm.GetById(productId);

            string fileName = "";
            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                    continue;

                fileName = productId + file.FileName;
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot\\images",
                            fileName);

                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                {
                    continue;
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }
                var imagepath = "/images/" + fileName;
                var tempImage = new Image { ImagePath = imagepath, Product = product };
                product.Images.Add(tempImage);


            }
            pm.ProductUpdate(product);

        }

        [HttpPost]
        public void DeleteImage(int productId, int imageId)
        {
            Product product = pm.GetById(productId);
            string path = product?.Images?.FirstOrDefault(i => i.ImageId == imageId).ImagePath;

            im.ImageDelete(imageId);

            path = path.Replace("/", "\\");
            string current = Directory.GetCurrentDirectory();
            var localPath = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot"
            ) + path;


            FileInfo file = new FileInfo(localPath);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception)
                { }

            }

        }





        public PartialViewResult AddProduct()
        {
            ViewBag.productVM = new ProductVM();
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductVM model)
        {

            switch (model.Product.CategoryId)
            {
                case 1:
                    model.Electronic.Product = model.Product;

                    electronicManager.AddElectronic(model.Electronic);
                    break;
                case 2:
                    model.Electronic.Product = model.Product;

                    electronicManager.AddElectronic(model.Electronic);
                    break;
                case 1003:
                    model.Book.Product = model.Product;
                    bookManager.AddBook(model.Book);
                    break;

                default:
                    break;
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public void DeleteProduct(int productId)
        {
            Product temp = pm.GetById(productId);
            switch (temp.CategoryId)
            {
                case 1:
                    var electronic = electronicManager.GetByProductId(productId);
                    if (electronic != null)
                        electronicManager.DeleteElectronic(electronic);
                    break;
                case 2:
                    var phone = electronicManager.GetByProductId(productId);
                    if (phone != null)
                        electronicManager.DeleteElectronic(phone);
                    break;
                case 1003:
                    var book = bookManager.GetByProductId(productId);
                    if (book != null)
                        bookManager.DeleteBook(book);
                    break;

                default:
                    break;
            }

            foreach (var item in temp?.Images)
            {
                if (item != null)
                {
                    DeleteImage(productId, item.ImageId);
                }
            }
            if (temp != null)
            {
                temp.Images = null;
                pm.ProductDelete(temp);
            }

        }


        [HttpGet]
        public PartialViewResult UpdateProduct(int productId)
        {
            List<Category> catList = cm.GetAllCategories();
            ViewBag.categories = catList;

            List<Brand> brandList = bm.GetAllBrands();
            ViewBag.brands = brandList;

            ProductVM pvm = new ProductVM();
            if (productId > 0)
            {

                var temp = pm.GetById(productId);
                pvm.Product = temp;
                dynamic secondTable;
                switch (temp.CategoryId)
                {
                    case 1:
                        secondTable = electronicManager.GetByProductId(productId);
                        pvm.Electronic = secondTable;
                        break;
                    case 2:
                        secondTable = electronicManager.GetByProductId(productId);
                        pvm.Electronic = secondTable;
                        break;
                    case 1003:
                        secondTable = bookManager.GetByProductId(productId);
                        pvm.Book = secondTable;
                        break;

                    default:
                        break;
                }


                ViewBag.productVM = pvm;
                return PartialView(pvm);
            }

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult UpdateProduct(ProductVM model, int productId)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>());
            IMapper mapper= config.CreateMapper();

            List<Category> catList = cm.GetAllCategories();
            ViewBag.categories = catList;

            List<Brand> brandList = bm.GetAllBrands();
            ViewBag.brands = brandList;

            var tempProduct = pm.GetById(productId);
             model.Product.ProductId = productId;
            tempProduct = mapper.Map<Product>(model.Product);
            pm.ProductUpdate(tempProduct);

            switch (model?.Product?.CategoryId)
            {
                case 1:
                    var electronic = electronicManager.GetByProductId(model.Product.ProductId);
                    if (electronic != null)
                    {
                        model.Electronic.ProductId = model.Product.ProductId;
                        model.Electronic.ElectronicId = electronic.ElectronicId;
                        config = new MapperConfiguration(cfg => cfg.CreateMap<Electronic, Electronic>());
                        mapper = config.CreateMapper();
                        electronic = mapper.Map<Electronic>(model.Electronic);

                        electronicManager.UpdateElectronic(electronic);
                    }
                    break;
                case 2:
                    var phone = electronicManager.GetByProductId(model.Product.ProductId);
                    if (phone != null)
                    {
                        model.Electronic.ProductId = model.Product.ProductId;
                        model.Electronic.ElectronicId = phone.ElectronicId;
                        config = new MapperConfiguration(cfg => cfg.CreateMap<Electronic, Electronic>());
                        mapper = config.CreateMapper();
                        phone = mapper.Map<Electronic>(model.Electronic);
                        electronicManager.UpdateElectronic(phone);
                    }
                    break;
                case 1003:
                    var book = bookManager.GetByProductId(model.Product.ProductId);
                    if (book != null)
                    {
                        model.Book.ProductId = model.Product.ProductId;
                        model.Book.BookId = book.BookId;
                        config = new MapperConfiguration(cfg => cfg.CreateMap<Book, Book>());
                        mapper = config.CreateMapper();
                        book = mapper.Map<Book>(model.Book);
                        bookManager.UpdateBook(book);
                    }
                    break;

                default:
                    break;
            }



            return PartialView();
        }



        public PartialViewResult GetSearchSuggestions(string searchText)
        {
            var list = pm.FilterProducts(searchText);
            return PartialView(list);
        }



        #region BrandOperations
        public PartialViewResult BrandOperations()
        {
            List<Brand> brandList = bm.GetAllBrands();
            return PartialView(brandList);
        }


        [HttpPost]
        public PartialViewResult BrandOperations(int brandId, string brandName, string operation)
        {
            if (operation == "update")
            {
                Brand temp = bm.GetBrandById(brandId);
                temp.BrandName = brandName;
                bm.UpdateBrand(temp);
            }
            else if (operation == "add")
            {
                bm.AddBrand(new Brand { BrandName = brandName });
            }
            else if (operation == "delete")
            {
                bm.DeleteBrandById(brandId);
            }

            var brandList = bm.GetAllBrands();
            return PartialView(brandList);
        }
        #endregion
    }
}
