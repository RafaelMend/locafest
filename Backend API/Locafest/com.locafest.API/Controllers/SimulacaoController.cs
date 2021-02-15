using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using com.locafest.Domain.LocacaoContext.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.locafest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacaoController : ControllerBase
    {
        private readonly ISimulacaoService _simulacaoService;

        public SimulacaoController(ISimulacaoService simulacaoService)
        {
            _simulacaoService = simulacaoService;
        }

        /// <response code="200">Retorna as informações</response>
        /// <response code="400">Parâmetros inválidos</response>
        /// <response code="503">Serviço indisponível no momento</response>
        /// <response code="500">Ocorreu um erro inesperado</response>
        [HttpGet]
        [Route("obter-simulacao")]
        [ProducesResponseType(typeof(SimulacaoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult ObterSimulacao(Guid veiculoId, DateTime dataRetirada, DateTime dataDevolucao)
        {
            var simulacao = _simulacaoService.ObterSimulacao(veiculoId, dataRetirada, dataDevolucao);

            if (simulacao == null)
            {
                return NotFound("Nenhuma simulação encontrado.");
            }

            return Ok(simulacao);
        }
    }
}
