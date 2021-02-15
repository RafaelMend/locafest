using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public Result Inserir(Modelo modelo)
        {
            try
            {
                int retorno = _modeloRepository.Inserir(modelo);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    modelo.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(modelo.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                modelo.AddNotification("Erros", e.Message);
                return Result.Error(modelo.Notifications);
            }
            
        }
    }
}
