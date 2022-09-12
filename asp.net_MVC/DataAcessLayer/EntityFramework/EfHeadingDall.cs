using ClassLibrary1.Abstract;
using DataAccesLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.EntityFreamwork
{
    public class EfHeadingDall : GenericRepository<Heading> , IHeadingDall
    {
    }
}
