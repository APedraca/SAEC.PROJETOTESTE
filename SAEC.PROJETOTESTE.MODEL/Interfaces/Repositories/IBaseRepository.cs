using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        ICollection<TEntity> GetAll();
        ICollection<TEntity> GetBy(Expression<Func<TEntity, bool>> expression);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
