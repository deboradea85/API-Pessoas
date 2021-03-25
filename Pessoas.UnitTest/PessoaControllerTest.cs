using Microsoft.AspNetCore.Mvc;
using Pessoas.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.UnitTest
{
    public sealed class PessoaControllerTest
    {
        private readonly IPessoasUnitTestService _service;

        public PessoaControllerTest()
        {
            _service = new PessoasUnitTestService();
        }


        public async Task GetAsync()
        {
            await _service.GetAsync();
        }

        public async Task GetByCPFAsync()
        {
            await _service.GetByCPFAsync();
        }

        public async Task PostAsync()
        {
            await _service.PostAsync();
        }

        public async Task PutByCPFAsync()
        {
            await _service.PutByCPFAsync();
        }

        public async Task DeleteByCPFAsync()
        {
            await _service.DeleteByCPFAsync();
        }
    }
}
