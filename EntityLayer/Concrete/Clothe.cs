using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Clothe
    {
        public int ClotheId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Size Size { get; set; }
        public int SizeId { get; set; }

        public string Gender { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }

    }
}
