using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICartService
    {
        bool CartAdd(Cart cart);
        bool CartDelete(Cart cart);
        bool CartUpdate(Cart cart);
        bool CartDelete(int cartId);

        bool IncreaseOrDecreaseQuantity(int cartId,int quantity);


        List<Cart> GetByCustomerId(int customerId);

    }
}
