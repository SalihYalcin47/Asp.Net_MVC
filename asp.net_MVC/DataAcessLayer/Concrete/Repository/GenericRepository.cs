using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository() 
        {
            _object = c.Set<T>(); // Dışardan gelen veri neysa buraya o gelecek
        }
        public void Delete(T p)
        {
            var DeleteEntry = c.Entry(p);
            DeleteEntry.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);  // Tek Bir Değer Döndürür
        }

        public void Insert(T p)
        {
            var AdedEntry = c.Entry(p);
            AdedEntry.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> list()
        {
            return _object.ToList();
        }

        public List<T> list(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var UpdateEntry = c.Entry(p);
            UpdateEntry.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
