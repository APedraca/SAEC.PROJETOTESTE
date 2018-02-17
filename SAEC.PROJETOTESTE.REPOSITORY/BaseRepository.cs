using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity;

namespace SAEC.PROJETOTESTE.REPOSITORY
{
    public class BaseRepository : IBaseRepository
    {
        protected Context Db = new Context();

        public void Add(BaseModel obj)
        {
            Db.Set<BaseModel>().Add(obj);
            Db.SaveChanges();
        }

        public BaseModel GetById(int id)
        {
            return Db.Set<BaseModel>().Find(id);
        }

        public IEnumerable<BaseModel> GetAll()
        {
            return Db.Set<BaseModel>().ToList();
        }

        public void Update(BaseModel obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(BaseModel obj)
        {
            Db.Set<BaseModel>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
