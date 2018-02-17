using System.Data.Entity;
using SAEC.PROJETOTESTE.MODEL.Entities;
using SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity.Mapping;

namespace SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity
{
    public class Context : DbContext
    {
        public Context() 
            : base("ApplicationServices")
        {

        }

        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CidadeMap());
        }
    }
}
