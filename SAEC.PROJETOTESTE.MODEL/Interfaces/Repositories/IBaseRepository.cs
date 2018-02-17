using System.Collections.Generic;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        void Add(BaseModel obj);
        BaseModel GetById(int id);
        IEnumerable<BaseModel> GetAll();
        void Update(BaseModel obj);
        void Remove(BaseModel obj);
    }
}
