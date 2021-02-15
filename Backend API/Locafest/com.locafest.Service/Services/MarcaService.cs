using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public Result Inserir(Marca marca)
        {
            try
            {
                int retorno = _marcaRepository.Inserir(marca);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    marca.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(marca.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                marca.AddNotification("Erros", e.Message);
                return Result.Error(marca.Notifications);
            }
            
        }
    }
}
