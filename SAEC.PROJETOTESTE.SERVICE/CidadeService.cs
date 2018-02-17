using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class CidadeService : BaseService, ICidadeService
    {
        public CidadeService(IBaseRepository baseRepository) : base(baseRepository)
        {
        }
    }
}