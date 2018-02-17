using System;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Repositories;
using SAEC.PROJETOTESTE.MODEL.Interfaces.Services;
using SAEC.PROJETOTESTE.MODEL.ManagementSystem;

namespace SAEC.PROJETOTESTE.SERVICE
{
    public class AlunoService : BaseService<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
            :base (alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Save(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.Nome))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoNomeEmpty);
            if (string.IsNullOrWhiteSpace(aluno.Cpf))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoCpfEmpty);
            if (string.IsNullOrWhiteSpace(aluno.Sexo))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoSexoEmpty);
            if (string.IsNullOrWhiteSpace(aluno.Telefone))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoTelefoneEmpty);
            if (aluno.CidadeId == 0)
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoCidadeEmpty);
            if (string.IsNullOrWhiteSpace(aluno.Endereco))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoEnderecoEmpty);
            if (string.IsNullOrWhiteSpace(aluno.Matricula))
                throw new ProjetoTesteException(ProjetoTesteExceptionMessage.AlunoMatriculaEmpty);

            aluno.Alterado = DateTime.Now;

            if (aluno.Id == 0)
                Add(aluno);
            else
                Update(aluno);
        }
    }
}
