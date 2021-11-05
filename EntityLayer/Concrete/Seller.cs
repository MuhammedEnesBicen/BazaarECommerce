using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string SellerFirstname { get; set; }
        public string SellerLastname { get; set; }
        public DateTime RegisterDate { get; set; }
        public string BusinessName { get; set; }
        public int SellerPoint { get; set; }
        public string SellerEmail { get; set; }
        public string SellerPassword { get; set; }
        public string SellerCity { get; set; }
        public string SellerIntroduction { get; set; }


    }
}
