using System.Collections.Generic;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Services
{
    public interface IBaseService
    {
        void Add(BaseModel obj);
        BaseModel GetById(int id);
        IEnumerable<BaseModel> GetAll();
        void Update(BaseModel obj);
        void Remove(BaseModel obj);
    }
}
