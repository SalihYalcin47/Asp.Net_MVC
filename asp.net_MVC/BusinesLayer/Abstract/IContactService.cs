using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();  // listeleme
        void ContactAdd(Contact contact);  // Ekleme
        Contact GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
