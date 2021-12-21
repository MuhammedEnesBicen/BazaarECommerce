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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public ResultModel AddBook(Book book)
        {
            _bookDal.Insert(book);
            return new ResultModel { Result = true, Message = "Book Insertion succesfull" };
        }

        public ResultModel DeleteBook(Book book)
        {
            _bookDal.Delete(book);
            return new ResultModel { Result = true, Message = "Book deletion succesfull" };
        }

        public ResultModel DeleteById(int bookId)
        {
            return _bookDal.DeleteById(bookId);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public Book GetById(int bookId)
        {
            return _bookDal.GetById(bookId);
        }

        public Book GetByProductId(int productId)
        {
            return _bookDal.GetByProductId(productId);
        }

        public ResultModel UpdateBook(Book book)
        {
            _bookDal.Update(book);
            return new ResultModel { Result = true, Message = "Book update successful" };
        }
    }
}
