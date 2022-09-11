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
    public class ImageFileManager : IImageFileService
    {
        IImageDall _ımagedall;

        public ImageFileManager(IImageDall ımagedall)
        {
            _ımagedall = ımagedall;
        }

        public List<ImageFile> GetList()
        {
          return  _ımagedall.list();
        }

        List<ImageFile> IImageFileService.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
