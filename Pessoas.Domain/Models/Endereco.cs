using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pessoas.Domain.Models
{
    public class Endereco : Base
    {
        [ForeignKey("Pessoa")]
        [JsonIgnore]
        public Guid PessoaEnderecoId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
    }
}
