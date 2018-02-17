using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity;

namespace SAEC.PROJETOTESTE.REPOSITORY
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected Context Db = new Context();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public ICollection<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return Db.Set<TEntity>().Where(expression).ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
