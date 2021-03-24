using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pessoas.Domain.Models
{
    public class Telefone : Base
    {
        [ForeignKey("Pessoa")]
        [JsonIgnore]
        public Guid PessoaTelefoneId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
        public string Tipo { get; set; }
        public long Numero { get; set; }
       
    }
}
