using API.Common.Entity.Core;
using API.Logic.Interface;
using API.Repository.Interface;
using System;
using System.Collections.Generic;

namespace API.Logic
{
    public abstract class Logic<TRepository, TEntity> : IDisposable, ILogic<TEntity>
        where TEntity : Base
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public Logic(TRepository repository)
        {
            _repository = repository;
        }

        public TEntity Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

        public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entity)
        {
            return _repository.DeleteRange(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public TEntity GetById(TEntity entity)
        {
            return _repository.GetById(entity);
        }

        public bool Exists(TEntity entity)
        {
            return _repository.Exists(entity);
        }

        public IEnumerable<TEntity> GetAll(TEntity entity)
        {
            return _repository.GetAll(entity);
        }

        public TEntity Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }
    }
}
