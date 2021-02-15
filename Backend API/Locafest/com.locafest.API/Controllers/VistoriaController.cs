using System;
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
    public class VistoriaController : ControllerBase
    {
        private readonly IVistoriaService _vistoriaService;

        public VistoriaController(IVistoriaService vistoriaService)
        {
            _vistoriaService = vistoriaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vistoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public Task Inserir(Vistoria vistoria)
        {
            var resultado = _vistoriaService.Inserir(vistoria);

            if (resultado.Invalid)
            {
                return Task.FromException(new ApplicationException("Erro ao processar cadastro! " + resultado.Notifications));
            }

            return Task.CompletedTask;
        }
    }
}
