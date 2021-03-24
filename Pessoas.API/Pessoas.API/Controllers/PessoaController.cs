using Microsoft.AspNetCore.Mvc;
using Pessoas.Domain.Models;
using Pessoas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoas.API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/pessoas/v{version:apiVersion}")]
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

        [HttpGet("{cpf:long}", Name = "GetByCPF")]
        [ProducesResponseType((200), Type = typeof(Pessoa))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
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
            catch (Exception ex)
            {
                return BadRequest(new { type = ex.HelpLink ?? ex.GetType().Name, title = "Erro: " + ex.Message, status = 400, traceId = ex.HResult });
            }

        }
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(Pessoa))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> Post([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null) return BadRequest();

                var pdvCreated = await _pessoaService.CriarPessoa(pessoa);

                return new CreatedAtRouteResult("GetByCPF", pdvCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { type = ex.HelpLink ?? ex.GetType().Name, title = "Erro: " + ex.Message, status = 404, traceId = ex.HResult });
            }
        }

        [HttpPut("{cpf:long}")]
        [ProducesResponseType((200), Type = typeof(Pessoa))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> PutByCPF(long cpf, [FromBody] Pessoa pessoa)
        {
            try
            {

                if (pessoa == null) return BadRequest();
                pessoa.Cpf = cpf;
                var pessoaAualizada = await _pessoaService.AtualizarPessoaPorCPF(pessoa);

                return Ok(pessoaAualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { type = ex.HelpLink ?? ex.GetType().Name, title = "Erro: " + ex.Message, status = 404, traceId = ex.HResult });
            }
        }


        [HttpDelete("{cpf:long}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> DeleteByCPF(long cpf)
        {
            try
            {
                var pessoa = await _pessoaService.ObterPessoaPorCPF(cpf);

                if (pessoa == null)
                {
                    return NotFound();
                }

                await _pessoaService.ExcluirPessoaPorCPF(cpf);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { type = ex.HelpLink ?? ex.GetType().Name, title = "Erro: " + ex.Message, status = 404, traceId = ex.HResult });
            }
        }
    }
}
