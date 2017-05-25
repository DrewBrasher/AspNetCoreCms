using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AspNetCoreCms.Models;

namespace AspNetCoreCms.Interfaces
{
    /// <summary>
    /// An interface that defines the methods that most any repository will need.
    /// </summary>
    /// <typeparam name="T">Type must extend <see cref="EntityBase"/></typeparam>
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
