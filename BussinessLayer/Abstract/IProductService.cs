using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IProductService
    {
        bool ProductAdd(Product product);
        bool ProductUpdate(Product product);
        bool ProductDelete(Product product);

        List<Product> GetByCategory(int categoryId);
        Product GetById(int id);
        List<Product> GetBySeller(int sellerId);
    }
}
