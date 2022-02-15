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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void DeleteCategoryById(int categoryId)
        {
            _categoryDal.DeleteCategoryById(categoryId);
        }

        public List<Category> GetAllCategories()
        {
           return _categoryDal.GetAll();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
