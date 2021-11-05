using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfComputerRepository : GenericRepository<Computer>, IComputerDal
    {
        public List<Computer> GetListWithProduct()
        {
            using (var c = new Context())
            {
                return c.Computers.Include(p => p.Product).ToList();
            }
        }
    }
}
