﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.locafest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Veiculo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public Task Inserir(Veiculo veiculo)
        {
            var resultado = _veiculoService.Inserir(veiculo);

            if (resultado.Invalid)
            {
                return Task.FromException(new ApplicationException("Erro ao processar cadastro! " + resultado.Notifications));
            }

            return Task.CompletedTask;
        }
    }
}
