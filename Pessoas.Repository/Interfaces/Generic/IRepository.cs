using Pessoas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pessoas.Repository.Interfaces.Generic
{
    public interface IRepository<T> where T : Base
    {
        Task<IEnumerable<T>> GetAllFilterJoin(Expression<Func<T, bool>> filter, string[] children);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task Delete(Guid id);
    }
}
