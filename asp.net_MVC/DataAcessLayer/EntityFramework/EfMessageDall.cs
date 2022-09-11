using DataAccesLayer.Concrete.Repository;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFramework
{
    public class EfMessageDall : GenericRepository<Message>, IMessageDall
    {
    }
}
