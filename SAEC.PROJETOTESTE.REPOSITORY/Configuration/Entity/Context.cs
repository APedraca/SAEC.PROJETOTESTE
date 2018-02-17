using System.Data.Entity;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity
{
    public class Context : DbContext
    {
        public Context() 
            : base("ApplicationServices")
        {
            Database.SetInitializer<Context>(null);
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>().ToTable("Tb_Cidade");
            modelBuilder.Entity<Aluno>().ToTable("Tb_Aluno");
            modelBuilder.Entity<Usuario>().ToTable("Tb_Usuario");
            //modelBuilder.Configurations.Add(new CidadeConfig());
            //modelBuilder.Configurations.Add(new AlunoConfig());
            //modelBuilder.Configurations.Add(new UsuarioConfig());
        }
    }
}
