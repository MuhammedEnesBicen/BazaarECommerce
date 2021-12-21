using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICustomerService 
    {
        ResultModel CustomerAdd(Customer customer);
        bool CustomerDelete(Customer customer);
        bool CustomerUpdate(Customer customer);

        Customer GetByEmail(string email);
        Customer GetById(int customerId);

    }
}
