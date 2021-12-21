using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string WriterName { get; set; }
        public string CategoryName { get; set; }
        public int PublicationYear { get; set; }
        public int PageNumber { get; set; }
        public string Language { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
