using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> list();  // hangi tablo ile işlem yapılacaksa T ye o gelir teker teker tablolarla ugraşmaya gerek duymaz

        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        T Get(Expression<Func<T, bool>> filter);
        List<T> list(Expression<Func<T,bool>>filter);
    }
}
