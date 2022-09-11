using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();  // listeleme
        void AdminAdd(Admin admin);  // Ekleme
        Admin GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
