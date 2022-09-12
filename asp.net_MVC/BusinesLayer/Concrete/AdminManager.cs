using BusinesLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDall _adminDall;

        public AdminManager(IAdminDall adminDall)
        {
            _adminDall = adminDall;
        }

        public void AdminAdd(Admin admin)
        {
             _adminDall.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDall.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDall.Update(admin);
        }

        public Admin GetID(int id)
        {
            return _adminDall.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDall.list();
        }
    }
}
