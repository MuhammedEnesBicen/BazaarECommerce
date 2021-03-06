using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Display(Name ="Adress  Name")]
        public string AddressName { get; set; }
        [Display(Name = "Adress  Text")]
        public string AddressText { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
