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
    public class MessageManager : IMessageService
    {
        IMessageDall _messageDall;

        public MessageManager(IMessageDall messageDall)
        {
            _messageDall = messageDall;
        }

        public Message GetID(int id)
        {
            return _messageDall.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string user)
        {
           return _messageDall.list(x => x.ReceiverMail == user);
        }

        public List<Message> GetListSendbox(string user)
        {
            return _messageDall.list(x => x.SenderMail == user);
        }

        public void MessageAdd(Message message)
        {
            _messageDall.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
