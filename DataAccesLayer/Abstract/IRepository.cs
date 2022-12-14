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
        List<T> List();

        void Insert(T u);

        T Get(Expression<Func<T, bool>> Filter);


        void Delete(T u);

        void Update(T u);

        List<T> List(Expression<Func<T, bool>> Filter);
    }
}
