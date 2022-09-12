using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetLisCategoryt(int id);
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);
        Heading GetHeading(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
