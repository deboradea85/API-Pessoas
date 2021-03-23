using Microsoft.AspNetCore.Mvc;
using Pessoas.API.Controllers;
using Pessoas.Domain.Models;
using Pessoas.Repository.Interfaces.Generic;
using Pessoas.Service.Interfaces;
using Pessoas.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pessoas.UnitTest
{
    public class PessoaControllerTest
    {
        private PessoaController _controller;
        private IPessoaService _pessoaService;
        private IRepository<Pessoa> _repository;
        private Pessoa _pessoa;
        public PessoaControllerTest()
        {
            _pessoaService = new PessoaService(_repository);
            _controller = new PessoaController(_pessoaService);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //// Act
            //var okResult = _controller.Get();
            //// Assert
            //Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            //// Act
            //var okResult = _controller.Get().Result as OkObjectResult;
            //// Assert
            //var items = Assert.IsType<List<Pessoa>>(okResult.Value);
            //Assert.Equal(3, items.Count);
        }
    }
}
