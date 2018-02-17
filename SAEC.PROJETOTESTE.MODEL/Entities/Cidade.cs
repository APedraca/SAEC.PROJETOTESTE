using System.Collections.Generic;

namespace SAEC.PROJETOTESTE.MODEL.Entities
{
    public class Cidade : BaseModel
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}
