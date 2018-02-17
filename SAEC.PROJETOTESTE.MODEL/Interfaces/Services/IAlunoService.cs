using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.MODEL.Interfaces.Services
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        void Save(Aluno aluno);
    }
}
