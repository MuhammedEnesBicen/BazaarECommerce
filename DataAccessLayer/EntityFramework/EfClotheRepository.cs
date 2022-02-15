using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfClotheRepository : GenericRepository<Clothe>, IClotheDal
    {
        public void DeleteClotheById(int clotheId)
        {
            using (var context = new Context())
            {
                Clothe temp = context.Clothes.FirstOrDefault(c => c.ClotheId == clotheId);
                context.Remove(temp);
                context.SaveChanges();
            }
        }

        public Clothe GetClotheById(int clotheId)
        {
            using (var context = new Context())
            {
                return context.Clothes.FirstOrDefault(c => c.ClotheId == clotheId);
            }
        }
    }
}
