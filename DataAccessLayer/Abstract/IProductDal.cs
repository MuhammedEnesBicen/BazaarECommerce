using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal: IGenericDal<Product>
    {
        List<Product> GetListWithProduct(int productId);
        Product GetProductWithJoin(int productId);
        List<Product> GetTopRatedProducts();
        List<Product> GetMostLovedBooks();
        List<Product> FilterProducts(string filterText);

    }
}
