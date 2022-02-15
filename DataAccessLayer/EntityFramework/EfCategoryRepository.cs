﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public void DeleteCategoryById(int categoryId)
        {
            using (var context = new Context())
            {
                var temp =  context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                context.Remove(temp);
                context.SaveChanges();
            }
        }
    }
}
