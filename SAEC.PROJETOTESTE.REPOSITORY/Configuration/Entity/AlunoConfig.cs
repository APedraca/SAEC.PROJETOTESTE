using System.Data.Entity.ModelConfiguration;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            ToTable("Tb_Aluno");
            HasKey(a => a.Id);
            Property(a => a.Alterado);
            HasRequired(a => a.Cidade).WithMany().HasForeignKey(a => a.CidadeId);
            Property(a => a.Cpf);
            Property(a => a.Endereco);
            Property(a => a.Matricula);
            Property(a => a.Nascimento);
            Property(a => a.Nome);
            Property(a => a.Rg);
            Property(a => a.Sexo);
            Property(a => a.Telefone);
            HasRequired(a => a.Usuario).WithMany().HasForeignKey(a => a.UsuarioId);
            Property(a => a.Cadastro);
        }
    }
}
