using Microsoft.EntityFrameworkCore;
using Pessoas.Domain.Models;
using Pessoas.Repository.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<T>> GetAllFilterJoin(Expression<Func<T, bool>> filter, string[] children)
        {
            try
            {               
                return await QueryJoin(children).AsNoTracking().Where(filter).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IQueryable<T> QueryJoin (string[] children)
        {
            IQueryable<T> query = dataSet;
            foreach (string entity in children)
            {
                query = query.Include(entity);
            }
            return query;
        }

        public async Task<IEnumerable<T>> GetAll(string[] children)
        {
            var items = await QueryJoin(children).AsNoTracking().ToListAsync();
            return (items);
        }

        public async Task<T> GetById(Guid id)
        {
            var item = await dataSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<T> Create(T item)
        {
            dataSet.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Update(T item)
        {
            _context.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
             await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(T item)
        {
            if (item != null)
            {          
                _context.Entry(item).State = EntityState.Detached;
                _context.Attach(item);
                dataSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
