﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Size Size { get; set; }
        public int SizeId { get; set; }

        public int Number { get; set; }
    }
}
