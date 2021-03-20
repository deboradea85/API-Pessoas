using Pessoas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Repository.Interfaces.Generic
{
    public interface IRepository<T> where T : Base
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task<T> Criar(T item);
        Task<T> Atualizar(T item);
        Task Excluir(Guid id);
    }
}
