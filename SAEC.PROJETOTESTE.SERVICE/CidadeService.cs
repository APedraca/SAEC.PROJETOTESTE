using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MODEL.ManagementSystem;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class CidadeService : BaseService<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
            :base (cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public void Save(Cidade cidade)
        {
            if (string.IsNullOrEmpty(cidade.Nome))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.CidadeNomeEmpty);
            if (string.IsNullOrEmpty(cidade.Cep))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.CidadeCepEmpty);
            if (string.IsNullOrEmpty(cidade.Estado))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.CidadeEstadoEmpty);

            if (cidade.Id == 0)
                Add(cidade);
            else
                Update(cidade);
        }
    }
}