using BussinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        public void ImageDelete(int imageId)
        {
            using (var context = new Context())
            {
                Image temp = context.Images.FirstOrDefault(c => c.ImageId == imageId);
                context.Images.Remove(temp);
                context.SaveChanges();
            }
        }
    }
}
