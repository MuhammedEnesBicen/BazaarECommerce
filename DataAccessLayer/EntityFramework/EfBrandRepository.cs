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
    public class EfBrandRepository : GenericRepository<Brand>, IBrandDal
    {
        public void DeleteBrandById(int brandId)
        {
            using (var context = new Context())
            {
                var allRelatedData = context.Products.Where(b => b.BrandId == brandId)
                    .Include(i=>i.Images)
                    .ToList();
                foreach (var item in allRelatedData)
                {
                    context.Remove(item);
                }
                
                context.SaveChanges();
                var tempBrand = context.Brands.FirstOrDefault(b => b.BrandId == brandId);
                context.Remove(tempBrand);
                context.SaveChanges();
            }
        }

        public Brand GetBrandById(int brandId)
        {
            using (var context = new Context())
            {
                return context.Brands.FirstOrDefault(b => b.BrandId == brandId);
            }
        }
    }
}
