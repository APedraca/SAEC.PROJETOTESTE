using System.Data.Entity.ModelConfiguration;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Tb_Usuario");
            HasKey(u => u.Id);
            Property(u => u.Cadastro);
            Property(u => u.Nome);
            Property(u => u.Cpf);
            Property(u => u.Sexo);
            Property(u => u.Telefone);
            HasRequired(u => u.Cidade).WithMany().HasForeignKey(u => u.CidadeId);
            Property(u => u.Email);
            Property(u => u.Senha);
        }
    }
}
