using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Models
{
    public class ProductVM
    {
        public ProductVM()
        {
            Product = new Product();
            Book = new Book();
            Electronic = new Electronic();
            Clothe = new Clothe();
        }
        public ProductVM(Product product, Book book)
        {
            Product = product;
            Book = book;
        }


        public Product Product { get; set; }
        public Book Book { get; set; }
        public Electronic Electronic { get; set; }
        public Clothe Clothe { get; set; }
        



    }
}
