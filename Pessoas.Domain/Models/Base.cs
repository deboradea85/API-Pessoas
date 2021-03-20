using System;
using System.ComponentModel.DataAnnotations;

namespace Pessoas.Domain.Models
{
    public class Base
    {
        [Key]
        public Guid Id { get; set; }
    }
}
