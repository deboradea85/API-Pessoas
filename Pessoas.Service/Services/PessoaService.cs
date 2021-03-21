using Pessoas.Domain.Models;
using Pessoas.Repository.Interfaces.Generic;
using Pessoas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.Service.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly IRepository<Pessoa> _repository;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoas()
        {
            return await _repository.ObterTodos();
        }

        public async Task<Pessoa> ObterPessoaPorId(Guid idPessoa)
        {
            return await _repository.ObterPorId(idPessoa);
        }

        public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
        {
            return await _repository.Criar(pessoa);
        }

        public async Task<Pessoa> AtualizarPessoa(Guid idPessoa, Pessoa pessoa)
        {
            pessoa.Id = idPessoa;
            return await _repository.Atualizar(pessoa);
        }

        public async Task ExcluirPessoa(Guid idPessoa)
        {
            var pessoa = _repository.ObterPorId(idPessoa);

            if (pessoa != null)
            {
                await _repository.Excluir(idPessoa);
            }
        }
    }
}
