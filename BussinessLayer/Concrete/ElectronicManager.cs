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
    public class ElectronicManager : IElectronicService
    {
        IElectronicDal _electronicDal;

        public ElectronicManager(IElectronicDal electronicDal)
        {
            _electronicDal = electronicDal;
        }

        public bool AddElectronic(Electronic electronic)
        {
            _electronicDal.Insert(electronic);
            return true;
        }

        public bool DeleteElectronic(Electronic electronic)
        {
            _electronicDal.Delete(electronic);
            return true;
        }

        public Electronic GetById(int id)
        {
            return _electronicDal.Get(c => c.ElectronicId == id);
        }

        public Electronic GetByProductId(int ProductId)
        {
            return _electronicDal.Get(c => c.ProductId == ProductId);
        }

        public List<Electronic> GetListWithProduct()
        {
            return _electronicDal.GetListWithProduct();
        }

        public bool UpdateElectronic(Electronic electronic)
        {
            _electronicDal.Update(electronic);
            return true;
        }
    }
}
