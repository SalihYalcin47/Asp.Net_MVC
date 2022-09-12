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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDall _writerDall;

        public WriterLoginManager(IWriterDall writerDall)
        {
            _writerDall = writerDall;
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDall.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
        public Writer GetWriterRecord(string username)
        {
            return _writerDall.Get(x => x.WriterMail == username);
        }
    }
}
