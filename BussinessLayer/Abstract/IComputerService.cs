using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IComputerService
    {
        bool AddComputer(Computer computer);
        bool DeleteComputer(Computer computer);
        bool UpdateComputer(Computer computer);

        Computer GetById(int id);
        Computer GetByProductId(int ProductId);
        List<Computer> GetListWithProduct();
    }
}
