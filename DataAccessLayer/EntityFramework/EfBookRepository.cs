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
    public class EfBookRepository : GenericRepository<Book>, IBookDal
    {
        public ResultModel DeleteById(int bookId)
        {
            using (var context = new Context())
            {
                Book temp = context.Books.FirstOrDefault(b => b.BookId == bookId);
                context.Remove(temp);
                context.SaveChanges();
                return new ResultModel { Message = "Book deletion successful", Result = true };
            }
        }

        public Book GetById(int bookId)
        {
            using (var context = new Context())
            {
                Book temp = context.Books.FirstOrDefault(b => b.BookId == bookId);
                return temp;
            }
        }

        public Book GetByProductId(int productId)
        {
            using (var context = new Context())
            {
                Book temp = context.Books.FirstOrDefault(b => b.ProductId == productId);
                return temp;
            }
        }
    }
}
