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
            //return Enumerable.Range(1, 5).Select(index => new Pessoa
            //{
            //    Nome = "Debora",
            //    Rg = 9999999999,
            //    Cpf = 99999999999,
            //    Telefone = new Telefone { Tipo = "Celular", Numero = 99999999999999999 },
            //    Endereco = new Endereco { Cep = 99999999, Logradouro = "Rua das Flores amarelas", Numero = 598698545, Complemento = "Quadra 27", Bairro = "Jardim das Margaridas", Municipio = "Salvadror", UF = "BA" }
            //})
            //.ToArray();
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
