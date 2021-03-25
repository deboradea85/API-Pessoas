using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pessoas.API.Controllers;
using Pessoas.Domain.Models;
using Pessoas.Repository;
using Pessoas.Repository.Interfaces.Generic;
using Pessoas.Repository.Repositories.Generic;
using Pessoas.Service.Interfaces;
using Pessoas.Service.Services;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace Pessoas.UnitTest
{
    public class PessoasUnitTestService : IPessoasUnitTestService

    {
        //private readonly ApplicationDbContext _context;
        //private PessoaController _controller;
        //private IPessoaService _pessoaService;
        //private IRepository<Pessoa> _repositoryPessoa;
        //private readonly IRepository<Endereco> _repositoryEndereco;
        //private readonly IRepository<Telefone> _repositoryTelefone;
        //private Pessoa _pessoa;

        //public PessoasUnitTestService()
        //{

        //    _context = new ApplicationDbContext(null);
        //    _repositoryPessoa = new Repository<Pessoa>(_context); ;
        //    _repositoryEndereco = new Repository<Endereco>(_context);
        //    _repositoryTelefone = new Repository<Telefone>(_context);
        //    _pessoaService = new PessoaService(_repositoryPessoa, _repositoryEndereco, _repositoryTelefone);
        //    _controller = new PessoaController(_pessoaService);
        //    _pessoa = new Pessoa();
        //}


        [Fact]
        public async Task GetAsync()
        {
            var result = new Task(null);
            var expected = new Task(null);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task GetByCPFAsync()
        {
            var result = new Task(null);
            var expected = new Task(null);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task PostAsync()
        {
            var result = new Task(null);
            var expected = new Task(null);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task PutByCPFAsync()
        {
            var result = new Task(null);
            var expected = new Task(null);
            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task DeleteByCPFAsync()
        {
            var result = new Task(null);
            var expected = new Task(null);
            Assert.Equal(expected, result);
        }
    }
}
