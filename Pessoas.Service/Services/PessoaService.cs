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

        private readonly IRepository<Pessoa> _repositoryPessoa;
        private readonly IRepository<Endereco> _repositoryEndereco;
        private readonly IRepository<Telefone> _repositoryTelefone;
        private readonly string[] children;

        public PessoaService(IRepository<Pessoa> repositoryPessoa, IRepository<Endereco> repositoryEndereco, IRepository<Telefone> repositoryTelefone)
        {
            _repositoryPessoa = repositoryPessoa;
            _repositoryEndereco = repositoryEndereco;
            _repositoryTelefone = repositoryTelefone;
            children = new string[] { "Endereco", "Telefone" };
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoas()
        {
            return await _repositoryPessoa.GetAll(children);
        }

        public async Task<Pessoa> ObterPessoaPorCPF(long cpf)
        {
            var pessoas = await _repositoryPessoa.GetAllFilterJoin(p => p.Cpf == cpf, children);
            return pessoas.FirstOrDefault();
        }

        public async Task<Pessoa> CriarPessoa(Pessoa pessoa)
        {
            var pessoaCPF = ObterPessoaPorCPF(pessoa.Cpf);

            if (pessoaCPF.Result == null)
            {
                return await _repositoryPessoa.Create(pessoa);

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
               
                pessoa.Telefone.Id = pessoaAtualizar.Result.Telefone.Id;
                pessoa.Telefone.PessoaTelefoneId = pessoaAtualizar.Result.Id;

                pessoa.Endereco.Id = pessoaAtualizar.Result.Endereco.Id;
                pessoa.Endereco.PessoaEnderecoId = pessoaAtualizar.Result.Id;

                var pessoaUpdated = _repositoryPessoa.Update(pessoa).Result;
                var enderecoUpdated = _repositoryEndereco.Update(pessoa.Endereco).Result;
                var telefoneUpdated = _repositoryTelefone.Update(pessoa.Telefone).Result;
             
                return pessoa;
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
                await _repositoryPessoa.Delete(pessoa.Result);
            }
        }
    }
}
