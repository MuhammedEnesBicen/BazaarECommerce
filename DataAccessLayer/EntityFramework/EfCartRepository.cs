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
    public class EfCartRepository : GenericRepository<Cart>, ICartDal
    {
        public bool DeleteById(int cartId)
        {
            using (var context = new Context())
            {
                Cart temp = context.Carts.FirstOrDefault(c => c.CartId == cartId);
                context.Remove(temp);context.SaveChanges();
                return true;
            }
        }

        //Getting with join operations
        public List<Cart> GetListWithProduct(int customerId)
        {
            using (var context = new Context())
            {
                return context.Carts.Where(c => c.CustomerId == customerId).Include(p=> p.Product.Images).Include(cu=> cu.Customer).ToList();
            }
        }

        public bool IncreaseOrDecraseQuantity(int cartId, int quantity)
        {
            using (var context = new Context())
            {
                Cart temp = context.Carts.FirstOrDefault(c => c.CartId == cartId);
                temp.Quantity += quantity;
                context.Update(temp);
                context.SaveChanges();
                return true;
            }
        }
    }
}
