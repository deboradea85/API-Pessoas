using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pessoas.Domain.Models
{
    public class Base
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
