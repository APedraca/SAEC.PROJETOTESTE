using System;

namespace SAEC.PROJETOTESTE.MODEL.Entities
{
    public class Aluno : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public string Rg { get; set; }
        public DateTime Nascimento { get; set; }
        public string Endereco { get; set; }
        public string Matricula { get; set; }
        public DateTime Alterado { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
