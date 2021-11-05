using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvc2 { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
