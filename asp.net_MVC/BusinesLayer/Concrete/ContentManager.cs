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
    public class ContentManager : IContentService
    {
        IContentDall _contentdall;

        public ContentManager(IContentDall contentdall)
        {
            _contentdall = contentdall;
        }

        public void ContentAdd(Content content)
        {
            _contentdall.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentdall.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentdall.Update(content);
        }

        public Content GetID(int id)
        {
            return _contentdall.Get(x => x.ContentID == id);
        }

        public List<Content> GetList(string p)
        {
            return _contentdall.list(x => x.ContentValue.Contains(p)); // Contentvalue degeri p den gelen değeri içermeli
        }

        public List<Content> GetListByID(int id)
        {
            return _contentdall.list(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentdall.list(x => x.WriterID == id);
        }
    }
}
