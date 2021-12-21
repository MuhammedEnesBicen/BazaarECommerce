using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public string Promotion { get; set; }
        public int Installment { get; set; }
        public double StarRate { get; set; }
        public int Quantity { get; set; }
        public int MonthlySalesPrevious { get; set; }
        public int MonthlySalesCurrent { get; set; }

        public List<Image> Images { get; set; }

    }
}
