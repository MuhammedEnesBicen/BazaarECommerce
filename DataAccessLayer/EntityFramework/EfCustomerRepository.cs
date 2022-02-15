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
    public class EfCustomerRepository : GenericRepository<Customer>, ICustomerDal
    {
        public Customer GetByCustomerId(int customerId)
        {
            using (var context = new Context())
            {
                return context.Customers.Where(c => c.CustomerId == customerId).Include(c => c.Address).FirstOrDefault();
            }
        }
    }
}
