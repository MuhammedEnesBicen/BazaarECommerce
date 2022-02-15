using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IBrandService
    {
        void AddBrand(Brand brand);
        void UpdateBrand(Brand brand);

        Brand GetBrandById(int brandId);
        List<Brand> GetAllBrands();
        void DeleteBrandById(int brandId);
    }
}
