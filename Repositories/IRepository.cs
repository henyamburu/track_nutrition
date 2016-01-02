using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IRepository<T>
    {
        T Find(int id);
        IList<T> Find(Expression<Func<T, bool>> exp);
        IList<T> Find(Expression<Func<T, bool>> exp, int count, int size);
        IList<T> Find(Expression<Func<T, bool>> exp, Expression<Func<T, IComparable>> order, bool desc);
        IList<T> Find(Expression<Func<T, bool>> exp, int count, int size, Expression<Func<T, IComparable>> order, bool desc);
        IList<T> FindAll();
        T Save(T entity);
        void Delete(T entity);
        T CreateInstance();
    }
}
