namespace Pessoas.Domain.Models
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public long Rg { get; set; }
        public Telefone Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
