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
    public class CartManager : ICartService
    {
        ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public bool CartAdd(Cart cart)
        {
            _cartDal.Insert(cart);
            return true;
        }

        public bool CartDelete(Cart cart)
        {
            _cartDal.Delete(cart);
            return true;
        }

        public bool CartDelete(int cartId)
        {
            _cartDal.DeleteById(cartId);
            return true;
        }

        public bool CartUpdate(Cart cart)
        {
            _cartDal.Update(cart);
            return true;
        }

        public List<Cart> GetByCustomerId(int customerId)
        {
            return _cartDal.GetListWithProduct(customerId);
        }

        public bool IncreaseOrDecreaseQuantity(int cartId, int quantity)
        {
            return _cartDal.IncreaseOrDecraseQuantity(cartId, quantity);
        }
    }
}
