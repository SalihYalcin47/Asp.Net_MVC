using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();  // listeleme
        void CategoryAdd(Category category);  // Ekleme
        Category GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
