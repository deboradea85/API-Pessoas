using Microsoft.EntityFrameworkCore;
using Pessoas.Domain.Models;

namespace Pessoas.Repository
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projetos\\2021\\API-Pessoas\\Pessoas.DataBase\\Pessoa.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
