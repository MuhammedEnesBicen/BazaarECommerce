using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _iCustomerDal;

        public CustomerManager(ICustomerDal iCustomerDal)
        {
            _iCustomerDal = iCustomerDal;
        }

        public bool CustomerAdd(Customer customer)
        {
            if (_iCustomerDal.Get(c=> c.Email ==customer.Email) != null)
            {
                return false;
            }

            try
            {
                _iCustomerDal.Insert(customer);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool CustomerDelete(Customer customer)
        {
            try
            {
                _iCustomerDal.Delete(customer);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool CustomerUpdate(Customer customer)
        {
            try
            {
                _iCustomerDal.Update(customer);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public Customer GetByEmail(string email)
        {
           return  _iCustomerDal.Get(c=> c.Email==email);
        }
    }
}
