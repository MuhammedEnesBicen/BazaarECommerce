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
    public class ComputerManager : IComputerService
    {
        IComputerDal _computerDal;

        public ComputerManager(IComputerDal computerDal)
        {
            _computerDal = computerDal;
        }

        public bool AddComputer(Computer computer)
        {
            _computerDal.Insert(computer);
            return true;
        }

        public bool DeleteComputer(Computer computer)
        {
            _computerDal.Delete(computer);
            return true;
        }

        public Computer GetById(int id)
        {
            return _computerDal.Get(c => c.ComputerId == id);
        }

        public Computer GetByProductId(int ProductId)
        {
            return _computerDal.Get(c => c.ProductId == ProductId);
        }

        public List<Computer> GetListWithProduct()
        {
            return _computerDal.GetListWithProduct();
        }

        public bool UpdateComputer(Computer computer)
        {
            _computerDal.Update(computer);
            return true;
        }
    }
}
