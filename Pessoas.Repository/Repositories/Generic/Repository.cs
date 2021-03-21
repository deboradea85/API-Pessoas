using Microsoft.EntityFrameworkCore;
using Pessoas.Domain.Models;
using Pessoas.Repository.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Repository.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> dataSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> ObterTodos()
        {
            var itens = await dataSet.ToListAsync();
            return (itens);
        }
        public async Task<T> ObterPorId(Guid id)
        {
            var item = await dataSet.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }
        public async Task<T> Criar(T item)
        {
            dataSet.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<T> Atualizar(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task Excluir(Guid id)
        {
            var item = await dataSet.FirstOrDefaultAsync(p => p.Id == id);

            if (item != null)
            {
                dataSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
