using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        public List<Product> GetBySeller(int sellerId)
        {
            return _productDal.GetAll(p => p.SellerId == sellerId);
        }

        public bool ProductAdd(Product product)
        {

            _productDal.Insert(product);
            return true;
        }

        public bool ProductDelete(Product product)
        {
            _productDal.Delete(product);
            return true;
        }

        public bool ProductUpdate(Product product)
        {
            _productDal.Update(product);
            return true;
        }
    }
}
