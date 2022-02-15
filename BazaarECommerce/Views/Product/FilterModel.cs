using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazaarECommerce.Views.Product
{
    public class FilterModel
    {
        public List<int> BrandIds { get; set; }
        public List<int> StarRates { get; set; }
        public string Searchtext { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

    }
}
