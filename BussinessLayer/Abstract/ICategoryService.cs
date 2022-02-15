using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void DeleteCategoryById(int categoryId);
        void UpdateCategory(Category category);

        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
    }
}
