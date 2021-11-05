using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    //db tasarımında pc ve product bağlantılı tablolar olduğu için ikisinin özelliklerini barındıran bir
    //entity ye ihtiyaç vardı, bunu DTO ile karşıladım. Aşağıdaki implemantasyon doğru bir kullanım olmayabilir
    public class ComputerDetailDto
    {
        public Product ProductObj { get; set; }
        public Computer ComputerObj { get; set; }

    }
}
