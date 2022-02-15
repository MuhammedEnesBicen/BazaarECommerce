using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IClotheDal: IGenericDal<Clothe>
    {
        Clothe GetClotheById(int clotheId);
        void DeleteClotheById(int clotheId);
    }
}
