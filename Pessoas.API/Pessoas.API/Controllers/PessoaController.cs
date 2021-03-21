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

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Pessoa>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<Pessoa>>> Get()
        {
            return Ok(await _pessoaService.ObterPessoas());
        }

        [HttpGet("{cpf:long}", Name = "GetById")]
        [ProducesResponseType((200), Type = typeof(Pessoa))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Pessoa>> GetByCPF(long cpf)
        {
            try
            {
                var pessoa = await _pessoaService.ObterPessoaPorCPF(cpf);

                if (pessoa == null)
                {
                    return NotFound();
                }

                return Ok(pessoa);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Pessoa))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Post([FromBody] Pessoa pessoa)
        {

            if (pessoa == null) return BadRequest();

            var pdvCreated = await _pessoaService.CriarPessoa(pessoa);

            return Ok(pdvCreated);
        }

        [HttpPut("{cpf:long}")]
        [ProducesResponseType((200), Type = typeof(Pessoa))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> PutByCPF(long cpf, [FromBody] Pessoa pessoa)
        {

            if (pessoa == null) return BadRequest();

            var pessoaAualizada = await _pessoaService.AtualizarPessoaPorCPF(pessoa);

            return Ok(pessoaAualizada);
        }


        [HttpDelete("{cpf:long}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> DeleteByCPF(long cpf)
        {
            var pessoa = await _pessoaService.ObterPessoaPorCPF(cpf);

            if (pessoa == null)
            {
                return NotFound();
            }

            await _pessoaService.ExcluirPessoaPorCPF(cpf);
            return NoContent();
        }
    }
}
