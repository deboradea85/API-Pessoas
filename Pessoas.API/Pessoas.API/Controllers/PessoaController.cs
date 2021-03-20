using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pessoas.Domain.Models;
using Pessoas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pessoas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private IPessoaService _pessoaService;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Get()
        {
            return Ok(await _pessoaService.ObterPessoas());
        }
    }
}
