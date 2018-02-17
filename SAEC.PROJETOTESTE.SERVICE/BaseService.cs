using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            DateTime cadastro = DateTime.Now;
            PropertyInfo propertyInfo = obj.GetType().GetProperty("Cadastro");
            propertyInfo.SetValue(obj, Convert.ChangeType(cadastro, propertyInfo.PropertyType), null);
            _repository.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public ICollection<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.GetBy(expression);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }
    }
}
