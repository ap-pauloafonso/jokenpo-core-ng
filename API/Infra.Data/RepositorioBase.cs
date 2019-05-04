using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data
{
    public class RepositorioBase<Type> : IRepositorioBase<Type> where Type : class
    {
        public JokenpoContext Context; 
        public RepositorioBase(JokenpoContext context)
        {
            Context = context;
        }
        public void Add(Type entity)
        {
            Context.Set<Type>().Add(entity);
        }

        public void AddRange(IEnumerable<Type> entities)
        {
            Context.Set<Type>().AddRange(entities);

        }

        public IEnumerable<Type> find(Expression<Func<Type, bool>> predicate)
        {
            return Context.Set<Type>().Where(predicate);
        }

        public Type Get(int id)
        {
            return Context.Set<Type>().Find(id);
        }

        public IEnumerable<Type> GetAll()
        {
            return Context.Set<Type>().ToList();
        }

        public void Remove(Type entity)
        {
            Context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Type> entities)
        {
            Context.RemoveRange(entities);
        }
    }
}