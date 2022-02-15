using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void AddBrand(Brand brand)
        {
            _brandDal.Insert(brand);
        }

        public void DeleteBrandById(int brandId)
        {
            _brandDal.DeleteBrandById(brandId);
        }

        public List<Brand> GetAllBrands()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandById(int brandId)
        {
            return _brandDal.GetBrandById(brandId);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
