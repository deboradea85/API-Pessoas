using Microsoft.EntityFrameworkCore;
using Pessoas.Domain.Models;

namespace Pessoas.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
