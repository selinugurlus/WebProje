using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet <T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T u)
        {
            _object.Remove(u);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> Filter)
        {
            return _object.SingleOrDefault(Filter); 
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

        public List<T> List(Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList();
        }

        public void Update(T u)
        {
            c.SaveChanges();
        }
    }
}
