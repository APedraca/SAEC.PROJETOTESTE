namespace SAEC.PROJETOTESTE.MODEL.Entities
{
    public class AlunoResponsavel : BaseModel
    {
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }
        public string Celular { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
