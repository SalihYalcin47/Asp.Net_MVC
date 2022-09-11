using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IMessageService
    {

        List<Message> GetListInbox(string user);  // listeleme
        List<Message> GetListSendbox(string user);  // listeleme
        void MessageAdd(Message message);  // Ekleme
        Message GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
