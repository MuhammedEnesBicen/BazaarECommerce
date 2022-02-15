using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal: IGenericDal<Customer>
    {

        //public Customer GetByEmail(string email);
        public Customer GetByCustomerId(int customerId);
    }
}
