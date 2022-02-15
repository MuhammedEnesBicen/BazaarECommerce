using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IElectronicService
    {
        bool AddElectronic(Electronic computer);
        bool DeleteElectronic(Electronic computer);
        bool UpdateElectronic(Electronic computer);

        Electronic GetById(int id);
        Electronic GetByProductId(int ProductId);
        List<Electronic> GetListWithProduct();
    }
}
