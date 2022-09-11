using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();  // listeleme
        void AboutAdd(About about);  // Ekleme
        About GetID(int id);  // id Ye göre İşlem Yap (  Silme )
        void AboutDelete(About about);
        void AboutUpdate(About about);
    }
}
