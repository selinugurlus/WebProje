using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class //göndereceğim t değeri class olmalı şartı.
    {
        Context c = new Context();

        DbSet<T> _object; //_object T değerine karşılık gelen sınıfı tutar.

        public GenericRepository() //constructer method
        {
            _object = c.Set<T>();
        }

        public void Delete(T u)
        {
            _object.Remove(u);
            c.SaveChanges();
        }

        public void Insert(T u)
        {
            _object.Add(u);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList(); //Filter'a ne gönderirsek onu listeler.
        }

        public void Update(T u)
        {
            c.SaveChanges();
        }
    }
}
