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
    public class EfCustomerRepository : GenericRepository<Customer>, ICustomerDal
    {
        //public Customer GetByEmail(string email)
        //{
        //    using (var context = new Context())
        //    {
        //        /*BU kullanımın doğruluğundan emin değilim*/
        //        return context.Customers.Where(x=> x.Email == email).FirstOrDefault();
        //    }
        //}
    }
}
