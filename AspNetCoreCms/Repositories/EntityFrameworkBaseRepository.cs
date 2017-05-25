using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    /// <summary>
    /// A repository that implements common methods that most any object stored in a data store would need.  They are implemented using Entity Framework.
    /// Individual repositories should extend this class so they only have to implement additional methods specific to that type of object.
    /// </summary>
    /// <typeparam name="T">The Model object being stored in the data store.  It must extend <see cref="EntityBase"/></typeparam>
    public class EntityFrameworkBaseRepository<T> : IRepository<T> where T : Entity
    {
        public readonly DbContext _dbContext;
        public readonly ILogger<T> Logger;

        /// <summary>
        /// Initialize the repository.
        /// </summary>
        /// <param name="log">The logger that this repository should use</param>
        /// <param name="dbContext">The Context that defines the data store to be used</param>
        public EntityFrameworkBaseRepository(ILogger<T> log, DbContext dbContext)
        {
            _dbContext = dbContext;
            Logger = log;
        }

        /// <summary>
        /// Lists all objects in the data store
        /// </summary>
        /// <returns>Returns an <see cref="IEnumerable{T}"/> of the objects.</returns>
        public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        /// <summary>
        /// Lists all objects in the data store that match the given <see cref="System.Linq.Expressions.Expression"/>
        /// </summary>
        /// <param name="predicate">An <see cref="System.Linq.Expressions.Expression"/> expression that filters the results</param>
        /// <returns>Returns an <see cref="IEnumerable{T}"/> of the objects that match the <see cref="System.Linq.Expressions.Expression"/>.</returns>
        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        /// <summary>
        /// Insert the object into the data store
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            Logger.LogDebug($"Inserting {nameof(entity)} into database: {entity.ToString()}");
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update the object in the data store.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            Logger.LogDebug($"Updating {nameof(entity)} in database (Id = {entity.Id}): {entity.ToString()}");
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Detetes the object from the data store
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            Logger.LogDebug($"Deleting {nameof(entity)} from database (Id = {entity.Id}): {entity.ToString()}");
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get the object from the data store where the Id matches the given id.
        /// </summary>
        /// <param name="id">The Id to search for</param>
        /// <returns>Returns the object that matches the given id.</returns>
        public virtual T GetById(int id)
        {
            Logger.LogDebug("GetById({0}) - Connection string: {1}", id, _dbContext.Database.GetDbConnection().ConnectionString);
            return _dbContext.Set<T>().SingleOrDefault(x => x.Id == id);
        }
    }
}
