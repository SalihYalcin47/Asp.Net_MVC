using BusinesLayer.Abstract;
using ClassLibrary1.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class WriterManager : IWriteService
    {
        IWriterDall _WriterDall;

        public WriterManager(IWriterDall writerDall)
        {
            _WriterDall = writerDall;
        }

        public Writer GetId(int id)
        {
            return _WriterDall.Get(x => x.WriterID == id);
        }

        public List<Writer> Getlist()
        {
            return _WriterDall.list();
        }

        public void WriterAdd(Writer writer)
        {
            _WriterDall.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _WriterDall.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _WriterDall.Update(writer);
        }
    }
}
