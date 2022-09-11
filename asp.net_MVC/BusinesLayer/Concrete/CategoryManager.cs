using BusinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {

        ICategoryDall _categoryDall;

        public CategoryManager(ICategoryDall categoryDall)
        {
            _categoryDall = categoryDall;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDall.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDall.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDall.Update(category);
        }

        public Category GetID(int id)
        {
            return _categoryDall.Get(x => x.CatagoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDall.list();
        }
    }
}
