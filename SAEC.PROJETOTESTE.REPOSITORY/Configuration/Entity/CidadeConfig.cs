using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAEC.PROJETOTESTE.MODEL.Entities;

namespace SAEC.PROJETOTESTE.REPOSITORY.Configuration.Entity
{
    public class CidadeConfig : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfig()
        {
            ToTable("Tb_Cidade");
            HasKey(c => c.Id);
            Property(c => c.Cep);
            Property(c => c.Estado);
            Property(c => c.Nome);
            Property(c => c.Cadastro);
        }
    }
}
