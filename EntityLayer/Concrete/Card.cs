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
        [Range(16,16)]
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string NameOnCard { get; set; }
        public int SecurityCode { get; set; }
        public string BankOrCredit { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
