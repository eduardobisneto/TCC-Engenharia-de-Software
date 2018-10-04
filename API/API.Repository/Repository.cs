using API.Common.Entity.Core;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public abstract class Repository<TContext, TEntity> : IDisposable, IRepository<TEntity>
        where TEntity : Base
        where TContext : DbContext
    {
        protected TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TEntity GetById(TEntity entity)
        {
            return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id.Equals(entity.Id));
        }

        public bool Exists(TEntity entity)
        {
            return (null != _context.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id.Equals(entity.Id)));
        }

        public IEnumerable<TEntity> GetAll(TEntity entity)
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            entity.DataCriacao = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            entity.DataAlteracao = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
