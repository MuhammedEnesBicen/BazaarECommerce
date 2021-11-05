using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string  Surname { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public int EarnedPoint { get; set; }
        public string PhotoPath { get; set; }


        public List<Card> Cards { get; set; }

    }
}
