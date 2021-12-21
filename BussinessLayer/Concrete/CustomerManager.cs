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

        public ResultModel CustomerAdd(Customer customer)
        {
            if (_iCustomerDal.Get(c=> c.Email ==customer.Email) != null)
            {
                return new ResultModel { Result=false, Message= "There is already an account using this email address." };
            }

            try
            {
                _iCustomerDal.Insert(customer);
            }
            catch (Exception)
            {

                return  new ResultModel { Result = false, Message = "An error occured during the register process.Unfortunatelly your account didnt created. we are sory" }; ;
            }
            return  new ResultModel { Result = true, Message = "Register Succesfull. Welcome "+customer.Name +". Now login and enjoy the shopping" }; ;
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

        public Customer GetById(int customerId)
        {
            return _iCustomerDal.Get(c => c.CustomerId == customerId);
        }
    }
}
