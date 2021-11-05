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
    public class EfCardRepository: GenericRepository<Card>, ICardDal
    {
        /*BUranın tam olarak ne yaptığını bilmiyorum,
         * tahminim card ile customer tablosu arasında ilişki kurup getirdiğidir*/
        public List<Card> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Cards.Include(x => x.Customer).ToList();
            }

        }

    }
}
