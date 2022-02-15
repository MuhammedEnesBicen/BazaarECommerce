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
    public class EfElectronicRepository : GenericRepository<Electronic>, IElectronicDal
    {
        public List<Electronic> GetListWithProduct()
        {
            using (var c = new Context())
            {
                return c.Electronics.Include(p => p.Product)
                    .Include(c => c.Product.Images)
                    .Include(c => c.Product.Category)
                    .Include(c => c.Product.Brand).ToList();
            }
        }
    }
}
