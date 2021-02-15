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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Modelo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public Task Inserir(Modelo modelo)
        {
            var resultado = _modeloService.Inserir(modelo);

            if (resultado.Invalid)
            {
                return Task.FromException(new ApplicationException("Erro ao processar cadastro! " + resultado.Notifications));
            }

            return Task.CompletedTask;
        }
    }
}
