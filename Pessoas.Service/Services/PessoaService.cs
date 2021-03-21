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
        private readonly string[] children;

        public PessoaService(IRepository<Pessoa> repository)
        {
            _repository = repository;
            children = new string[] { "Endereco", "Telefone" };
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoas()
        {        
            return await _repository.GetAllFilterJoin(p => p.Id != null, children);
        }

        public async Task<Pessoa> ObterPessoaPorCPF(long cpf)
        {
            var pessoas = await _repository.GetAllFilterJoin(p => p.Cpf == cpf, children);
            return pessoas.FirstOrDefault();
        }

        public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
        {
            var pessoaCPF = ObterPessoaPorCPF(pessoa.Cpf);

            if (pessoaCPF.Result == null)
            {
                return await _repository.Create(pessoa);

            }
            else
            {
                throw new Exception("Já existe Pessoa com este CPF");
            }
            
        }

        public async Task<Pessoa> AtualizarPessoaPorCPF(Pessoa pessoa)
        {
            var pessoaAtualizar = ObterPessoaPorCPF(pessoa.Cpf);
            if (pessoaAtualizar.Result != null)
            {
                pessoa.Id = pessoaAtualizar.Result.Id;
                return await _repository.Update(pessoa);
            }
            else
            {
                throw new Exception("A pessoa a ser atualizada não foi encontrada");
            }
            
            
        }

        public async Task ExcluirPessoaPorCPF(long cpf)
        {
            var pessoa = ObterPessoaPorCPF(cpf);

            if (pessoa.Result != null)
            {
                await _repository.Delete(pessoa.Result);
            }
        }
    }
}
