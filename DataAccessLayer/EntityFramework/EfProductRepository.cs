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
                #region Alternative Version
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
                #endregion

                return context.Products.Where(p=> p.CategoryId==categoryId).Include(i => i.Images).Include(b=>b.Brand).Include(ca =>ca.Category)
                    .ToList();
            }
        }

        public List<Product> GetMostLovedBooks()
        {
            using (var context = new Context())
            {
                return context.Products.Where(p => p.CategoryId == 1003).OrderByDescending(p => p.StarRate).Take(12).Include(i => i.Images).Include(b => b.Brand).Include(ca => ca.Category)
                    .ToList();
            }
        }

        public Product GetProductWithJoin(int productId)
        {
            using (var context = new Context())
            {
                Product temp = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (temp != null)
                {
                    temp.Images = context.Images.Where(i => i.ProductId == productId).ToList();
                    temp.Brand = context.Brands.FirstOrDefault(b => b.BrandId == temp.BrandId);
                    temp.Category = context.Categories.FirstOrDefault(c => c.CategoryId == temp.CategoryId);
                }
                return temp;

            }
        }

        public List<Product> GetTopRatedProducts()
        {
            using (var context = new Context())
            {
                return context.Products.Where(p=>p.CategoryId!=1003).OrderByDescending(p=>p.StarRate).Take(12).Include(i => i.Images).Include(b => b.Brand).Include(ca => ca.Category)
                    .ToList();
            }
        }

        public List<Product> FilterProducts(string filterText)
        {
            using (var context = new Context())
            {
                return context.Products.Where(p => p.ProductName.Contains(filterText)).Take(4).ToList();
            }
        }
    }
}
