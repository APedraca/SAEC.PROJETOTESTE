using System.Collections.Generic;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class BaseService : IBaseService
    {
        private readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Add(BaseModel obj)
        {
            _baseRepository.Add(obj);
        }

        public BaseModel GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        public IEnumerable<BaseModel> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public void Update(BaseModel obj)
        {
            _baseRepository.Update(obj);
        }

        public void Remove(BaseModel obj)
        {
            _baseRepository.Remove(obj);
        }
    }
}
