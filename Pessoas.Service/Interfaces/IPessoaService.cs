using Pessoas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> ObterPessoas();
        Task<Pessoa> ObterPessoaPorCPF(long cpf);
        Task<Pessoa> CriarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoaPorCPF(Pessoa pessoa);
        Task ExcluirPessoaPorCPF(long cpf);
    }
}
