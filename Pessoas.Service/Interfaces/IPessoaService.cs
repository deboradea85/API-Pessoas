using Pessoas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> ObterPessoas();
        Task<Pessoa> ObterPessoaPorId(Guid idPessoa);
        Task<Pessoa> CriarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoa(Guid idPessoa, Pessoa pessoa);
        Task ExcluirPessoa(Guid idPessoa);
    }
}
