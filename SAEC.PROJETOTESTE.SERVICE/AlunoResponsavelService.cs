using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class AlunoResponsavelService : BaseService<AlunoResponsavel>, IAlunoResponsavelService
    {
        private readonly IAlunoResponsavelRepository _alunoResponsavelRepository;

        public AlunoResponsavelService(IAlunoResponsavelRepository alunoResponsavelRepository)
            :base(alunoResponsavelRepository)
        {
            _alunoResponsavelRepository = alunoResponsavelRepository;
        }
    }
}