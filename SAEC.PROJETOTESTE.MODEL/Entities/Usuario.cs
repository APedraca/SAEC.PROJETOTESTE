namespace SAEC.PROJETOTESTE.MODEL.Entities
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
