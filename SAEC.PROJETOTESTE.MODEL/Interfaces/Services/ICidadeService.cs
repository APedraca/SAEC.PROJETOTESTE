using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Services
{
    public interface ICidadeService : IBaseService<Cidade>
    {
        void Save(Cidade cidade);
    }
}
