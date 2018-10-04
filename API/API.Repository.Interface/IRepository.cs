using API.Common.Entity.Core;
using System;
using System.Collections.Generic;

namespace API.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : Base
    {
        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entity);

        TEntity GetById(TEntity entity);

        IEnumerable<TEntity> GetAll(TEntity entity);

        bool Exists(TEntity entity);
    }
}
