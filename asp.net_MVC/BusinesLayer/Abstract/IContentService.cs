using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);  // listeleme
        List<Content> GetListByWriter(int id);  // listeleme
        List<Content> GetListByID(int id);
        void ContentAdd(Content content);  // Ekleme
        Content GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
