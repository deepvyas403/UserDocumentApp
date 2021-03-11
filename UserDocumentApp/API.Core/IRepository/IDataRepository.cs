using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.IRepository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
