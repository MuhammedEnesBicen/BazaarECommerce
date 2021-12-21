using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICartDal: IGenericDal<Cart>
    {
        //Getting with join operations
        List<Cart> GetListWithProduct(int customerId);
        bool IncreaseOrDecraseQuantity(int cartId, int quantity);
        bool DeleteById(int cartId);
    }
}
