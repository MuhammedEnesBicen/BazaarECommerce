using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBookService
    {
        ResultModel AddBook(Book book);
        ResultModel DeleteBook(Book book);
        ResultModel DeleteById(int bookId);
        ResultModel UpdateBook(Book book);

        Book GetById(int bookId);
        Book GetByProductId(int productId);
        List<Book> GetAll();

    }
}
