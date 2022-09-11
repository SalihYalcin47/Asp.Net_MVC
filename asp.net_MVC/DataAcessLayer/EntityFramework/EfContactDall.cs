using DataAccesLayer.Concrete.Repository;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.EntityFreamwork
{
    public class EfContactDall : GenericRepository<Contact>, IContactDall
    {
    }
}
