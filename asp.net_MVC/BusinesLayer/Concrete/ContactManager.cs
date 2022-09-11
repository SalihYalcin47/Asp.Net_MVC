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
    public class ContactManager : IContactService
    {
        IContactDall _Contactdall;

        public ContactManager(IContactDall contactdall)
        {
            _Contactdall = contactdall;
        }

        public void ContactAdd(Contact contact)
        {
            _Contactdall.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _Contactdall.Delete(contact);   
        }

        public void ContactUpdate(Contact contact)
        {
            _Contactdall.Update(contact);
        }
        public Contact GetID(int id)
        {
             return   _Contactdall.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _Contactdall.list();
        }
    }
}
