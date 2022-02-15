using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IClotheService
    {
        void AddClothe(Clothe clothe);
        void UpdateClothe(Clothe clothe);
        Clothe GetClotheById(int clotheId);
        void DeleteClotheById(int clotheId);
        
    }
}
