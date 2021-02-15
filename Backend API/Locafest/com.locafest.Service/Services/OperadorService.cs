using com.locafest.Domain;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class OperadorService : IOperadorService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IOperadorRepository _operadorRepository;  

        public OperadorService(IUsuarioRepository usuarioRepository, IOperadorRepository operadorRepository)
        {
            _usuarioRepository = usuarioRepository;
            _operadorRepository = operadorRepository;
        }

        public Result Inserir(Operador operador)
        {
            try
            {
                if (operador.Usuario != null)
                    _usuarioRepository.Inserir(operador.Usuario);
                int retorno = _operadorRepository.Inserir(operador);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    operador.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(operador.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                operador.AddNotification("Erros", e.Message);
                return Result.Error(operador.Notifications);
            }
            
        }
    }
}
