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
    public class HeadingManager : IHeadingService
    {
        IHeadingDall _headingDall;

        public HeadingManager(IHeadingDall headingDall)
        {
            _headingDall = headingDall;
        }

        public Heading GetHeading(int id)
        {
            return _headingDall.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetLisCategoryt(int id)
        {
            return _headingDall.list(x => x.CatagoryID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDall.list();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDall.list(x => x.WriterID == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDall.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDall.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDall.Update(heading);
        }

    }
}
