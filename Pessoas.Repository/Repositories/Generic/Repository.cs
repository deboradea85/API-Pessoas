using Pessoas.Domain.Models;
using Pessoas.Repository.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Repository.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        public Task<IEnumerable<T>> ObterTodos()
        {
            throw new NotImplementedException();
        }
        public Task<T> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<T> Criar(T item)
        {
            throw new NotImplementedException();
        }
        public Task<T> Atualizar(T item)
        {
            throw new NotImplementedException();
        }
        public Task Excluir(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
