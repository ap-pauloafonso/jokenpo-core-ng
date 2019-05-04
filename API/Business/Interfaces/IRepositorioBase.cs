using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IRepositorioBase<Type> where Type : class
    {
        Type Get(int id);
        IEnumerable<Type> GetAll();
        IEnumerable<Type> find(Expression<Func<Type, bool>> predicate);

        void Add(Type entity);
        void AddRange(IEnumerable<Type> entities);


        void Remove(Type entity);
        void RemoveRange(IEnumerable<Type> entities);

    }
}