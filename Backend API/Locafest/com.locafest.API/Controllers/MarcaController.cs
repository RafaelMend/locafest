using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.locafest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Marca), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public Task Inserir(Marca marca)
        {
            var resultado = _marcaService.Inserir(marca);

            if (resultado.Invalid)
            {
                return Task.FromException(new ApplicationException("Erro ao processar cadastro! " + resultado.Notifications));
            }

            return Task.CompletedTask;
        }
    }
}
