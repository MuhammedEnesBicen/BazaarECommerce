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

        public List<Product> FilterProducts(string filterText)
        {
            return _productDal.FilterProducts(filterText);
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetListWithProduct(categoryId);
        }

        public Product GetById(int id)
        {
            return _productDal.GetProductWithJoin(id);
        }

        public List<Product> GetMostLovedBooks()
        {
            return _productDal.GetMostLovedBooks();
        }

        public List<Product> GetTopRatedProducts()
        {
            return _productDal.GetTopRatedProducts();
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
