using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.locafest.Domain;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.locafest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
        private readonly IOperadorService _operadorService;

        public OperadorController(IOperadorService operadorService)
        {
            _operadorService = operadorService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Operador), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public Task Inserir(Operador operador)
        {
            var resultado = _operadorService.Inserir(operador);

            if(resultado.Invalid)
            {
                return Task.FromException(new ApplicationException("Erro ao processar cadastro! " + resultado.Notifications));
            }

            return Task.CompletedTask;
        }
    }
}
