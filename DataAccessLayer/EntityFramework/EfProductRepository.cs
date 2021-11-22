using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository: GenericRepository<Product>,IProductDal
    {
        public List<Product> GetListWithProduct(int categoryId)
        {
            using (var context = new Context())
            {
                //var result = from p in context.Products
                //             join c in context.Categories
                //             on p.CategoryId equals c.CategoryId
                //             join s in context.Sellers
                //             on p.SellerId equals s.SellerId
                //             join b in context.Brands
                //             on p.BrandId equals b.BrandId
                //             join i in context.Images
                //             on p.ProductId equals i.ProductId
                //             select new Product
                //             {
                //                 ProductId = p.ProductId,
                //                 ProductName = p.ProductName,
                //                 Category =c,
                //                 Brand=b,
                //                 Seller=s,
                //                 Price=p.Price,
                //                 StarRate =p.StarRate,
                //                 Discount=p.Discount,
                //                 Description=p.Description,
                //                 Images =i

                //             };
                //return result.ToList();


                return context.Products.Where(p=> p.CategoryId==categoryId).Include(i => i.Images).Include(s=> s.Seller).Include(b=>b.Brand).Include(ca =>ca.Category)
                    .ToList();
            }
        }
    }
}
