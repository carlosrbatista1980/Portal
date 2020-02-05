using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Data;

namespace Portal.Service.Base
{
    public interface IServiceBase 
    {
    }

    public abstract class ServiceBase: IServiceBase
    {
        protected PortalDbContext _context;

        public ServiceBase(PortalDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all records from a entity
        /// </summary> 
        /// <returns>IQuerable</returns>
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.AsQueryable();
        }

        /// <summary>
        ///     Gets all records from a entity filtering by a condition. (you can also use GetAll().Where(x => x.Id != 0) but, you will trigger 2 actions, GetAll() and Where filter)
        /// Using GetAllWhere you will trigger just one action, its much more faster.
        /// </summary>
        /// <example>
        ///     Ex: var records = GetAllWhere(x => x.Id == 1)  returns all records where Id is equal to 1
        /// </example> 
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllWhere<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Where(predicate);
        }

        /// <summary>
        /// Adds an entity to be saved but, its not exists on database yet.
        /// </summary>
        /// <param name="entity"></param>
        public void Insert<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Add(entity);
            _context.SaveChanges(CommitAllChangesOnSuccess);
            //_context.Entry<TEntity>(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Remove an entity from database and commits its changes.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            dbSet.Remove(entity);
            _context.SaveChanges(CommitAllChangesOnSuccess);
            //_context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Gets an entity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TEntity GetEntityById<TEntity>(int id) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();
            return dbSet.Find(id);
        }

        /// <summary>
        /// Commits all changes added on database
        /// </summary>
        /// <param name="CommitAllChangesOnSuccess"></param>
        /// <returns></returns>
        public bool Update<TEntity>(TEntity entity, bool CommitAllChangesOnSuccess = true) where TEntity : class
        {
            DbSet<TEntity> dbSet = _context.Set<TEntity>();

            if (_context.Entry<TEntity>(entity).State == EntityState.Modified)
            {
                try
                {
                    dbSet.Attach(entity);
                    _context.SaveChanges(CommitAllChangesOnSuccess);
                    //_context.Entry<TEntity>(entity).State = EntityState.Modified;

                    return true;
                }
                catch (DbUpdateException ex)
                {
                    return false;
                }
            }

            return false;
        }


    }
}
