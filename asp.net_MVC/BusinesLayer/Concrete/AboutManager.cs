using BusinesLayer.Abstract;
using DataAcessLayer.Abstract;
using DataAcessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDall _aboutdall;

        public AboutManager(IAboutDall aboutdall)
        {
            _aboutdall = aboutdall;
        }

        public void AboutAdd(About about)
        {
            _aboutdall.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutdall.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutdall.Update(about);
        }

        public About GetID(int id)
        {
            return _aboutdall.Get(x => x.AbautID == id);
        }

        public List<About> GetList()
        {
            return _aboutdall.list();
        }
    }
}
