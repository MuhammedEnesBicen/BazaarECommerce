using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Electronic
    {
        public int ElectronicId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public string DisplayCard { get; set; }
        public string Processor { get; set; }
        public string ScreenSize { get; set; }
        public string OperatingSystem { get; set; }
        public int Ram { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; }
        public bool Webcam { get; set; }

    }
}
