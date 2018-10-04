using API.Common.Entity.Core;
using System;
using System.Collections.Generic;

namespace API.Logic.Interface
{
    public interface ILogic<T> : IDisposable
        where T : Base
    {
        T Insert(T entity);

        T Update(T entity);

        T Delete(T entity);

        IEnumerable<T> DeleteRange(IEnumerable<T> entity);

        T GetById(T entity);

        IEnumerable<T> GetAll(T entity);

        bool Exists(T entity);
    }
}
